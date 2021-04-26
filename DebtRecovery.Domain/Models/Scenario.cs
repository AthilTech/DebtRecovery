using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Scenario
    {
        public Guid ScenarioId { get; set; }
        public string ScenarioLabel { get; set; }
        public bool IsCentralized { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<Customer> Customers { get; set; }
      
    }
}
