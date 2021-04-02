using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Scenario
    {
        public Guid ScenarioId { get; set; }
        public string Type { get; set; }

        public ICollection<Activity> Activities { get; set; }
        public ICollection<Client> Clients { get; set; }


    }
}
