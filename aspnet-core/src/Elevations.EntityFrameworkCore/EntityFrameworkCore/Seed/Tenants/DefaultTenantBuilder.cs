namespace Elevations.EntityFrameworkCore.Seed.Tenants
{
    using System.Linq;

    using Abp.Application.Editions;
    using Abp.MultiTenancy;

    using Elevations.Editions;
    using Elevations.MultiTenancy;

    using Microsoft.EntityFrameworkCore;

    public class DefaultTenantBuilder
    {
        private readonly ElevationsDbContext _context;

        public DefaultTenantBuilder(ElevationsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultTenant();
        }

        private void CreateDefaultTenant()
        {
            // Default tenant

            Tenant? defaultTenant = _context.Tenants.IgnoreQueryFilters()
                .FirstOrDefault(t => t.TenancyName == AbpTenantBase.DefaultTenantName);
            if (defaultTenant == null)
            {
                defaultTenant = new Tenant(AbpTenantBase.DefaultTenantName, AbpTenantBase.DefaultTenantName);

                Edition? defaultEdition = _context.Editions.IgnoreQueryFilters()
                    .FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
                if (defaultEdition != null)
                {
                    defaultTenant.EditionId = defaultEdition.Id;
                }

                _context.Tenants.Add(defaultTenant);
                _context.SaveChanges();
            }
        }
    }
}