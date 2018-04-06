using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Services
{
    public interface IUserService
    {
        void EditUsersPaymentStatistics(IEnumerable<Payment> payments,int receiverId);
    }

}
