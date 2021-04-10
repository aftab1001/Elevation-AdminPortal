namespace Elevations.EntityFrameworkCore.Seed
{
    using System;
    using System.Transactions;

    using Abp.Dependency;
    using Abp.Domain.Uow;
    using Abp.EntityFrameworkCore.Uow;
    using Abp.MultiTenancy;

    using Elevations.EntityFrameworkCore.Seed.Host;
    using Elevations.EntityFrameworkCore.Seed.Tenants;

    using Microsoft.EntityFrameworkCore;

    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<ElevationsDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(ElevationsDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (IDisposableDependencyObjectWrapper<IUnitOfWorkManager> uowManager =
                iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (IUnitOfWorkCompleteHandle uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    TDbContext context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}