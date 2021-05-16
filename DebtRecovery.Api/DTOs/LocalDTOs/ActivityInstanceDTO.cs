using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class ActivityInstanceDTO
    {
        public Guid ActivityInstanceId { get; set; }
        public string Description { get; set; }
        public string PlanedDate { get; set; }
        public DateTime ActionDate { get; set; }
        public int ActionDuration { get; set; }
        public string MediaType { get; set; }
        public bool IsAuto { get; set; }

        //Customer
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        //Agent
        public string AgentId { get; set; }
        public string AgentName { get; set; }

        //Activity
        public Guid Fk_ScenarioActivity { get; set; }

        public string ScenarioActivityName { get; set; }

        //bill
        public Guid FK_bill { get; set; }

    }
    public class GeneratedActivityInstanceDTO
    {
        public Guid ActivityInstanceId { get; set; }
        public string Description { get; set; }
        public DateTime PlanedDate { get; set; }
        public DateTime ActionDate { get; set; }
        public int ActionDuration { get; set; }
        public string MediaType { get; set; }
        public bool IsAuto { get; set; }
        public bool IsAchieved { get; set; }

        //Customer
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        //Agent
        public string AgentId { get; set; }
        public string AgentName { get; set; }

        //Activity
        public Guid Fk_ScenarioActivity { get; set; }

        public string ScenarioActivityName { get; set; }

        //scenario
        public string ScenarioLabel { get; set; }
        //bill
        public Guid FK_bill { get; set; }
        public string BillNumber { get; set; }
        public double BillAmount { get; set; }

    }


}
