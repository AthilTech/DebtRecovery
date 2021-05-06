using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
     public class Customer

    {
        public Guid CustomerId { get; set; }
        public string LegalIdentifier { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Profile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool Litigation { get; set; } 

        //relationships 

        //Bill 
        public ICollection<Bill> Bills { get; set; }

        //Agent
        public Guid? FK_Agent { get; set; }
        public Agent Agent { get; set; }

        // scenario 
        public Guid FK_Scenario { get; set; }
        public Scenario Scenario { get; set; }




    }
}

