using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
     public class Activity
    {
        public Guid ActivityId { get; set; }
        public DateTime Date { get; set; }
        public String Type { get; set; }
        public String Media { get; set; }
        public String Model { get; set; }
        public int Order { get; set; }
        public int Automatic_send { get; set; }


        //reference  properities
        public Guid FK_Scenario { get; set; }
        public Scenario Scenario { get; set; }
    }
}
