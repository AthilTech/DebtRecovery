using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class Bill_TripDTO
    {
        public Guid Bill_TripId { get; set; }
        public Guid FK_Trip { get; set; }
        public Guid FK_Bill { get; set; }
    }
}
