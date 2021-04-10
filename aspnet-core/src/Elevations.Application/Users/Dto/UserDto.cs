namespace Elevations.Users.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.Application.Services.Dto;
    using Abp.Authorization.Users;
    using Abp.AutoMapper;

    using Elevations.Authorization.Users;

    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        public DateTime CreationTime { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        public string[] RoleNames { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }
    }
}