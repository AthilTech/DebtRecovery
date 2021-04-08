using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class PaymentDTO
    {
        public Guid PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DueDate { get; set; }
        public double AmountToPay { get; set; }
        public double PayedAmount { get; set; }
    }
}