namespace Elevations.Authentication.External
{
    using System;

    public class ExternalLoginProviderInfo
    {
        public ExternalLoginProviderInfo(string name, string clientId, string clientSecret, Type providerApiType)
        {
            Name = name;
            ClientId = clientId;
            ClientSecret = clientSecret;
            ProviderApiType = providerApiType;
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Name { get; set; }

        public Type ProviderApiType { get; set; }
    }
}