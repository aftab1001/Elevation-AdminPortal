namespace Elevations.Roles.Dto
{
    using System.Linq;

    using Abp.Authorization;
    using Abp.Authorization.Roles;

    using AutoMapper;

    using Elevations.Authorization.Roles;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Services.Dto;

    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            // Role and permission
            CreateMap<Permission, string>().ConvertUsing(r => r.Name);
            CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

            CreateMap<CreateRoleDto, Role>();

            CreateMap<RoleDto, Role>();

            CreateMap<Role, RoleDto>().ForMember(
                x => x.GrantedPermissions,
                opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

            CreateMap<Role, RoleListDto>();
            CreateMap<Role, RoleEditDto>();

            CreateMap<Role, RoleEditDto>();
            CreateMap<UpdateBookingDto, BookingDto>();

            CreateMap<Booking, BookingDto>();
            
            CreateMap<Permission, FlatPermissionDto>();
        }
    }
}