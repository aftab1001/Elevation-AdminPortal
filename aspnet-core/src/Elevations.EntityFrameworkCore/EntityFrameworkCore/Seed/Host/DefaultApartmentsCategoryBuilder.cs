namespace Elevations.EntityFrameworkCore.Seed.Host
{
    using Elevations.EntityFrameworkCore.HotelDto;

    public class DefaultApartmentsCategoryBuilder
    {
        private readonly ElevationsDbContext _context;

        public DefaultApartmentsCategoryBuilder(ElevationsDbContext context)
        {
            _context = context;
        }

        public static List<Apartments> InitializeApartments
        {
            get
            {
                return GetInitialApartments();
            }
        }

        public void Create()
        {
            CreateRoomCategories();
        }

        private static List<Apartments> GetInitialApartments()
        {
            return new()
                       {
                           new Apartments() { CreationTime = DateTime.Now, Name = "Guest House" },
                           new Apartments() { Name = "Meeting Room", CreationTime = DateTime.Now }
                       };
        }

        private void AddRoomCatIfNotExists(Apartments category)
        {
            if (_context.Ap.IgnoreQueryFilters().Any(l => l.Id == category.Id))
            {
                return;
            }

            _context.RoomsCategory.Add(category);
            _context.SaveChanges();
        }

        private void CreateRoomCategories()
        {
            foreach (RoomsCategory language in InitializeApartments)
            {
                AddRoomCatIfNotExists(language);
            }
        }
    }
}