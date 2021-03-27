namespace Elevations.EntityFrameworkCore.Seed.Host
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Elevations.EntityFrameworkCore.HotelDto;

    using Microsoft.EntityFrameworkCore;

    public class NewsBuilder
    {
        private readonly ElevationsDbContext _context;

        public NewsBuilder(ElevationsDbContext context)
        {
            _context = context;
        }

        public static List<News> News
        {
            get
            {
                return GetInitialCategories();
            }
        }

        public void Create()
        {
            CreateNews();
        }

        private static List<News> GetInitialCategories()
        {
            return new()
                       {
                           new News()
                               {

                                CreationTime = DateTime.Now,
                                Description = "Shanghai Marriott Hotel expanded its portfolio of hotels in China.",
                                Date = new DateTime(2020,06,20)
                               };
        }

        private void AddNewsIfNotExists(News category)
        {
            if (_context.News.IgnoreQueryFilters().Any(l => l.Name == category.Name))
            {
                return;
            }

            _context.News.Add(category);
            _context.SaveChanges();
        }

        private void CreateNews()
        {
            foreach (News category in News)
            {
                AddNewsIfNotExists(category);
            }
        }
    }
}