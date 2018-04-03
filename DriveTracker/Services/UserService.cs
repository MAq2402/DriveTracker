using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Services
{
    public class UserService : IUserService
    {
        public void EditUserPaymentStatistics(IEnumerable<Payment> payments)
        {
            var receiver = payments.FirstOrDefault().Receiver;
                
            if(receiver==null)
            {
                return;
            }

            receiver.ToReceive = payments.Sum(p => p.Amount);

           foreach(var payment in payments)
            {
                payment.Payer.ToPay = payment.Amount;
            }
        }

    }
}