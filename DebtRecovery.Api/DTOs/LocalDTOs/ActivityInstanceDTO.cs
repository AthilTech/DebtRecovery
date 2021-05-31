using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class ActivityInstanceDTO
    {
        internal object billNumber;

        public Guid ActivityInstanceId { get; set; }
        public string Description { get; set; }
        public string PlanedDate { get; set; }
        public DateTime ActionDate { get; set; }
        public int ActionDuration { get; set; }
        public string MediaType { get; set; }
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

        public string ScenarioActivityName { get; set; }

        //bill
        public Guid FK_bill { get; set; }
        public object BillNumber { get; internal set; }
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
        public bool SuccessState { get; set; }

        //Customer
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustumerEmail { get; set; }


        //Agent
        public string AgentId { get; set; }
        public string AgentName { get; set; }

        //Activity
        public Guid Fk_ScenarioActivity { get; set; }
        public string Type { get; set; }

        public string ScenarioActivityName { get; set; }

        //scenario
        public string ScenarioLabel { get; set; }
        //bill
        public Guid FK_bill { get; set; }
        public string BillNumber { get; set; }
        public double BillAmount { get; set; }

    }


}
