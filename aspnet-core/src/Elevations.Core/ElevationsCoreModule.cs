namespace Elevations
{
    using Abp.Localization;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using Abp.Timing;
    using Abp.Zero;
    using Abp.Zero.Configuration;

    using Elevations.Authorization.Roles;
    using Elevations.Authorization.Users;
    using Elevations.Configuration;
    using Elevations.Localization;
    using Elevations.MultiTenancy;
    using Elevations.Timing;

    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ElevationsCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ElevationsCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }

        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            ElevationsLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ElevationsConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
        }
    }
}