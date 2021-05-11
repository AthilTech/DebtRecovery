using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Activity
    {
        public Guid ActivityId { get; set; }
        public string ActivityLabel { get; set; }
        public string Type { get; set; }
        public string Media { get; set; }
        public string Model { get; set; }
        public int Order { get; set; }
        public bool IsAuto { get; set; }

        public bool isActive { get; set; }

        //
        public int BeforeDays { get; set; }
        public int AfterDays { get; set; } 

        // testing this activity date thing 
        public DateTime date { get; set; }

        //reference properities

        //one to many with scenario
        public Guid FK_Scenario { get; set; }
        public Scenario Scenario { get; set; }

    }
}
