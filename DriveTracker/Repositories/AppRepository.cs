using DriveTracker.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Repositories
{
    public class AppRepository : IAppRepository
    {
        private AppDbContext _context;

        public AppRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Commit()
        {
            return _context.SaveChanges()>0;
        }
    }
}