using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class ActivityDTO
    {
        public Guid ActivityId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Media { get; set; }
        public string Model { get; set; }
        public int Order { get; set; }
        public bool Auto { get; set; }


    }
}