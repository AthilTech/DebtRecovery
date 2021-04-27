using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Bill
    {
        public Guid BillId { get; set; }
        public string Number { get; set; }
        public double Total { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
        public string PaymentMethod { get; set; }
        public bool Scenario_State { get; set; }

        //Navigation Properties

        //many

        public ICollection<Promise> Promises { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<History> Histories { get; set; }

        public ICollection<BillTrip> BillTrips { get; set; }

        public Guid FK_Customer{ get; set; }
        public Customer Customer{ get; set; }

    }
}