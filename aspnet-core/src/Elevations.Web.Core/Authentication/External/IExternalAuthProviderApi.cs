namespace Elevations.Authentication.External
{
    using System.Threading.Tasks;

    public interface IExternalAuthProviderApi
    {
        ExternalLoginProviderInfo ProviderInfo { get; }

        Task<ExternalAuthUserInfo> GetUserInfo(string accessCode);

        void Initialize(ExternalLoginProviderInfo providerInfo);

        Task<bool> IsValidUser(string userId, string accessCode);
    }
}