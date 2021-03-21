using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public abstract class User
    {
        //properities
        public Guid UserId { get; set; }
        public string Name { get; set; }
        
        public int Telephonenumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
   
        public int Identitycard { get; set; }

        public int Subsidiary_Code  { get; set; }

        //reference  properities
        public Guid FK_Role { get; set; }
        public Role Role { get; set; }

    }
}
