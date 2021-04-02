using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtRecovery.Domain.Models
{
    public abstract class User

    {
        public Guid UserId { get; set; }
        public string LastName { get; set; }
        public string name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }

        //one to many with role 

        public Guid fk_Role { get; set; }
        public Role Role { get; set; }


    }
}
