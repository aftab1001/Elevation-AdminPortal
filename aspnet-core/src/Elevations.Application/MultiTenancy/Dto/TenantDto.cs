namespace Elevations.MultiTenancy.Dto
{
    using System.ComponentModel.DataAnnotations;

    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Abp.MultiTenancy;

    [AutoMapFrom(typeof(Tenant))]
    public class TenantDto : EntityDto
    {
        public bool IsActive { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }
    }
}