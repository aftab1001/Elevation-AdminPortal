namespace Elevations.EntityFrameworkCore.Seed.Host
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Elevations.EntityFrameworkCore.HotelDto;

    using Microsoft.EntityFrameworkCore;

    public class DefaultApartmentCategoryBuilder
    {
        private readonly ElevationsDbContext _context;

        public DefaultApartmentCategoryBuilder(ElevationsDbContext context)
        {
            _context = context;
        }

        public static List<ApartmentCategory> ApartmentCategories
        {
            get
            {
                return GetInitialCategories();
            }
        }

        public void Create()
        {
            CreateRoomCategories();
        }

        private static List<ApartmentCategory> GetInitialCategories()
        {
            return new()
                       {
                           new ApartmentCategory { CreationTime = DateTime.Now, Name = "Guest House" },
                           new ApartmentCategory { Name = "Meeting Room", CreationTime = DateTime.Now }
                       };
        }

        private void AddApartmentCatIfNotExists(ApartmentCategory category)
        {
            if (_context.ApartmentCategory.IgnoreQueryFilters().Any(l => l.Name == category.Name))
            {
                return;
            }

            _context.ApartmentCategory.Add(category);
            _context.SaveChanges();
        }

        private void CreateRoomCategories()
        {
            foreach (ApartmentCategory category in ApartmentCategories)
            {
                AddApartmentCatIfNotExists(category);
            }
        }
    }
}