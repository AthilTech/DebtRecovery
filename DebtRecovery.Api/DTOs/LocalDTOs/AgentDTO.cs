using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class AgentDTO:UserDTO
    {
      
        public Guid Fk_Manager { get; set; }
        public string ManagerFullName { get; set; }


    }
}