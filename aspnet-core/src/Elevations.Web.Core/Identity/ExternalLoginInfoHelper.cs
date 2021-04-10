namespace Elevations.Identity
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    using Abp.Extensions;

    public class ExternalLoginInfoHelper
    {
        public static (string name, string surname) GetNameAndSurnameFromClaims(List<Claim> claims)
        {
            string name = null;
            string surname = null;

            Claim? givennameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            if (givennameClaim != null && !givennameClaim.Value.IsNullOrEmpty())
            {
                name = givennameClaim.Value;
            }

            Claim? surnameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname);
            if (surnameClaim != null && !surnameClaim.Value.IsNullOrEmpty())
            {
                surname = surnameClaim.Value;
            }

            if (name == null || surname == null)
            {
                Claim? nameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                if (nameClaim != null)
                {
                    string nameSurName = nameClaim.Value;
                    if (!nameSurName.IsNullOrEmpty())
                    {
                        int lastSpaceIndex = nameSurName.LastIndexOf(' ');
                        if (lastSpaceIndex < 1 || lastSpaceIndex > nameSurName.Length - 2)
                        {
                            name = surname = nameSurName;
                        }
                        else
                        {
                            name = nameSurName.Substring(0, lastSpaceIndex);
                            surname = nameSurName.Substring(lastSpaceIndex);
                        }
                    }
                }
            }

            return (name, surname);
        }
    }
}