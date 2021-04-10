namespace Elevations.Controllers
{
    using Abp.AspNetCore.Mvc.Controllers;
    using Abp.IdentityFramework;

    using Microsoft.AspNetCore.Identity;

    public abstract class ElevationsControllerBase : AbpController
    {
        protected ElevationsControllerBase()
        {
            LocalizationSourceName = ElevationsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}