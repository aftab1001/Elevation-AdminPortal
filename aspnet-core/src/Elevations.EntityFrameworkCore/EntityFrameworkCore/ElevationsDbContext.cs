﻿namespace Elevations.EntityFrameworkCore
{
    using Abp.Zero.EntityFrameworkCore;

    using Elevations.Authorization.Roles;
    using Elevations.Authorization.Users;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.MultiTenancy;

    using Microsoft.EntityFrameworkCore;

    public class ElevationsDbContext : AbpZeroDbContext<Tenant, Role, User, ElevationsDbContext>
    {
        public ElevationsDbContext(DbContextOptions<ElevationsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApartmentCategory> ApartmentCategory { get; set; }

        public DbSet<Apartments> Apartments { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        /* Define a DbSet for each entity of the application */
        public DbSet<RoomsCategory> RoomsCategory { get; set; }
    }
}