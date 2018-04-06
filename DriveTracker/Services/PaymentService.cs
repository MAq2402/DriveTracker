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

        public IEnumerable<Payment> GeneratePayments(Journey journey, int journeyUserId)
        {
            var payments = new List<Payment>();
            var routes = journey.PassengerRoutes;
            foreach(var route in routes)
            {
                var payment = new Payment
                {
                    ReceiverId = journeyUserId,
                    PayerId = route.UserId,
                    Journey = journey,
                    Amount = route.TotalPrice,
                };
                payments.Add(payment);
            }
            return payments;
        }

    }
}