﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class BillDTO
    {
        public Guid BillId { get; set; }
        public string Number { get; set; }
        public double Total { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
        public string PaymentMethod { get; set; }
        public bool Scenario_State { get; set; }
        public decimal Sum { get; set; }

        //customer 
        public string CustomerName { get; set; }
        public Guid FK_Customer{ get; set; }

    }

}