namespace Elevations.EntityFrameworkCore
{
    using Elevations.Configuration;
    using Elevations.Web;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ElevationsDbContextFactory : IDesignTimeDbContextFactory<ElevationsDbContext>
    {
        public ElevationsDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ElevationsDbContext> builder = new DbContextOptionsBuilder<ElevationsDbContext>();
            IConfigurationRoot configuration =
                AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ElevationsDbContextConfigurer.Configure(
                builder,
                configuration.GetConnectionString(ElevationsConsts.ConnectionStringName));


            return new ElevationsDbContext(builder.Options);
        }
    }
}