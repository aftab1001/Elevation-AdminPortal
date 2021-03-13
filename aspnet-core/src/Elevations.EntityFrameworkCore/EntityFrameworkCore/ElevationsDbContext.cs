using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Elevations.Authorization.Roles;
using Elevations.Authorization.Users;
using Elevations.MultiTenancy;

namespace Elevations.EntityFrameworkCore
{
    using Elevations.EntityFrameworkCore.HotelDto;

    public class ElevationsDbContext : AbpZeroDbContext<Tenant, Role, User, ElevationsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<RoomsCategory> RoomsCategory { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
       
        public ElevationsDbContext(DbContextOptions<ElevationsDbContext> options)
            : base(options)
        {
        }
    }
}
