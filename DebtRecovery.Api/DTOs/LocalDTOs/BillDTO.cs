using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class BillDTO
    {
        public Guid BillId { get; set; }
        public int Number { get; set; }
        public double Total { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
        public int NbPayments { get; set; }
        public string PaymentMethod { get; set; }
        public bool Scenario_State { get; set; }

        //customer 
        public string CustomerName { get; set; }
    }

}