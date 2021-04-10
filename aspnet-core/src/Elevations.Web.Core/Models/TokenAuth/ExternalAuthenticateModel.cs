namespace Elevations.Models.TokenAuth
{
    using System.ComponentModel.DataAnnotations;

    using Abp.Authorization.Users;

    public class ExternalAuthenticateModel
    {
        [Required]
        [StringLength(UserLogin.MaxLoginProviderLength)]
        public string AuthProvider { get; set; }

        [Required]
        public string ProviderAccessCode { get; set; }

        [Required]
        [StringLength(UserLogin.MaxProviderKeyLength)]
        public string ProviderKey { get; set; }
    }
}