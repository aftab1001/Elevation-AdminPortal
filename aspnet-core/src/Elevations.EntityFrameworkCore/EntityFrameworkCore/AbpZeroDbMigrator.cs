namespace Elevations.EntityFrameworkCore
{
    using Abp.Domain.Uow;
    using Abp.EntityFrameworkCore;
    using Abp.MultiTenancy;
    using Abp.Zero.EntityFrameworkCore;

    public class AbpZeroDbMigrator : AbpZeroDbMigrator<ElevationsDbContext>
    {
        public AbpZeroDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IDbContextResolver dbContextResolver)
            : base(unitOfWorkManager, connectionStringResolver, dbContextResolver)
        {
        }
    }
}