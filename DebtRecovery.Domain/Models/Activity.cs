using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Activity
    {
        public Guid ActivityId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Media { get; set; }
        public string Model { get; set; }
        public int Order { get; set; }
        public bool Auto { get; set; }


        //reference properities

        //one to many with scenario
        public Guid fk_Scenario { get; set; }
        public Scenario Scenario { get; set; }

    }
}
