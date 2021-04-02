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

        public string Comment { get; set; }

        //one-many relations 

        public Guid fk_Bill { get; set; }
        public Bill Bill { get; set; }
    }
}
