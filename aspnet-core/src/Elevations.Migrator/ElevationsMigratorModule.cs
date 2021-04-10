namespace Elevations.Migrator
{
    using Abp.Events.Bus;
    using Abp.Modules;
    using Abp.Reflection.Extensions;

    using Castle.MicroKernel.Registration;

    using Elevations.Configuration;
    using Elevations.EntityFrameworkCore;
    using Elevations.Migrator.DependencyInjection;

    using Microsoft.Extensions.Configuration;

    [DependsOn(typeof(ElevationsEntityFrameworkModule))]
    public class ElevationsMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ElevationsMigratorModule(ElevationsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ElevationsMigratorModule).GetAssembly().GetDirectoryPathOrNull());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ElevationsMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ElevationsConsts.ConnectionStringName);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus),
                () => IocManager.IocContainer.Register(Component.For<IEventBus>().Instance(NullEventBus.Instance)));
        }
    }
}