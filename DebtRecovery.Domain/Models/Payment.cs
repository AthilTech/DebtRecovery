using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Payment
    {   //properities

        public Guid PaymentID { get; set; }
        public String PaymentMode { get; set; }
        public DateTime Date { get; set; }
        public float Payrollamount { get; set; }
        public float Amountpaid { get; set; }

        // reference properties
        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }



        //navigation properties
       // public ICollection<Promise> Promises { get; set; }
    }
}

