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

namespace Elevations.Services
{
    public class GalleryAppService : AsyncCrudAppService<Gallery, GalleryDto, int, PagedResultRequestDto, Gallery,
        GalleryDto>
    {
        private readonly IRepository<Apartments> apartmentRepository;
        private readonly IRepository<Gallery> galleryRepository;

        private readonly IRepository<Rooms> roomsRepository;

        public GalleryAppService(IRepository<Gallery, int> repository, IRepository<Gallery> galleryRepository,
            IRepository<Rooms> roomsRepository, IRepository<Apartments> apartmentRepository)
            : base(repository)
        {
            this.galleryRepository = galleryRepository;
            this.roomsRepository = roomsRepository;
            this.apartmentRepository = apartmentRepository;
        }

        public override async Task<GalleryDto> CreateAsync(Gallery input)
        {
            CheckUpdatePermission();


            var insertedId = await galleryRepository.InsertAndGetIdAsync(input);
            input.Id = insertedId;
            return MapToEntityDto(input);
        }

        public override Task<PagedResultDto<GalleryDto>> GetAllAsync(PagedResultRequestDto input)
        {
            return Task.FromResult(GetAllGalleryImages());
        }

        public Task<ListResultDto<GalleryDto>> GetAllGalleryImages(PagedResultRequestDto input)
        {
            var apartments = apartmentRepository.GetAllIncluding(x => x.Category);

            foreach (var apartment in apartments) apartment.CategoryName = apartment.Category.Name;
            return Task.FromResult(
                new ListResultDto<GalleryDto>(
                    ObjectMapper.Map<List<GalleryDto>>(apartments).OrderBy(p => p.Type).ToList()));
        }

        private PagedResultDto<GalleryDto> GetAllGalleryImages()
        {
            var roomsList = roomsRepository.GetAll().ToList();
            var apartmentList = apartmentRepository.GetAll();
            var galleryList = galleryRepository.GetAll();

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
                    Type = gallery.ImageType
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