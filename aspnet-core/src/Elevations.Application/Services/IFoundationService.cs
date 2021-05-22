namespace Elevations.Services
{
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    using Elevations.Services.Dto;

    public interface IFoundationService : IAsyncCrudAppService<FoundationDto, int, PagedResultRequestDto,
        UpdateFoundationDto, FoundationDto>
    {
        public Task<PagedResultDto<FoundationDto>> GetAllGalleryImages();
    }
}