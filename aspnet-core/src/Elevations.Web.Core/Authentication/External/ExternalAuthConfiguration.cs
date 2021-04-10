namespace Elevations.Authentication.External
{
    using System.Collections.Generic;

    using Abp.Dependency;

    public class ExternalAuthConfiguration : IExternalAuthConfiguration, ISingletonDependency
    {
        public ExternalAuthConfiguration()
        {
            Providers = new List<ExternalLoginProviderInfo>();
        }

        public List<ExternalLoginProviderInfo> Providers { get; }
    }
}