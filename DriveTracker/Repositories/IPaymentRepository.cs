using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Repositories
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
    }
}
