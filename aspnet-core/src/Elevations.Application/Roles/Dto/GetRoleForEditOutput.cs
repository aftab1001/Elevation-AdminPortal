namespace Elevations.Roles.Dto
{
    using System.Collections.Generic;

    public class GetRoleForEditOutput
    {
        public List<string> GrantedPermissionNames { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public RoleEditDto Role { get; set; }
    }
}