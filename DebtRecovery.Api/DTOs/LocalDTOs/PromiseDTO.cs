using DebtRecovery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class PromiseDTO
    {
        public Guid PromiseId { get; set; }
       
        public DateTime PromiseDate { get; set; }
        public double AmountPromised { get; set; }

        //Customer
        public string CustomerName { get; set; }

        //Bill

        public Guid FK_Bill { get; set; }
        public string BillNumber { get; set; }


    }
}