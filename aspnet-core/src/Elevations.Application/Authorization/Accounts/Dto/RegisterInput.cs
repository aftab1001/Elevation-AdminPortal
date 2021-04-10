namespace Elevations.Authorization.Accounts.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Abp.Auditing;
    using Abp.Authorization.Users;
    using Abp.Extensions;

    using Elevations.Validation;

    public class RegisterInput : IValidatableObject
    {
        [DisableAuditing]
        public string CaptchaResponse { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!UserName.IsNullOrEmpty())
            {
                if (!UserName.Equals(EmailAddress) && ValidationHelper.IsEmail(UserName))
                {
                    yield return new ValidationResult(
                        "Username cannot be an email address unless it's the same as your email address!");
                }
            }
        }
    }
}