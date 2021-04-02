using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Bill
    {
        public Guid BillId { get; set; }
        public int Number { get; set; }
        public double Total { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
        public int NbPayments { get; set; }
        public string PaymentMethod { get; set; }
        public bool scenario_state { get; set; }

        //Navigation Properties

        //many

        public ICollection<Promise> Promises { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<History> Histories { get; set; }


        public Guid fk_Client { get; set; }
        public Client Client { get; set; }









    }
}