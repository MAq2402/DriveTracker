using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.DbContexts;
using DriveTracker.Entities;

namespace DriveTracker.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
        }


    }
}