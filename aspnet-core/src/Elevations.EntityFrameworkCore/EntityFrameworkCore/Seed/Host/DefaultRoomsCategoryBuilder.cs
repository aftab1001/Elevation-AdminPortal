namespace Elevations.EntityFrameworkCore.Seed.Host
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Elevations.EntityFrameworkCore.HotelDto;

    using Microsoft.EntityFrameworkCore;

    public class DefaultRoomsCategoryBuilder
    {
        private readonly ElevationsDbContext _context;

        public DefaultRoomsCategoryBuilder(ElevationsDbContext context)
        {
            _context = context;
        }

        public static List<RoomsCategory> InitialLanguages
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

        private static List<RoomsCategory> GetInitialCategories()
        {
            return new()
                       {
                           new RoomsCategory() { CreationTime = DateTime.Now, Name = "Guest House" },
                           new RoomsCategory() { Name = "Meeting Room", CreationTime = DateTime.Now }
                       };
        }

        private void AddRoomCatIfNotExists(RoomsCategory category)
        {
            if (_context.RoomsCategory.IgnoreQueryFilters().Any(l => l.Id == category.Id))
            {
                return;
            }

            _context.RoomsCategory.Add(category);
            _context.SaveChanges();
        }

        private void CreateRoomCategories()
        {
            foreach (RoomsCategory language in InitialLanguages)
            {
                AddRoomCatIfNotExists(language);
            }
        }
    }
}