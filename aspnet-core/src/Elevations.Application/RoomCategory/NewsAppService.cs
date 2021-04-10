namespace Elevations.RoomCategory
{
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    //[AbpAuthorize(PermissionNames.Pages_News)]
    [AbpAllowAnonymous]
    public class NewsAppService : AsyncCrudAppService<News, NewsDto, int, PagedRoleResultRequestDto
        , UpdateNewsDto, NewsDto>

    {
        private readonly IRepository<News> newsRepo;

        public NewsAppService(IRepository<News, int> repository, IRepository<News> newsRepo)
            : base(repository)
        {
            this.newsRepo = newsRepo;
        }

        public override async Task<NewsDto> CreateAsync(UpdateNewsDto input)
        {
            CheckCreatePermission();

            News news = new()
                            {
                                Date = input.Date, Description1 = input.Description1, Description2 = input.Description2,
                                Description3 = input.Description3, Description4 = input.Description4,
                                Description5 = input.Description5, Image1 = input.Image1, Image2 = input.Image2,
                                Image3 = input.Image3, Image4 = input.Image4, Image5 = input.Image5,
                                ImageSequence = input.ImageSequence, Name = input.Name, Title = input.Title
                            };

            await newsRepo.InsertAsync(news);

            return MapToEntityDto(news);
        }

        public override async Task<NewsDto> UpdateAsync(NewsDto input)
        {
            CheckUpdatePermission();

            News news = new()
                            {
                                Id = input.Id, Date = input.Date, Description1 = input.Description1,
                                Description2 = input.Description2, Description3 = input.Description3,
                                Description4 = input.Description4, Description5 = input.Description5,
                                Image1 = input.Image1, Image2 = input.Image2, Image3 = input.Image3,
                                Image4 = input.Image4, Image5 = input.Image5, ImageSequence = input.ImageSequence,
                                Name = input.Name, Title = input.Title
                            };

            await newsRepo.UpdateAsync(news);

            return MapToEntityDto(news);
        }
    }
}