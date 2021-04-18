namespace Elevations.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly ElevationsDbContext _context;

        public InitialHostDbBuilder(ElevationsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultRoomsCategoryBuilder(_context).Create();
            new DefaultRoomsBuilder(_context).Create();
            new DefaultApartmentCategoryBuilder(_context).Create();
            new Apartment(_context).Create();
            new RestaurantBuilder(_context).Create();
            new NewsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}