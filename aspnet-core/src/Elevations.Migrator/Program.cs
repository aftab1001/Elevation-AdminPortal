namespace Elevations.Migrator
{
    using System;

    using Abp;
    using Abp.Castle.Logging.Log4Net;
    using Abp.Collections.Extensions;
    using Abp.Dependency;

    using Castle.Facilities.Logging;

    public class Program
    {
        private static bool _quietMode;

        public static void Main(string[] args)
        {
            ParseArgs(args);

            using (AbpBootstrapper bootstrapper = AbpBootstrapper.Create<ElevationsMigratorModule>())
            {
                bootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config"));

                bootstrapper.Initialize();

                using (IDisposableDependencyObjectWrapper<MultiTenantMigrateExecuter> migrateExecuter =
                    bootstrapper.IocManager.ResolveAsDisposable<MultiTenantMigrateExecuter>())
                {
                    bool migrationSucceeded = migrateExecuter.Object.Run(_quietMode);

                    if (_quietMode)
                    {
                        // exit clean (with exit code 0) if migration is a success, otherwise exit with code 1
                        int exitCode = Convert.ToInt32(!migrationSucceeded);
                        Environment.Exit(exitCode);
                    }
                    else
                    {
                        Console.WriteLine("Press ENTER to exit...");
                        Console.ReadLine();
                    }
                }
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.IsNullOrEmpty())
            {
                return;
            }

            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-q":
                        _quietMode = true;
                        break;
                }
            }
        }
    }
}