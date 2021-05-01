using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtRecovery.Domain.Models
{
    public  class User
         
    {  
        
        public Guid UserId { get; set; }
        public string Icn { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; } 
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        //subsidiary 
        #region Subsidiary
        public Guid? FK_Subsidiary { get; set; }


        #endregion

        //one to many with role 

        public Guid? FK_Role { get; set; }
        public Role Role { get; set; }


    }
}
