using DriveTracker.Entities;
using DriveTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void EditUsersPaymentStatistics(IEnumerable<Payment> payments,int receiverId)
        {
            var receiver = _userRepository.GetUser(receiverId);
                
            if(receiver==null)
            {
                throw new Exception("UserService EditUsersPaymentStatistics receiver==null");
            }

            receiver.ToReceive = payments.Sum(p => p.Amount);

            foreach (var payment in payments)
            {
                var payer = _userRepository.GetUser(payment.PayerId);
                if (payer == null)
                {
                    throw new Exception("UserService EditUsersPaymentStatistics payer==null");
                }
                payer.ToPay = payment.Amount;
            }
        }

    }
}