namespace Elevations.Roles.Dto
{
    using System.ComponentModel.DataAnnotations;

    using Abp.Application.Services.Dto;
    using Abp.Authorization.Roles;

    using Elevations.Authorization.Roles;

    public class RoleEditDto : EntityDto<int>
    {
        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public bool IsStatic { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }
    }
}