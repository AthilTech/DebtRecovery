using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtRecovery.Domain.Models
{
    public abstract class User
         
    {   //   link for inheritence with the primary key in the parent class  https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-3-table-per-concrete-type-tpc-and-choosing-strategy-guidelines
        public Guid UserId { get; set; }
        public string CIN { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Login { get; set; } 
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        //subsidiary 
        #region Subsidiary
        public Guid? FK_Subsidiary { get; set; }

        #endregion

        //one to many with role 

        public Guid FK_Role { get; set; }
        public Role Role { get; set; }


    }
}
