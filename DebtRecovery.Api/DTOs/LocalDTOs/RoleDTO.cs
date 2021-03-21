using DebtRecovery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class RoleDTO
    {

        // properities
        public Guid RoleId { get; set; }
        public string RoleLogin { get; set; }
       


        //navigation properties
        public ICollection<User> Users { get; set; }
    }
}
