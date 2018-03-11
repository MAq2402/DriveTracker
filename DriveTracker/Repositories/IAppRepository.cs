using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Repositories
{
    public interface IAppRepository
    {
        bool Commit();
    }
}