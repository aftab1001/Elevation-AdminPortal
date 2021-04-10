namespace Elevations
{
    using System;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.IdentityFramework;
    using Abp.Runtime.Session;

    using Elevations.Authorization.Users;
    using Elevations.MultiTenancy;

    using Microsoft.AspNetCore.Identity;

    /// <summary>
    ///     Derive your application services from this class.
    /// </summary>
    public abstract class ElevationsAppServiceBase : ApplicationService
    {
        protected ElevationsAppServiceBase()
        {
            LocalizationSourceName = ElevationsConsts.LocalizationSourceName;
        }

        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            User user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }
    }
}