using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Elevations.Configuration;
using Elevations.Web;

namespace Elevations.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ElevationsDbContextFactory : IDesignTimeDbContextFactory<ElevationsDbContext>
    {
        public ElevationsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ElevationsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ElevationsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ElevationsConsts.ConnectionStringName));

            return new ElevationsDbContext(builder.Options);
        }
    }
}
