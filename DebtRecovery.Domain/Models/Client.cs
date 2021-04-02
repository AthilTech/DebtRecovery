using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
     public class Client

    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string contact { get; set; }
        public string Tel_m { get; set; }
        public string Tel_f { get; set; }
        public string Profile { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }
        public string Type { get; set; }

        //relationships 

        //Bill 
        public ICollection<Bill> Bills { get; set; }
        //Agent
        public Guid fk_Agent { get; set; }
        public Agent Agent { get; set; }
        // scenario 
        public Guid fk_Scenario { get; set; }
        public Scenario Scenario { get; set; }






    }
}

