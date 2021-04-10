namespace Elevations.Authentication.JwtBearer
{
    using System;

    using Microsoft.IdentityModel.Tokens;

    public class TokenAuthConfiguration
    {
        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; }

        public string Issuer { get; set; }

        public SymmetricSecurityKey SecurityKey { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }
}