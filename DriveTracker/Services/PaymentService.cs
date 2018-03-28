using DriveTracker.Entities;
using DriveTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void GeneratePayments(Journey journey)
        {
            throw new NotImplementedException();
        }
    }
}