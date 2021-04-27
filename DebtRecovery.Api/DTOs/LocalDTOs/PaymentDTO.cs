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

        public double PayedAmount { get; set; }
    } 
    public class PaymentSumDTO
    {
        public List<PaymentDTO> Payments { get; set; }
        public double Sum { get; set; }
    }
    public class PaymentsWithSum
    {
        public double PaymentSum { get; set; }
        public List<PaymentDTO> Payments { get; set; }
    }
}