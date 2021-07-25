namespace Elevations.Services
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.Authorization;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Services.Dto;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;

    [AbpAuthorize(PermissionNames.Pages_Restaurant)]
    public class RestaurantAppService : AsyncCrudAppService<Dishes, DishesDto, int, PagedResultRequestDto, DishesDto
        , DishesDto>

    {
        public RestaurantAppService(IRepository<Dishes, int> repository)
            : base(repository)
        {
        }

        public override async Task<DishesDto> CreateAsync(DishesDto input)
        {
            CheckUpdatePermission();
            Dishes dishes = ObjectMapper.Map<Dishes>(input);
            dishes.Category = (int)input.Category;
            int insertedId = await Repository.InsertAndGetIdAsync(dishes);
            input.Id = insertedId;
            return input;
        }

        [AbpAllowAnonymous]
        public override Task<PagedResultDto<DishesDto>> GetAllAsync(PagedResultRequestDto input)
        {
            List<Dishes> dishes = Repository.GetAllListAsync().Result;
            var dishesResponse = new List<DishesDto>();

            foreach (var dish in dishes)
            {
                var mappedDish = ObjectMapper.Map<DishesDto>(dish);
                mappedDish.Category = (DishCategory)dish.Category;
                dishesResponse.Add(mappedDish);
            }

            PagedResultDto<DishesDto> pagedResult = new PagedResultDto<DishesDto>(
                dishes.Count,
                new ReadOnlyCollection<DishesDto>(dishesResponse));

            return Task.FromResult(pagedResult);
        }

        public override async Task<DishesDto> UpdateAsync(DishesDto input)
        {
            CheckUpdatePermission();

            Dishes recordToUpdate = ObjectMapper.Map<Dishes>(input);
            recordToUpdate.Category = (int)input.Category;
            await Repository.UpdateAsync(recordToUpdate);

            return MapToEntityDto(recordToUpdate);
        }

        protected override async Task<Dishes> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}