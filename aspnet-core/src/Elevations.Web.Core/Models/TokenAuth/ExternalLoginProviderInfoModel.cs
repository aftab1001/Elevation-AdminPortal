namespace Elevations.Models.TokenAuth
{
    using Abp.AutoMapper;

    using Elevations.Authentication.External;

    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string ClientId { get; set; }

        public string Name { get; set; }
    }
}