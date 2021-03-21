using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public class RecoveryManager : User
    {


        //navigation properties
        public ICollection<RecoveryAgent> RecoveryAgents { get; set; }
    }
}
