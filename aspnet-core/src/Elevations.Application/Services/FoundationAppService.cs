namespace Elevations.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Domain.Repositories;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Services.Dto;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;

    public class FoundationAppService :
        AsyncCrudAppService<Foundation, FoundationDto, int, PagedResultRequestDto, UpdateFoundationDto, FoundationDto>,
        IFoundationService
    {
        public FoundationAppService(IRepository<Foundation, int> repository)
            : base(repository)
        {
        }

        public override async Task<FoundationDto> CreateAsync(UpdateFoundationDto input)
        {
            CheckUpdatePermission();

            Foundation foundation = new()
                                        {
                                            Description = input.Description, CreationTime = DateTime.Now,
                                            HeadingText = input.HeadingText, Image = input.Image, Type = input.Type,
                                            UpperText = input.UpperText
                                        };
            int insertedId = await Repository.InsertAndGetIdAsync(foundation);
            input.Id = insertedId;
            return MapToEntityDto(foundation);
        }

        [AllowAnonymous]
        public override Task<PagedResultDto<FoundationDto>> GetAllAsync(PagedResultRequestDto input)
        {
            return Task.FromResult(GetFoundationImageDetail());
        }

        public async Task<PagedResultDto<FoundationDto>> GetAllGalleryImages()
        {
            return await Task.FromResult(GetFoundationImageDetail());
        }

        public override async Task<FoundationDto> UpdateAsync(FoundationDto input)
        {
            CheckUpdatePermission();

            Foundation foundation = new()
                                        {
                                            Description = input.Description, CreationTime = DateTime.Now,
                                            HeadingText = input.HeadingText, Id = input.Id, Image = input.Image,
                                            Type = input.Type, UpperText = input.UpperText
                                        };

            await Repository.UpdateAsync(foundation);

            return MapToEntityDto(foundation);
        }

        protected override async Task<Foundation> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        private PagedResultDto<FoundationDto> GetFoundationImageDetail()
        {
            List<Foundation> foundationsList = Repository.GetAll().ToList();

            List<FoundationDto> foundationDtoList = new();

            foreach (Foundation item in foundationsList)
            {
                FoundationDto foundationDto = new();
                foundationDto.UpperText = item.UpperText;
                foundationDto.Description = item.Description;
                foundationDto.HeadingText = item.HeadingText;
                foundationDto.Image = item.Image;
                foundationDto.Type = item.Type;
                foundationDto.Id = item.Id;

                foundationDtoList.Add(foundationDto);
            }

            return new PagedResultDto<FoundationDto>(
                foundationsList.Count,
                new ReadOnlyCollection<FoundationDto>(foundationDtoList));
        }
    }
}