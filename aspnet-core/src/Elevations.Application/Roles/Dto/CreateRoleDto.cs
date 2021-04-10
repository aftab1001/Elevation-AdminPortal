namespace Elevations.Roles.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Abp.Authorization.Roles;

    using Elevations.Authorization.Roles;

    public class CreateRoleDto
    {
        public CreateRoleDto()
        {
            GrantedPermissions = new List<string>();
        }

        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public List<string> GrantedPermissions { get; set; }

        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}