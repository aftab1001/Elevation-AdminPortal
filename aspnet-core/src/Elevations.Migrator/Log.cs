namespace Elevations.Migrator
{
    using System;

    using Abp.Dependency;
    using Abp.Timing;

    using Castle.Core.Logging;

    public class Log : ITransientDependency
    {
        public Log()
        {
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Write(string text)
        {
            Console.WriteLine(Clock.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + text);
            Logger.Info(text);
        }
    }
}