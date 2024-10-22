using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentService.Data;
using PaymentService.Models;

namespace PaymentService.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly PaymentDbContext _context;
        public PaymentRepository(PaymentDbContext context)
        {
            _context =context;
        }        
        public async Task<PaymentModel>GetPaymentByIdAsync(int paymentId)
        {
            return await _context.Payments.FindAsync(paymentId);
        }
        public async Task<IEnumerable<PaymentModel>> GetAllPaymentAsync()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<bool>AddPaymentAsync(PaymentModel payment)
        {
            await _context.Payments.AddAsync(payment);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool>UpdatePaymentStatusAsync(int paymentId , string status)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if(payment == null)return false;
            payment.Status = status;
            return await _context.SaveChangesAsync()>0;
        }
    }
}