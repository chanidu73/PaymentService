using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Services;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController:ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(decimal amount)
        {
            var payment = await _paymentService.ProcessPaymentAsync(amount);
            if(payment==null) 
            {
                return BadRequest("The Process of paying failed");
            }
            return Ok(payment);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetPayment(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if(payment ==null)return NotFound("there is no payment");
            return Ok(payment);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }
    }
}