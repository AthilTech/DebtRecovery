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


    }
}