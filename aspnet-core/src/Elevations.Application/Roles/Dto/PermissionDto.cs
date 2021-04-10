namespace Elevations.Roles.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;

    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto<long>
    {
        public string Description { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }
    }
}