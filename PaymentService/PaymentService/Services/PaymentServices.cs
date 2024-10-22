using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Models;
using PaymentService.Repositories;

namespace PaymentService.Services
{
    public class PaymentServices:IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentServices(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<PaymentModel> ProcessPaymentAsync(decimal amount)
        {
            var payment = new PaymentModel
            {
                Amount = amount,
                Status ="Pending",
                PaymentDate = DateTime.Now,
                TransactionId = Guid.NewGuid().ToString()
            };
            var success = await _paymentRepository.AddPaymentAsync(payment);
            return success ? payment:null;
        }
        public async Task<PaymentModel>GetPaymentByIdAsync(int paymentId)
        {
            return await _paymentRepository.GetPaymentByIdAsync(paymentId);
        }
        public async Task<IEnumerable<PaymentModel>>GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllPaymentAsync();
        }

        
    }
}