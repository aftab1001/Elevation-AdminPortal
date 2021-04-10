namespace Elevations.Authentication.External
{
    using System.Threading.Tasks;

    public interface IExternalAuthManager
    {
        Task<ExternalAuthUserInfo> GetUserInfo(string provider, string accessCode);

        Task<bool> IsValidUser(string provider, string providerKey, string providerAccessCode);
    }
}