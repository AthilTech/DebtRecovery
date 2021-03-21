using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public class RecoveryAgent : User
    {

        //navigation properties
        public ICollection<Client> Clients { get; set; }
       

        //reference  properities
        public Guid? FK_Manager { get; set; }
        public RecoveryManager? RecoveryManager { get; set; }

    }
}
