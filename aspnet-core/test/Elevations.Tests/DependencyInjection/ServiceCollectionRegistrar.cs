namespace Elevations.Tests.DependencyInjection
{
    using System;

    using Abp.Dependency;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor.MsDependencyInjection;

    using Elevations.EntityFrameworkCore;
    using Elevations.Identity;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            ServiceCollection services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            services.AddEntityFrameworkInMemoryDatabase();

            IServiceProvider serviceProvider =
                WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

            DbContextOptionsBuilder<ElevationsDbContext> builder = new DbContextOptionsBuilder<ElevationsDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

            iocManager.IocContainer.Register(
                Component.For<DbContextOptions<ElevationsDbContext>>().Instance(builder.Options).LifestyleSingleton());
        }
    }
}