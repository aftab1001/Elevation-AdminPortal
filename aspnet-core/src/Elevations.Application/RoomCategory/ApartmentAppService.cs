namespace Elevations.RoomCategory
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.Authorization;
    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.RoomCategory.Dto;

     [AbpAuthorize(PermissionNames.Pages_Apartments)]
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

            Apartments apartments = new Apartments
                                        {
                                            Category = input.ApartmentCategory, Image = input.Image, Name = input.Name,
                                            Bath = input.Bath, Bed = input.Bed, Description = input.Description
                                        };
            apartments.Name = input.Name;
            apartments.ImageSequence = input.ImageSequence;
            apartments.Length = input.Length;
            apartments.Price = input.Price;
            apartments.Id = input.Id;

            await apartmentRepository.UpdateAsync(apartments);

            return MapToEntityDto(apartments);
        }
    }
}