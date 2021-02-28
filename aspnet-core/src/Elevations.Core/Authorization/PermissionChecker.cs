using Abp.Authorization;
using Elevations.Authorization.Roles;
using Elevations.Authorization.Users;

namespace Elevations.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
