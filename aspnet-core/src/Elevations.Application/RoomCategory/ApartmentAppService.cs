namespace Elevations.RoomCategory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Migrations;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

    //[AbpAuthorize(PermissionNames.Pages_Apartments)]
    [AbpAllowAnonymous]
    public class ApartmentAppService :
        AsyncCrudAppService<Apartments, ApartmentDto, int, PagedRoleResultRequestDto, UpdateApartmentDto, ApartmentDto>,
        IApartmentService
    {
        private readonly IRepository<Apartments> apartmentRepository;

        public ApartmentAppService(IRepository<Apartments> apartmentRepository)
            : base(apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
        }

        public override async Task<ApartmentDto> CreateAsync(UpdateApartmentDto input)
        {
            CheckCreatePermission();

            Apartments apartments = new()
                                        {
                                            Category = input.ApartmentCategory, Image1 = input.Image, Name = input.Name,
                                            Bath = input.Bath, Bed = input.Bed, Description = input.Description
                                        };

            
            apartments.Name = input.Name;
            apartments.ImageSequence = input.ImageSequence;
            apartments.Length = input.Length;
            apartments.Price = input.Price;
            apartments.Category = new ApartmentCategory
                                      {
                                          Name = input.ApartmentCategory.Name, CreationTime = DateTime.Now
                                      };


            await apartmentRepository.InsertAsync(apartments);

            return MapToEntityDto(apartments);
        }

        [AbpAllowAnonymous]
        public Task<ListResultDto<ApartmentDto>> GetAllApartment()
        {
            IQueryable<Apartments> roomsList = apartmentRepository.GetAll();

            return Task.FromResult(
                new ListResultDto<ApartmentDto>(
                    ObjectMapper.Map<List<ApartmentDto>>(roomsList).OrderBy(p => p.Name).ToList()));
        }

        public override async Task<ApartmentDto> UpdateAsync(ApartmentDto input)
        {
            CheckUpdatePermission();

            Apartments apartments = new()
                                        {
                                            Category = input.ApartmentCategory, Image1 = input.Image1,
                                            Name = input.Name, Bath = input.Bath, Bed = input.Bed,
                                            Description = input.Description
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

            await apartmentRepository.UpdateAsync(apartments);

            return MapToEntityDto(apartments);
        }
    }
}