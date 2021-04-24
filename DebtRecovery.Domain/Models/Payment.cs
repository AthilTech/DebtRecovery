using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Payment
    {

        public Guid PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DueDate { get; set; }

        public double PayedAmount { get; set; }
        // 

        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }

    }
}
