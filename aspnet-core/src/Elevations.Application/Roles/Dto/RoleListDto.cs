namespace Elevations.Roles.Dto
{
    using System;

    using Abp.Application.Services.Dto;
    using Abp.Domain.Entities.Auditing;

    public class RoleListDto : EntityDto, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }

        public bool IsStatic { get; set; }

        public string Name { get; set; }
    }
}