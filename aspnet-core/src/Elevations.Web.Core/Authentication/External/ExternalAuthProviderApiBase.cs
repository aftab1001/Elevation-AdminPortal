namespace Elevations.Authentication.External
{
    using System.Threading.Tasks;

    using Abp.Dependency;

    public abstract class ExternalAuthProviderApiBase : IExternalAuthProviderApi, ITransientDependency
    {
        public ExternalLoginProviderInfo ProviderInfo { get; set; }

        public abstract Task<ExternalAuthUserInfo> GetUserInfo(string accessCode);

        public void Initialize(ExternalLoginProviderInfo providerInfo)
        {
            ProviderInfo = providerInfo;
        }

        public async Task<bool> IsValidUser(string userId, string accessCode)
        {
            ExternalAuthUserInfo userInfo = await GetUserInfo(accessCode);
            return userInfo.ProviderKey == userId;
        }
    }
}