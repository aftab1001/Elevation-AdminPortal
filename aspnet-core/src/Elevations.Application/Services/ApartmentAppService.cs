namespace Elevations.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.Domain.Uow;

    using Castle.Components.DictionaryAdapter;

    using Elevations.Authorization;
    using Elevations.EntityFrameworkCore;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.Services.Dto;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    [AbpAuthorize(PermissionNames.Pages_Apartments)]
    public class ApartmentAppService :
        AsyncCrudAppService<Apartments, ApartmentDto, int, PagedRoleResultRequestDto, UpdateApartmentDto, ApartmentDto>,
        IApartmentService
    {
        private readonly IRepository<ApartmentCategory> apartmentCategoryRepository;

        private readonly IRepository<Apartments> apartmentRepository;
        private readonly IConfiguration configuration;
        private  ElevationsDbContext context;

        public ApartmentAppService(
            IRepository<Apartments> apartmentRepository,
            IRepository<ApartmentCategory> apartmentCategoryRepository, 
            IConfiguration configuration)
            : base(apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
            this.apartmentCategoryRepository = apartmentCategoryRepository;
            this.configuration = configuration;
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
        [UnitOfWork]
        public Task<ListResultDto<ApartmentDto>> GetAllApartment()
        {
            //ABP framework is taking too much time to load data.That's why doing some dirty stuff
            //to manually create a dbcontext and getting data from that context.
            var connectionString = configuration.GetConnectionString("Default");
            var optionsBuilder = new DbContextOptionsBuilder<ElevationsDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

     context = new ElevationsDbContext(optionsBuilder.Options);
     context.ChangeTracker.AutoDetectChangesEnabled = false;       
     List<Apartments> lstApartmentDto = context.Apartments.Include(x=>x.Category).ToListAsync().Result;

     foreach (var item in lstApartmentDto)
     {
         item.CategoryName = item.Category.Name;

     }

     //       var query = from apartment in apartmentRepository.GetAll().AsNoTracking()
               
     //               select new ApartmentDto
     //               {
     //                              Id = apartment.Id,
     //               Description = apartment.Description,
     //               Bed = apartment.Bed,
     //               CategoryName = apartment.CategoryName,
     //               CityFee = apartment.CityFee,
     //               CleaningFee = apartment.CleaningFee,
     //               Facilities = apartment.Facilities,
     //               Features = apartment.Features,
     
     //       Image1 = apartment.Image1,
 
       
     //       Bath = apartment.Bath,
       
     //       ImageSequence=apartment.ImageSequence,
     //       Length=apartment.Length,
     //       MaxNumberOfDays  = apartment.MaxNumberOfDays,
     //       WeeklyPlan = apartment.WeeklyPlan,
     //       WeekendPlan = apartment.WeekendPlan,
     //       Price = apartment.Price,
     //       MonthlyPlan = apartment.MonthlyPlan,
     //       NightlyPlan = apartment.NightlyPlan
     //               };
     //       var result =     query.ToListAsync().Result;

            // List<Apartments> apartments = apartmentRepository.GetAllIncluding(x => x.Category).AsNoTracking().ToList();
            


                               //    foreach (Apartments apartment in apartments)
                               //    {
                               //    ApartmentDto apartmentDto = new ApartmentDto();
                               //    apartmentDto.Description = apartment.Description;
                               //    apartmentDto.Bed = apartment.Bed;
                               //    apartmentDto.CategoryName = apartment.CategoryName;
                               //    apartmentDto.CityFee = apartment.CityFee;
                               //    apartmentDto.CleaningFee = apartment.CleaningFee;
                               //    apartmentDto.Facilities = apartment.Facilities;
                               //    apartmentDto.Features = apartment.Features;
                               //    apartmentDto.Image1 = apartment.Image1;
                               //    apartmentDto.Image2= apartment.Image2;
                               //    apartmentDto.Features = apartment.Features;
                               //    apartmentDto.Bath = apartment.Bath;
                               //    apartmentDto.CityFee = apartment.CityFee;
                               //    apartmentDto.Image3 = apartment.Image3;
                               //    apartmentDto.Image4 = apartment.Image4;
                               //    apartmentDto.Image5 = apartment.Image5;
                               //    apartmentDto.ImageSequence = apartment.ImageSequence;
                               //    apartmentDto.Length = apartment.Length;
                               //    apartmentDto.MaxNumberOfDays = apartmentDto.MaxNumberOfDays;
                               //    apartmentDto.WeeklyPlan = apartmentDto.WeeklyPlan;
                               //    apartmentDto.WeekendPlan = apartmentDto.WeekendPlan;
                               //    apartmentDto.Price = apartmentDto.Price;
                               //    apartmentDto.Id = apartmentDto.Id;
                               //    apartmentDto.MonthlyPlan = apartmentDto.MonthlyPlan;
                               //    apartmentDto.NightlyPlan = apartmentDto.NightlyPlan;

                               //    lstApartmentDto.Add(apartmentDto);

                               //}

            context.Dispose();
            return Task.FromResult(new ListResultDto<ApartmentDto>(ObjectMapper.Map<List<ApartmentDto>>(lstApartmentDto)));
            //return Task.FromResult(
            //    new ListResultDto<ApartmentDto>(
            //        ObjectMapper.Map<List<ApartmentDto>>(apartments).OrderBy(p => p.Name).ToList()));
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