namespace Elevations.Web.Host.Startup
{
    using Abp.Modules;
    using Abp.Reflection.Extensions;

    using Elevations.Configuration;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    [DependsOn(typeof(ElevationsWebCoreModule))]
    public class ElevationsWebHostModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        private readonly IWebHostEnvironment _env;

        public ElevationsWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ElevationsWebHostModule).GetAssembly());
        }
    }
}