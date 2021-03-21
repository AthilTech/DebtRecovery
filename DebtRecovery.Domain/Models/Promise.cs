using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public class Promise
    {
        //properities

        public Guid PromissId { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }


        //reference  properities
        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }

       // public Guid FK_Payment { get; set; }
        //public Payment Payment{ get; set; }



    }
}
