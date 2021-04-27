using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Promise
    {

        public Guid PromiseId { get; set; }
     
        public DateTime PromiseDate { get; set; }
        public double AmountPromised { get; set; }

      

        //one-many relations 

        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }
    }
}
