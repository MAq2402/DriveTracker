using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User GetUser(int id);
        bool UserExists(int id);
    }
}