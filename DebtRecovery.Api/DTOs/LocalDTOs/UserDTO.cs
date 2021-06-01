using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string CIN { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        //subsidiary 
        public Guid? FK_Subsidiary { get; set; }
        public string SubsidiaryCode { get; set; }
        public string Label { get; set; }

        /// role
        public Guid? FK_Role { get; set; }


    }
}