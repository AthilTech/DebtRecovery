using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public class Role
    {
        // properities
        public Guid RoleId { get; set; }
        public string Login { get; set; }
     


        //navigation properties
        public ICollection<User> Users { get; set; }
    }
}
