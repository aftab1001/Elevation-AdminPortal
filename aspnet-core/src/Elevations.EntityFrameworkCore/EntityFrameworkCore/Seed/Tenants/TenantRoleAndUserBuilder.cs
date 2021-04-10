﻿namespace Elevations.EntityFrameworkCore.Seed.Tenants
{
    using System.Collections.Generic;
    using System.Linq;

    using Abp.Authorization;
    using Abp.Authorization.Roles;
    using Abp.Authorization.Users;
    using Abp.MultiTenancy;

    using Elevations.Authorization;
    using Elevations.Authorization.Roles;
    using Elevations.Authorization.Users;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class TenantRoleAndUserBuilder
    {
        private readonly ElevationsDbContext _context;

        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(ElevationsDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // Admin role

            Role? adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(
                r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(
                    new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin)
                        {
                            IsStatic = true
                        }).Entity;
                _context.SaveChanges();
            }

            // Grant all permissions to admin role

            List<string> grantedPermissions = _context.Permissions.IgnoreQueryFilters().OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == _tenantId && p.RoleId == adminRole.Id).Select(p => p.Name).ToList();

            List<Permission> permissions = PermissionFinder.GetAllPermissions(new ElevationsAuthorizationProvider())
                .Where(
                    p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) && !grantedPermissions.Contains(p.Name))
                .ToList();

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(
                        permission => new RolePermissionSetting
                                          {
                                              TenantId = _tenantId, Name = permission.Name, IsGranted = true,
                                              RoleId = adminRole.Id
                                          }));
                _context.SaveChanges();
            }

            // Admin user

            User? adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(
                u => u.TenantId == _tenantId && u.UserName == AbpUserBase.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com");
                adminUser.Password =
                    new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions()))
                        .HashPassword(adminUser, "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }
        }
    }
}