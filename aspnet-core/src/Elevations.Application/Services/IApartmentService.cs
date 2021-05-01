using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Elevations.Roles.Dto;
using Elevations.Services.Dto;

namespace Elevations.Services
{
    public interface IApartmentService : IAsyncCrudAppService<ApartmentDto, int, PagedRoleResultRequestDto,
        UpdateApartmentDto, ApartmentDto>
    {
        Task<ListResultDto<ApartmentDto>> GetAllApartment();
    }
}