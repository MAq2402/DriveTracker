using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Services
{
    public interface IJourneyService
    {
        void GiveTotalPrices(Journey journey, double priceForLiter);
    }
}
