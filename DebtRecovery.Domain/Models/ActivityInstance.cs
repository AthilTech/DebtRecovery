using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
  public class ActivityInstance
    {   
        //
        public Guid ActivityInstanceId { get; set; }
        public string Description { get; set; }
        public DateTime PlanedDate { get; set; }
        public DateTime ActionDate { get; set; }
        public string MediaType { get; set; }
        public int ActionDuration { get; set; }
        public bool IsAuto { get; set; }
        public bool SuccessState { get; set; }

        //Customer
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        //Agent
        public string AgentId { get; set; }
        public string AgentName { get; set; }

        //Activity
        public Guid Fk_ScenarioActivity { get; set; }
        public Activity ScenarioActivity { get; set; }
        public string ScenarioActivityName { get; set; }

        //bill
        public Guid FK_bill { get; set; }
        public Bill Bill { get; set; }
    }
}
