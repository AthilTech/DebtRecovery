﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class RoleDTO
    {
        public Guid RoleId { get; set; }
        public int Login { get; set; }
        public int Password { get; set; }
    }
}