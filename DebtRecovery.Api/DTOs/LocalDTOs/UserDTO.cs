using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string LastName { get; set; }
        public string name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }
    }
}