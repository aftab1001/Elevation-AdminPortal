namespace Elevations.Authorization.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Authorization.Users;
    using Abp.Domain.Services;
    using Abp.IdentityFramework;
    using Abp.Runtime.Session;
    using Abp.UI;

    using Elevations.Authorization.Roles;
    using Elevations.MultiTenancy;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UserRegistrationManager : DomainService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        private readonly RoleManager _roleManager;

        private readonly TenantManager _tenantManager;

        private readonly UserManager _userManager;

        public UserRegistrationManager(
            TenantManager tenantManager,
            UserManager userManager,
            RoleManager roleManager,
            IPasswordHasher<User> passwordHasher)
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;

            AbpSession = NullAbpSession.Instance;
        }

        public IAbpSession AbpSession { get; set; }

        public async Task<User> RegisterAsync(
            string name,
            string surname,
            string emailAddress,
            string userName,
            string plainPassword,
            bool isEmailConfirmed)
        {
            CheckForTenant();

            Tenant tenant = await GetActiveTenantAsync();

            User user = new User
                            {
                                TenantId = tenant.Id, Name = name, Surname = surname, EmailAddress = emailAddress,
                                IsActive = true, UserName = userName, IsEmailConfirmed = isEmailConfirmed,
                                Roles = new List<UserRole>()
                            };

            user.SetNormalizedNames();

            foreach (Role defaultRole in await _roleManager.Roles.Where(r => r.IsDefault).ToListAsync())
            {
                user.Roles.Add(new UserRole(tenant.Id, user.Id, defaultRole.Id));
            }

            await _userManager.InitializeOptionsAsync(tenant.Id);

            CheckErrors(await _userManager.CreateAsync(user, plainPassword));
            await CurrentUnitOfWork.SaveChangesAsync();

            return user;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        private void CheckForTenant()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                throw new InvalidOperationException("Can not register host users!");
            }
        }

        private async Task<Tenant> GetActiveTenantAsync()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return await GetActiveTenantAsync(AbpSession.TenantId.Value);
        }

        private async Task<Tenant> GetActiveTenantAsync(int tenantId)
        {
            Tenant tenant = await _tenantManager.FindByIdAsync(tenantId);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("UnknownTenantId{0}", tenantId));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIdIsNotActive{0}", tenantId));
            }

            return tenant;
        }
    }
}