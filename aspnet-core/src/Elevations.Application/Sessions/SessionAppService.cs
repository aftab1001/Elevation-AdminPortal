namespace Elevations.Sessions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Auditing;

    using Elevations.Sessions.Dto;

    public class SessionAppService : ElevationsAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            GetCurrentLoginInformationsOutput output = new GetCurrentLoginInformationsOutput
                                                           {
                                                               Application = new ApplicationInfoDto
                                                                                 {
                                                                                     Version = AppVersionHelper.Version,
                                                                                     ReleaseDate =
                                                                                         AppVersionHelper.ReleaseDate,
                                                                                     Features =
                                                                                         new Dictionary<string, bool>()
                                                                                 }
                                                           };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
            }

            return output;
        }
    }
}