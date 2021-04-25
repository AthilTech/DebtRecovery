using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Role
    {

        //scalar properities
        public Guid RoleId { get; set; }
        public string Label { get; set; }

    //one-to-many with user 
    public ICollection<User> Users { get; set; }




    }
}
