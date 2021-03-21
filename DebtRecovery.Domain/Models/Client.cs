using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public class Client
    {
        //    properities
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Profil { get; set; }
        public string Type { get; set; }
        public int Telephonenumber { get; set; }
        public int Telephonenumberfixe { get; set; }

        //reference  properities
        public Guid FK_Agent { get; set; }
        public RecoveryAgent RecoveryAgent { get; set; }

        public Guid FK_Scenario { get; set; }
        public Scenario scenario { get; set; }

        //navigation properties
        public ICollection<Bill> Bills { get; set; }

        

    }
}
