namespace Elevations.MultiTenancy
{
    using Abp.MultiTenancy;

    using Elevations.Authorization.Users;

    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}