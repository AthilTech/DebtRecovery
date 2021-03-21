using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
  public  class Scenario
    {
        //properities

        public Guid ScenarioId { get; set; }
        public String Name { get; set; }

        //navigation properties
        public ICollection<Activity> Activities { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
