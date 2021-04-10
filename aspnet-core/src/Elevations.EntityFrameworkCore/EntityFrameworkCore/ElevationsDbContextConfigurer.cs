namespace Elevations.EntityFrameworkCore
{
    using System.Data.Common;

    using Microsoft.EntityFrameworkCore;

    public static class ElevationsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ElevationsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ElevationsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}