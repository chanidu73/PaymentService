using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Models;

namespace PaymentService.Services
{
    public interface IPaymentService
    {
        Task<PaymentModel>ProcessPaymentAsync(decimal amount);
        Task<PaymentModel>GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<PaymentModel>> GetAllPaymentsAsync ();  
    }
}