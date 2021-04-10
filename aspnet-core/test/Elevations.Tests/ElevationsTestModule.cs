namespace Elevations.Tests
{
    using System;

    using Abp.AutoMapper;
    using Abp.Configuration.Startup;
    using Abp.Dependency;
    using Abp.Modules;
    using Abp.Net.Mail;
    using Abp.TestBase;
    using Abp.Zero.Configuration;
    using Abp.Zero.EntityFrameworkCore;

    using Castle.MicroKernel.Registration;

    using Elevations.EntityFrameworkCore;
    using Elevations.Tests.DependencyInjection;

    using NSubstitute;

    [DependsOn(typeof(ElevationsApplicationModule), typeof(ElevationsEntityFrameworkModule), typeof(AbpTestBaseModule))]
    public class ElevationsTestModule : AbpModule
    {
        public ElevationsTestModule(ElevationsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            // Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<AbpZeroDbMigrator<ElevationsDbContext>>();

            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
        }

        private void RegisterFakeService<TService>()
            where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>().UsingFactoryMethod(() => Substitute.For<TService>()).LifestyleSingleton());
        }
    }
}