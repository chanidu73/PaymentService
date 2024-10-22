using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Models;

namespace PaymentService.Repositories
{
    public interface IPaymentRepository
    {
        Task<PaymentModel>GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<PaymentModel>> GetAllPaymentAsync();
        Task<bool>AddPaymentAsync (PaymentModel payment);
        Task<bool>UpdatePaymentStatusAsync(int paymentId , string status );
    }
}