namespace Elevations.RoomCategory
{
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    public interface
        IApartmentService : IAsyncCrudAppService<ApartmentDto, int, PagedRoleResultRequestDto, UpdateApartmentDto, ApartmentDto>
    {
        Task<ListResultDto<ApartmentDto>> GetAllApartment();
        
    }
}