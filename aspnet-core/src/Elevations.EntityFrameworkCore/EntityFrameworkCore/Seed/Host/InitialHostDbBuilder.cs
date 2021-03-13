﻿namespace Elevations.EntityFrameworkCore.Seed.Host
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

            _context.SaveChanges();
        }
    }
}
