using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Elevations.EntityFrameworkCore.HotelDto;
using Elevations.Services.Dto;
using Elevations.Services.Enum;
using Microsoft.AspNetCore.Authorization;

namespace Elevations.Services
{
    public class GalleryAppService : AsyncCrudAppService<Gallery, GalleryDto, int, PagedResultRequestDto,
            UpdateGalleryDto, GalleryDto>,
        IGalleryService
    {
        private readonly IRepository<Apartments> _apartmentRepository;
        private readonly IRepository<Gallery> _galleryRepository;

        private readonly IRepository<Rooms> _roomsRepository;

        public GalleryAppService(IRepository<Gallery, int> repository, IRepository<Gallery> galleryRepository,
            IRepository<Rooms> roomsRepository, IRepository<Apartments> apartmentRepository)
            : base(repository)
        {
            _galleryRepository = galleryRepository;
            _roomsRepository = roomsRepository;
            _apartmentRepository = apartmentRepository;
        }

        public override async Task<GalleryDto> CreateAsync(UpdateGalleryDto input)
        {
            CheckUpdatePermission();
            Gallery gallery = new()
            {
                Image = input.Image,
                ImageTitle = input.ImageTitle,
                ImageType = input.Type
            };
            var insertedId = await _galleryRepository.InsertAndGetIdAsync(gallery);
            input.Id = insertedId;
            return MapToEntityDto(gallery);
        }

        [AllowAnonymous]
        public override Task<PagedResultDto<GalleryDto>> GetAllAsync(PagedResultRequestDto input)
        {
            return Task.FromResult(GetImageDetail());
        }


        public override async Task<GalleryDto> UpdateAsync(GalleryDto input)
        {
            CheckUpdatePermission();

            Gallery gallery = new()
            {
                Image = input.Image,
                ImageTitle = input.ImageTitle,
                ImageType = input.Type
            };


            await _galleryRepository.UpdateAsync(gallery);

            return MapToEntityDto(gallery);
        }

        [AllowAnonymous]
        public async Task<PagedResultDto<GalleryDto>> GetAllGalleryImages()
        {
            var apartments = _apartmentRepository.GetAllIncluding(x => x.Category);

            foreach (var apartment in apartments) apartment.CategoryName = apartment.Category.Name;

            return await Task.FromResult(GetGalleryImages());
        }

        public PagedResultDto<GalleryDto> GetGalleryImages()
        {
            var galleryList = _galleryRepository.GetAll();

            var galleryImages = new List<GalleryDto>();


            foreach (var gallery in galleryList) AddGalleryImages(gallery, galleryImages);

            return new PagedResultDto<GalleryDto>(galleryImages.Count,
                new ReadOnlyCollection<GalleryDto>(galleryImages.ToList()));
        }

        public PagedResultDto<GalleryDto> GetImageDetail()
        {
            var roomsList = _roomsRepository.GetAll().ToList();
            var apartmentList = _apartmentRepository.GetAll();
            var galleryList = _galleryRepository.GetAll();

            var galleryImages = new List<GalleryDto>();

            foreach (var room in roomsList) AddRooms(room, galleryImages);

            foreach (var room in apartmentList) AddApartment(room, galleryImages);

            foreach (var gallery in galleryList) AddGalleryImages(gallery, galleryImages);

            return new PagedResultDto<GalleryDto>(galleryImages.Count,
                new ReadOnlyCollection<GalleryDto>(galleryImages.ToList()));
        }

        private void AddGalleryImages(Gallery gallery, List<GalleryDto> galleryList)
        {
            if (!string.IsNullOrEmpty(gallery.Image))
            {
                var item = new GalleryDto
                {
                    Image = gallery.Image,
                    ImageTitle = gallery.ImageTitle,
                    Type = gallery.ImageType,
                    Id = gallery.Id
                };

                galleryList.Add(item);
            }
        }

        private void AddApartment(Apartments apartment, List<GalleryDto> galleryImages)
        {
            if (!string.IsNullOrEmpty(apartment.Image1))
            {
                var item = new GalleryDto
                {
                    Image = apartment.Image1, ImageTitle = apartment.Name, Type = ImageType.Apartments.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image2))
            {
                var item = new GalleryDto
                {
                    Image = apartment.Image2, ImageTitle = apartment.Name, Type = ImageType.Apartments.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image3))
            {
                var item = new GalleryDto
                {
                    Image = apartment.Image3, ImageTitle = apartment.Name, Type = ImageType.Apartments.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image4))
            {
                var item = new GalleryDto
                {
                    Image = apartment.Image4, ImageTitle = apartment.Name, Type = ImageType.Apartments.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image5))
            {
                var item = new GalleryDto
                {
                    Image = apartment.Image5, ImageTitle = apartment.Name, Type = ImageType.Apartments.ToString()
                };

                galleryImages.Add(item);
            }
        }

        private void AddRooms(Rooms room, List<GalleryDto> galleryImages)
        {
            if (!string.IsNullOrEmpty(room.Image1))
            {
                var item = new GalleryDto
                {
                    Image = room.Image1, ImageTitle = room.Name, Type = ImageType.Rooms.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image2))
            {
                var item = new GalleryDto
                {
                    Image = room.Image2, ImageTitle = room.Name, Type = ImageType.Rooms.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image3))
            {
                var item = new GalleryDto
                {
                    Image = room.Image3, ImageTitle = room.Name, Type = ImageType.Rooms.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image4))
            {
                var item = new GalleryDto
                {
                    Image = room.Image4, ImageTitle = room.Name, Type = ImageType.Rooms.ToString()
                };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image5))
            {
                var item = new GalleryDto
                {
                    Image = room.Image5, ImageTitle = room.Name, Type = ImageType.Rooms.ToString()
                };

                galleryImages.Add(item);
            }
        }
    }
}