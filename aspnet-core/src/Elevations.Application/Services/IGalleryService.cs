using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Elevations.EntityFrameworkCore.HotelDto;
using Elevations.Roles.Dto;
using Elevations.Services.Dto;

namespace Elevations.Services
{
    public interface IGalleryService: IAsyncCrudAppService<GalleryDto, int, PagedResultRequestDto, Gallery,
        GalleryDto>
    {
        Task<ListResultDto<GalleryDto>> GetAllGalleryImages(PagedResultRequestDto input);
    }
}