﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DebtRecovery.Api.DTOs.ForeignDTOs
{
    public class TripDTO
    {
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool plannified { get; set; }
    }
}