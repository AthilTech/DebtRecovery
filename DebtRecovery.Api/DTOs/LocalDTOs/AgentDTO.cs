﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class AgentDTO:UserDTO
    {
        public Guid AgentId { get; set; }


    }
}