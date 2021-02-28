using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Elevations.EntityFrameworkCore;
using Elevations.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Elevations.Web.Tests
{
    [DependsOn(
        typeof(ElevationsWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ElevationsWebTestModule : AbpModule
    {
        public ElevationsWebTestModule(ElevationsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ElevationsWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ElevationsWebMvcModule).Assembly);
        }
    }
}