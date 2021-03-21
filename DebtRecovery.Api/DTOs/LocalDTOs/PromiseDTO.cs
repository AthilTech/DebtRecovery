using DebtRecovery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class PromiseDTO
    {
        //properities

        public Guid PromissId { get; set; }
        public DateTime PromissDate { get; set; }
        public float PromissAmount { get; set; }


        //reference  properities
        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }
    }
}
