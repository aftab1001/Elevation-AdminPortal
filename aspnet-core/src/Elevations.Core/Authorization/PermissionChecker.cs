namespace Elevations.Authorization
{
    using Abp.Authorization;

    using Elevations.Authorization.Roles;
    using Elevations.Authorization.Users;

    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}