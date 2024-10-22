using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get;set; }
        public string TransactionId {get;set; }
        public decimal Amount { get;set; }
        public string Status { get;set; }
        public DateTime PaymentDate { get;set; }

    }
}