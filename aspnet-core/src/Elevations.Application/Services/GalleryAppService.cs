namespace Elevations.Services
{
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
    using Microsoft.EntityFrameworkCore;

    public class GalleryAppService : AsyncCrudAppService<Gallery, GalleryDto, int, PagedResultRequestDto,
                                         UpdateGalleryDto, GalleryDto>,
                                     IGalleryService
    {
        private readonly IRepository<Apartments> _apartmentRepository;

        private readonly IRepository<Gallery> _galleryRepository;

        private readonly IRepository<Rooms> _roomsRepository;

        public GalleryAppService(
            IRepository<Gallery, int> repository,
            IRepository<Gallery> galleryRepository,
            IRepository<Rooms> roomsRepository,
            IRepository<Apartments> apartmentRepository)
            : base(repository)
        {
            _galleryRepository = galleryRepository;
            _roomsRepository = roomsRepository;
            _apartmentRepository = apartmentRepository;
        }

        public override async Task<GalleryDto> CreateAsync(UpdateGalleryDto input)
        {
            CheckUpdatePermission();

            Gallery gallery = new() { Image = input.Image, ImageTitle = input.ImageTitle, ImageType = input.Type };
            int insertedId = await _galleryRepository.InsertAndGetIdAsync(gallery);
            input.Id = insertedId;
            return MapToEntityDto(gallery);
        }

        [AllowAnonymous]
        public override Task<PagedResultDto<GalleryDto>> GetAllAsync(PagedResultRequestDto input)
        {
            return Task.FromResult(GetImageDetail());
        }

        [AllowAnonymous]
        public async Task<PagedResultDto<GalleryDto>> GetAllGalleryImages()
        {
            IQueryable<Apartments> apartments = _apartmentRepository.GetAllIncluding(x => x.Category);

            foreach (Apartments apartment in apartments)
            {
                apartment.CategoryName = apartment.Category.Name;
            }

            return await Task.FromResult(GetGalleryImages());
        }

        public override async Task<GalleryDto> UpdateAsync(GalleryDto input)
        {
            CheckUpdatePermission();

            Gallery gallery = new()
                                  {
                                      Image = input.Image, ImageTitle = input.ImageTitle, ImageType = input.ImageType,
                                      Id = input.Id
                                  };

            await _galleryRepository.UpdateAsync(gallery);

            return MapToEntityDto(gallery);
        }

        protected override async Task<Gallery> GetEntityByIdAsync(int id)
        {
            return await _galleryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        private void AddApartment(Apartments apartment, List<GalleryDto> galleryImages)
        {
            if (!string.IsNullOrEmpty(apartment.Image1))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = apartment.Image1, ImageTitle = apartment.Name,
                                          ImageType = ImageType.Apartments.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image2))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = apartment.Image2, ImageTitle = apartment.Name,
                                          ImageType = ImageType.Apartments.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image3))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = apartment.Image3, ImageTitle = apartment.Name,
                                          ImageType = ImageType.Apartments.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image4))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = apartment.Image4, ImageTitle = apartment.Name,
                                          ImageType = ImageType.Apartments.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(apartment.Image5))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = apartment.Image5, ImageTitle = apartment.Name,
                                          ImageType = ImageType.Apartments.ToString()
                                      };

                galleryImages.Add(item);
            }
        }

        private void AddGalleryImages(Gallery gallery, List<GalleryDto> galleryList)
        {
            if (!string.IsNullOrEmpty(gallery.Image))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = gallery.Image, ImageTitle = gallery.ImageTitle,
                                          ImageType = gallery.ImageType, Id = gallery.Id
                                      };

                galleryList.Add(item);
            }
        }

        private void AddRooms(Rooms room, List<GalleryDto> galleryImages)
        {
            if (!string.IsNullOrEmpty(room.Image1))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = room.Image1, ImageTitle = room.Name,
                                          ImageType = ImageType.Rooms.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image2))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = room.Image2, ImageTitle = room.Name,
                                          ImageType = ImageType.Rooms.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image3))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = room.Image3, ImageTitle = room.Name,
                                          ImageType = ImageType.Rooms.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image4))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = room.Image4, ImageTitle = room.Name,
                                          ImageType = ImageType.Rooms.ToString()
                                      };

                galleryImages.Add(item);
            }

            if (!string.IsNullOrEmpty(room.Image5))
            {
                GalleryDto item = new GalleryDto
                                      {
                                          Image = room.Image5, ImageTitle = room.Name,
                                          ImageType = ImageType.Rooms.ToString()
                                      };

                galleryImages.Add(item);
            }
        }

        private PagedResultDto<GalleryDto> GetGalleryImages()
        {
            IQueryable<Gallery> galleryList = _galleryRepository.GetAll();

            List<GalleryDto> galleryImages = new List<GalleryDto>();

            foreach (Gallery gallery in galleryList)
            {
                AddGalleryImages(gallery, galleryImages);
            }

            return new PagedResultDto<GalleryDto>(
                galleryImages.Count,
                new ReadOnlyCollection<GalleryDto>(galleryImages.ToList()));
        }

        private PagedResultDto<GalleryDto> GetImageDetail()
        {
            List<Rooms> roomsList = _roomsRepository.GetAll().ToList();
            IQueryable<Apartments> apartmentList = _apartmentRepository.GetAll();
            IQueryable<Gallery> galleryList = _galleryRepository.GetAll();

            List<GalleryDto> galleryImages = new List<GalleryDto>();

            foreach (Rooms room in roomsList)
            {
                AddRooms(room, galleryImages);
            }

            foreach (Apartments room in apartmentList)
            {
                AddApartment(room, galleryImages);
            }

            foreach (Gallery gallery in galleryList)
            {
                AddGalleryImages(gallery, galleryImages);
            }

            return new PagedResultDto<GalleryDto>(
                galleryImages.Count,
                new ReadOnlyCollection<GalleryDto>(galleryImages.ToList()));
        }
    }
}