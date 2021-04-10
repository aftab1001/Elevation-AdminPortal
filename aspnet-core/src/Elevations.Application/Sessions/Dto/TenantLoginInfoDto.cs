namespace Elevations.Sessions.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.MultiTenancy;

    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string Name { get; set; }

        public string TenancyName { get; set; }
    }
}