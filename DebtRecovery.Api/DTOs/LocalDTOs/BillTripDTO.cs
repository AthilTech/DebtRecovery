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
    public class TripInfoDTO

    {
        public Guid BillTripId { get; set; }


        // trip
        public Guid FK_Trip { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Plannified { get; set; }
        public string Status { get; set; }
        //bill
        public Guid FK_Bill { get; set; }
        public string BillNumber { get; set; } 

        public Guid FK_Customer { get; set; }
        public string CustomerName { get; set; } 

    }
}
