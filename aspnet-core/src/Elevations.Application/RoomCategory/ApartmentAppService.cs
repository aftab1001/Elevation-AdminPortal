﻿namespace Elevations.RoomCategory
{
    using System;
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

        public Task<ListResultDto<ApartmentDto>> GetAllApartment()
        {
            IQueryable<Apartments> roomsList = apartmentRepository.GetAll();

            return Task.FromResult(
                new ListResultDto<ApartmentDto>(ObjectMapper.Map<List<ApartmentDto>>(roomsList).OrderBy(p => p.Name).ToList()));
        }

     
    }
}