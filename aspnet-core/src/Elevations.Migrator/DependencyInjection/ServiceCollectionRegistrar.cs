namespace Elevations.Migrator.DependencyInjection
{
    using Abp.Dependency;

    using Castle.Windsor.MsDependencyInjection;

    using Elevations.Identity;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            ServiceCollection services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);
        }
    }
}