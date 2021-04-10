namespace Elevations.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Abp.Authorization;
    using Abp.Authorization.Users;
    using Abp.MultiTenancy;
    using Abp.Runtime.Security;
    using Abp.UI;

    using Elevations.Authentication.External;
    using Elevations.Authentication.JwtBearer;
    using Elevations.Authorization;
    using Elevations.Authorization.Users;
    using Elevations.Models.TokenAuth;
    using Elevations.MultiTenancy;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    public class TokenAuthController : ElevationsControllerBase
    {
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;

        private readonly TokenAuthConfiguration _configuration;

        private readonly IExternalAuthConfiguration _externalAuthConfiguration;

        private readonly IExternalAuthManager _externalAuthManager;

        private readonly LogInManager _logInManager;

        private readonly ITenantCache _tenantCache;

        private readonly UserRegistrationManager _userRegistrationManager;

        public TokenAuthController(
            LogInManager logInManager,
            ITenantCache tenantCache,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            TokenAuthConfiguration configuration,
            IExternalAuthConfiguration externalAuthConfiguration,
            IExternalAuthManager externalAuthManager,
            UserRegistrationManager userRegistrationManager)
        {
            _logInManager = logInManager;
            _tenantCache = tenantCache;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _configuration = configuration;
            _externalAuthConfiguration = externalAuthConfiguration;
            _externalAuthManager = externalAuthManager;
            _userRegistrationManager = userRegistrationManager;
        }

        [HttpPost]
        public async Task<AuthenticateResultModel> Authenticate([FromBody] AuthenticateModel model)
        {
            AbpLoginResult<Tenant, User> loginResult = await GetLoginResultAsync(
                                                           model.UserNameOrEmailAddress,
                                                           model.Password,
                                                           GetTenancyNameOrNull());

            string accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));

            return new AuthenticateResultModel
                       {
                           AccessToken = accessToken, EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                           ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds, UserId = loginResult.User.Id
                       };
        }

        [HttpPost]
        public async Task<ExternalAuthenticateResultModel> ExternalAuthenticate(
            [FromBody] ExternalAuthenticateModel model)
        {
            ExternalAuthUserInfo externalUser = await GetExternalUserInfo(model);

            AbpLoginResult<Tenant, User> loginResult = await _logInManager.LoginAsync(
                                                           new UserLoginInfo(
                                                               model.AuthProvider,
                                                               model.ProviderKey,
                                                               model.AuthProvider),
                                                           GetTenancyNameOrNull());

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    {
                        string accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));
                        return new ExternalAuthenticateResultModel
                                   {
                                       AccessToken = accessToken,
                                       EncryptedAccessToken = GetEncryptedAccessToken(accessToken),
                                       ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                                   };
                    }
                case AbpLoginResultType.UnknownExternalLogin:
                    {
                        User newUser = await RegisterExternalUserAsync(externalUser);
                        if (!newUser.IsActive)
                        {
                            return new ExternalAuthenticateResultModel { WaitingForActivation = true };
                        }

                        // Try to login again with newly registered user!
                        loginResult = await _logInManager.LoginAsync(
                                          new UserLoginInfo(model.AuthProvider, model.ProviderKey, model.AuthProvider),
                                          GetTenancyNameOrNull());
                        if (loginResult.Result != AbpLoginResultType.Success)
                        {
                            throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                                loginResult.Result,
                                model.ProviderKey,
                                GetTenancyNameOrNull());
                        }

                        return new ExternalAuthenticateResultModel
                                   {
                                       AccessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity)),
                                       ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                                   };
                    }
                default:
                    {
                        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                            loginResult.Result,
                            model.ProviderKey,
                            GetTenancyNameOrNull());
                    }
            }
        }

        [HttpGet]
        public List<ExternalLoginProviderInfoModel> GetExternalAuthenticationProviders()
        {
            return ObjectMapper.Map<List<ExternalLoginProviderInfoModel>>(_externalAuthConfiguration.Providers);
        }

        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            List<Claim> claims = identity.Claims.ToList();
            Claim nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(
                new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(
                            JwtRegisteredClaimNames.Iat,
                            DateTimeOffset.Now.ToUnixTimeSeconds().ToString(),
                            ClaimValueTypes.Integer64)
                    });

            return claims;
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            DateTime now = DateTime.UtcNow;

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                _configuration.Issuer,
                _configuration.Audience,
                claims,
                now,
                now.Add(expiration ?? _configuration.Expiration),
                _configuration.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private string GetEncryptedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken, AppConsts.DefaultPassPhrase);
        }

        private async Task<ExternalAuthUserInfo> GetExternalUserInfo(ExternalAuthenticateModel model)
        {
            ExternalAuthUserInfo userInfo = await _externalAuthManager.GetUserInfo(
                                                model.AuthProvider,
                                                model.ProviderAccessCode);
            if (userInfo.ProviderKey != model.ProviderKey)
            {
                throw new UserFriendlyException(L("CouldNotValidateExternalUser"));
            }

            return userInfo;
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(
            string usernameOrEmailAddress,
            string password,
            string tenancyName)
        {
            AbpLoginResult<Tenant, User> loginResult =
                await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                        loginResult.Result,
                        usernameOrEmailAddress,
                        tenancyName);
            }
        }

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }

        private async Task<User> RegisterExternalUserAsync(ExternalAuthUserInfo externalUser)
        {
            User user = await _userRegistrationManager.RegisterAsync(
                            externalUser.Name,
                            externalUser.Surname,
                            externalUser.EmailAddress,
                            externalUser.EmailAddress,
                            Authorization.Users.User.CreateRandomPassword(),
                            true);

            user.Logins = new List<UserLogin>
                              {
                                  new UserLogin
                                      {
                                          LoginProvider = externalUser.Provider, ProviderKey = externalUser.ProviderKey,
                                          TenantId = user.TenantId
                                      }
                              };

            await CurrentUnitOfWork.SaveChangesAsync();

            return user;
        }
    }
}