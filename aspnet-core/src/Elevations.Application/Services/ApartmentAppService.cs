using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Elevations.EntityFrameworkCore.HotelDto;
using Elevations.Roles.Dto;
using Elevations.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace Elevations.Services
{
    //[AbpAuthorize(PermissionNames.Pages_Apartments)]
    [AbpAllowAnonymous]
    public class ApartmentAppService :
        AsyncCrudAppService<Apartments, ApartmentDto, int, PagedRoleResultRequestDto, UpdateApartmentDto, ApartmentDto>,
        IApartmentService
    {
        private readonly IRepository<ApartmentCategory> apartmentCategoryRepository;

        private readonly IRepository<Apartments> apartmentRepository;

        public ApartmentAppService(
            IRepository<Apartments> apartmentRepository,
            IRepository<ApartmentCategory> apartmentCategoryRepository)
            : base(apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
            this.apartmentCategoryRepository = apartmentCategoryRepository;
        }

        public override async Task<ApartmentDto> CreateAsync(UpdateApartmentDto input)
        {
            CheckCreatePermission();

            Apartments apartments = new()
                                        {
                                            Category = apartmentCategoryRepository.GetAll()
                                                .FirstOrDefault(x => x.Name == input.CategoryName),
                                            Image1 = string.IsNullOrEmpty(input.Image1) ? "" : input.Image1,
                                            Name = input.Name, Bath = input.Bath, Bed = input.Bed,
                                            Description =
                                                string.IsNullOrEmpty(input.Description)
                                                    ? "create apartment "
                                                    : input.Description
                                        };

            apartments.Name = input.Name;
            apartments.ImageSequence = input.ImageSequence;
            apartments.Length = input.Length;
            apartments.Price = input.Price;
            apartments.Description = input.Description;

            apartments.Features = input.Features;
            apartments.Facilities = input.Facilities;
            apartments.Facilities = input.Facilities;
            apartments.WeekendPlan = input.WeekendPlan;
            apartments.WeeklyPlan = input.WeeklyPlan;
            apartments.MonthlyPlan = input.MonthlyPlan;
            apartments.CleaningFee = input.CleaningFee;
            apartments.CityFee = input.CityFee;
            apartments.MaxNumberOfDays = input.MaxNumberOfDays;
            apartments.MinNumberOfDays = input.MinNumberOfDays;

            int insertedId = await apartmentRepository.InsertAndGetIdAsync(apartments);
            apartments.Id = insertedId;
            return MapToEntityDto(apartments);
        }

        [AbpAllowAnonymous]
        public Task<ListResultDto<ApartmentDto>> GetAllApartment()
        {
            IQueryable<Apartments> apartments = apartmentRepository.GetAllIncluding(x => x.Category);
            
            foreach (Apartments apartment in apartments)
            {
                apartment.CategoryName = apartment.Category.Name;

            }
            return Task.FromResult(
                new ListResultDto<ApartmentDto>(
                    ObjectMapper.Map<List<ApartmentDto>>(apartments).OrderBy(p => p.Name).ToList()));
        }

        public override async Task<ApartmentDto> UpdateAsync(ApartmentDto input)
        {
            CheckUpdatePermission();

            Apartments apartments = new()
                                        {
                                            Category = apartmentCategoryRepository.GetAll()
                                                .FirstOrDefault(x => x.Name == input.CategoryName),
                                            Image1 = input.Image1, Name = input.Name, Bath = input.Bath,
                                            Bed = input.Bed, Description = input.Description
                                        };
            apartments.Name = input.Name;
            apartments.Image2 = input.Image2;
            apartments.Image2 = input.Image3;
            apartments.Image4 = input.Image4;
            apartments.Image5 = input.Image5;

            apartments.ImageSequence = input.ImageSequence;
            apartments.Length = input.Length;
            apartments.Price = input.Price;
            apartments.Id = input.Id;
            apartments.Description = input.Description;

            apartments.Features = input.Features;
            apartments.Facilities = input.Facilities;
            apartments.Facilities = input.Facilities;
            apartments.WeekendPlan = input.WeekendPlan;
            apartments.WeeklyPlan = input.WeeklyPlan;
            apartments.MonthlyPlan = input.MonthlyPlan;
            apartments.CleaningFee = input.CleaningFee;
            apartments.CityFee = input.CityFee;
            apartments.MaxNumberOfDays = input.MaxNumberOfDays;
            apartments.MinNumberOfDays = input.MinNumberOfDays;

            await apartmentRepository.UpdateAsync(apartments);

            return MapToEntityDto(apartments);
        }

        protected override async Task<Apartments> GetEntityByIdAsync(int id)
        {
            Apartments filteredApartments = await apartmentRepository.GetAllIncluding(x => x.Category)
                                                .FirstOrDefaultAsync(x => x.Id == id);

            filteredApartments.CategoryName = filteredApartments.Category.Name;
            filteredApartments.CategoryId = filteredApartments.Category.Id;
            return filteredApartments;
        }
    }
}