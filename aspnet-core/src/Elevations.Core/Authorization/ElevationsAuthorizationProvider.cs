﻿namespace Elevations.Authorization
{
    using Abp.Authorization;
    using Abp.Localization;
    using Abp.MultiTenancy;

    public class ElevationsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(
                PermissionNames.Pages_Tenants,
                L("Tenants"),
                multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Rooms, L("Rooms"));
            context.CreatePermission(PermissionNames.Pages_Apartments, L("Apartments"));
            context.CreatePermission(PermissionNames.Pages_News, L("News"));
            context.CreatePermission(PermissionNames.Pages_Dashboard, L("Dashboard"));
            context.CreatePermission(PermissionNames.Pages_Reservation, L("Reservation"));
            context.CreatePermission(PermissionNames.Pages_Restaurant, L("Restaurant"));
            context.CreatePermission(PermissionNames.Pages_Gallery, L("Gallery"));
            context.CreatePermission(PermissionNames.Pages_Donation, L("Donation"));
            context.CreatePermission(PermissionNames.Pages_Booking, L("Booking"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ElevationsConsts.LocalizationSourceName);
        }
    }
}