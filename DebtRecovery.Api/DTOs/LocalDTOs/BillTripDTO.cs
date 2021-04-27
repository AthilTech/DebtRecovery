using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class BillTripDTO
    {
        public Guid BillTripId { get; set; }
        public Guid FK_Trip { get; set; }
        public Guid FK_Bill { get; set; }
    }
}
