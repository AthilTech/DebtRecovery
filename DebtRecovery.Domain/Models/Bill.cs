using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
  public  class Bill
    {   //properities
        public Guid BillId { get; set; }
        public int Num { get; set; }
        public float Totalamount { get; set; }
        public DateTime Datecreation { get; set; }
        public DateTime Datedeadline { get; set; }
        public int Numberpayments { get; set; }
        public String ModePayment { get; set; }
        public int scenario_state { get; set; }


        //reference  properities
        public Guid FK_Client { get; set; }
        public Client client { get; set; }


        //navigation properties
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Promise> Promesses { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<History> histories { get; set; }
        public ICollection<Bill_Trip> Bill_Trips { get; set; }
    }
}
