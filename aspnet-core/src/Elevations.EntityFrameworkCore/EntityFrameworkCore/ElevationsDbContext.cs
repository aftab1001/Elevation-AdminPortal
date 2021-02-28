using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Elevations.Authorization.Roles;
using Elevations.Authorization.Users;
using Elevations.MultiTenancy;

namespace Elevations.EntityFrameworkCore
{
    public class ElevationsDbContext : AbpZeroDbContext<Tenant, Role, User, ElevationsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ElevationsDbContext(DbContextOptions<ElevationsDbContext> options)
            : base(options)
        {
        }
    }
}
