﻿namespace Elevations.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp;
    using Abp.Authorization.Users;
    using Abp.Events.Bus;
    using Abp.Events.Bus.Entities;
    using Abp.MultiTenancy;
    using Abp.Runtime.Session;
    using Abp.TestBase;

    using Elevations.Authorization.Users;
    using Elevations.EntityFrameworkCore;
    using Elevations.EntityFrameworkCore.Seed.Host;
    using Elevations.EntityFrameworkCore.Seed.Tenants;
    using Elevations.MultiTenancy;

    using Microsoft.EntityFrameworkCore;

    public abstract class ElevationsTestBase : AbpIntegratedTestBase<ElevationsTestModule>
    {
        protected ElevationsTestBase()
        {
            void NormalizeDbContext(ElevationsDbContext context)
            {
                context.EntityChangeEventHelper = NullEntityChangeEventHelper.Instance;
                context.EventBus = NullEventBus.Instance;
                context.SuppressAutoSetTenantId = true;
            }

            // Seed initial data for host
            AbpSession.TenantId = null;
            UsingDbContext(
                context =>
                    {
                        NormalizeDbContext(context);
                        new InitialHostDbBuilder(context).Create();
                        new DefaultTenantBuilder(context).Create();
                    });

            // Seed initial data for default tenant
            AbpSession.TenantId = 1;
            UsingDbContext(
                context =>
                    {
                        NormalizeDbContext(context);
                        new TenantRoleAndUserBuilder(context, 1).Create();
                    });

            LoginAsDefaultTenantAdmin();
        }

        /// <summary>
        ///     Gets current tenant if <see cref="IAbpSession.TenantId" /> is not null.
        ///     Throws exception if there is no current tenant.
        /// </summary>
        protected async Task<Tenant> GetCurrentTenantAsync()
        {
            int tenantId = AbpSession.GetTenantId();
            return await UsingDbContext(context => context.Tenants.SingleAsync(t => t.Id == tenantId));
        }

        /// <summary>
        ///     Gets current user if <see cref="IAbpSession.UserId" /> is not null.
        ///     Throws exception if it's null.
        /// </summary>
        protected async Task<User> GetCurrentUserAsync()
        {
            long userId = AbpSession.GetUserId();
            return await UsingDbContext(context => context.Users.SingleAsync(u => u.Id == userId));
        }

        #region UsingDbContext

        protected IDisposable UsingTenantId(int? tenantId)
        {
            int? previousTenantId = AbpSession.TenantId;
            AbpSession.TenantId = tenantId;
            return new DisposeAction(() => AbpSession.TenantId = previousTenantId);
        }

        protected void UsingDbContext(Action<ElevationsDbContext> action)
        {
            UsingDbContext(AbpSession.TenantId, action);
        }

        protected Task UsingDbContextAsync(Func<ElevationsDbContext, Task> action)
        {
            return UsingDbContextAsync(AbpSession.TenantId, action);
        }

        protected T UsingDbContext<T>(Func<ElevationsDbContext, T> func)
        {
            return UsingDbContext(AbpSession.TenantId, func);
        }

        protected Task<T> UsingDbContextAsync<T>(Func<ElevationsDbContext, Task<T>> func)
        {
            return UsingDbContextAsync(AbpSession.TenantId, func);
        }

        protected void UsingDbContext(int? tenantId, Action<ElevationsDbContext> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (ElevationsDbContext context = LocalIocManager.Resolve<ElevationsDbContext>())
                {
                    action(context);
                    context.SaveChanges();
                }
            }
        }

        protected async Task UsingDbContextAsync(int? tenantId, Func<ElevationsDbContext, Task> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (ElevationsDbContext context = LocalIocManager.Resolve<ElevationsDbContext>())
                {
                    await action(context);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected T UsingDbContext<T>(int? tenantId, Func<ElevationsDbContext, T> func)
        {
            T result;

            using (UsingTenantId(tenantId))
            {
                using (ElevationsDbContext context = LocalIocManager.Resolve<ElevationsDbContext>())
                {
                    result = func(context);
                    context.SaveChanges();
                }
            }

            return result;
        }

        protected async Task<T> UsingDbContextAsync<T>(int? tenantId, Func<ElevationsDbContext, Task<T>> func)
        {
            T result;

            using (UsingTenantId(tenantId))
            {
                using (ElevationsDbContext context = LocalIocManager.Resolve<ElevationsDbContext>())
                {
                    result = await func(context);
                    await context.SaveChangesAsync();
                }
            }

            return result;
        }

        #endregion

        #region Login

        protected void LoginAsHostAdmin()
        {
            LoginAsHost(AbpUserBase.AdminUserName);
        }

        protected void LoginAsDefaultTenantAdmin()
        {
            LoginAsTenant(AbpTenantBase.DefaultTenantName, AbpUserBase.AdminUserName);
        }

        protected void LoginAsHost(string userName)
        {
            AbpSession.TenantId = null;

            User? user = UsingDbContext(
                context => context.Users.FirstOrDefault(
                    u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for host.");
            }

            AbpSession.UserId = user.Id;
        }

        protected void LoginAsTenant(string tenancyName, string userName)
        {
            Tenant? tenant =
                UsingDbContext(context => context.Tenants.FirstOrDefault(t => t.TenancyName == tenancyName));
            if (tenant == null)
            {
                throw new Exception("There is no tenant: " + tenancyName);
            }

            AbpSession.TenantId = tenant.Id;

            User? user = UsingDbContext(
                context => context.Users.FirstOrDefault(
                    u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for tenant: " + tenancyName);
            }

            AbpSession.UserId = user.Id;
        }

        #endregion
    }
}