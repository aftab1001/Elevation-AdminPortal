namespace Elevations.Authentication.External
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Dependency;

    public class ExternalAuthManager : IExternalAuthManager, ITransientDependency
    {
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;

        private readonly IIocResolver _iocResolver;

        public ExternalAuthManager(IIocResolver iocResolver, IExternalAuthConfiguration externalAuthConfiguration)
        {
            _iocResolver = iocResolver;
            _externalAuthConfiguration = externalAuthConfiguration;
        }

        public IDisposableDependencyObjectWrapper<IExternalAuthProviderApi> CreateProviderApi(string provider)
        {
            ExternalLoginProviderInfo? providerInfo =
                _externalAuthConfiguration.Providers.FirstOrDefault(p => p.Name == provider);
            if (providerInfo == null)
            {
                throw new Exception("Unknown external auth provider: " + provider);
            }

            IDisposableDependencyObjectWrapper<IExternalAuthProviderApi> providerApi =
                _iocResolver.ResolveAsDisposable<IExternalAuthProviderApi>(providerInfo.ProviderApiType);
            providerApi.Object.Initialize(providerInfo);
            return providerApi;
        }

        public Task<ExternalAuthUserInfo> GetUserInfo(string provider, string accessCode)
        {
            using (IDisposableDependencyObjectWrapper<IExternalAuthProviderApi> providerApi =
                CreateProviderApi(provider))
            {
                return providerApi.Object.GetUserInfo(accessCode);
            }
        }

        public Task<bool> IsValidUser(string provider, string providerKey, string providerAccessCode)
        {
            using (IDisposableDependencyObjectWrapper<IExternalAuthProviderApi> providerApi =
                CreateProviderApi(provider))
            {
                return providerApi.Object.IsValidUser(providerKey, providerAccessCode);
            }
        }
    }
}