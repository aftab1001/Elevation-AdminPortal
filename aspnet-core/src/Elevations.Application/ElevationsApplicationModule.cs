using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Elevations.Authorization;

namespace Elevations
{
    [DependsOn(
        typeof(ElevationsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ElevationsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ElevationsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ElevationsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
