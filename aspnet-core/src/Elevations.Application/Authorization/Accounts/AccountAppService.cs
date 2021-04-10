namespace Elevations.Authorization.Accounts
{
    using System.Threading.Tasks;

    using Abp.Configuration;
    using Abp.Zero.Configuration;

    using Elevations.Authorization.Accounts.Dto;
    using Elevations.Authorization.Users;
    using Elevations.MultiTenancy;

    public class AccountAppService : ElevationsAppServiceBase, IAccountAppService
    {
        // from: http://regexlib.com/REDetails.aspx?regexp_id=1923
        public const string PasswordRegex =
            "(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$";

        private readonly UserRegistrationManager _userRegistrationManager;

        public AccountAppService(UserRegistrationManager userRegistrationManager)
        {
            _userRegistrationManager = userRegistrationManager;
        }

        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            Tenant tenant = await TenantManager.FindByTenancyNameAsync(input.TenancyName);
            if (tenant == null)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.NotFound);
            }

            if (!tenant.IsActive)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.InActive);
            }

            return new IsTenantAvailableOutput(TenantAvailabilityState.Available, tenant.Id);
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            User user = await _userRegistrationManager.RegisterAsync(
                            input.Name,
                            input.Surname,
                            input.EmailAddress,
                            input.UserName,
                            input.Password,
                            true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
                        );

            bool isEmailConfirmationRequiredForLogin =
                await SettingManager.GetSettingValueAsync<bool>(
                    AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
                       {
                           CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
                       };
        }
    }
}