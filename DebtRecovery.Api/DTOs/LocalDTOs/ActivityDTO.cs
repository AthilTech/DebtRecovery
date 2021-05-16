using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class ActivityDTO
    {
        public Guid ActivityId { get; set; }
        public string ActivityLabel { get; set; }
        public string Type { get; set; }
        public string Media { get; set; }
        public string Model { get; set; }
        public int Order { get; set; }
        public bool IsAuto { get; set; }
        public bool IsActive { get; set; }
        //
        public int BeforeDays { get; set; }
        public int AfterDays { get; set; } 
        //public DateTime Date { get; set; }


    }
}