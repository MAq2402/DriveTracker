using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.DbContexts;
using DriveTracker.Entities;

namespace DriveTracker.Repositories
{
    public class FuelRepository : IFuelRepository
    {
        private AppDbContext _context;

        public FuelRepository(AppDbContext context)
        {
            _context = context;
        }
        public Fuel GetFuel(int id)
        {
            return _context.Fuels.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Fuel> GetFuels()
        {
            return _context.Fuels;
        }
    }
}