using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class History
    //we need to create our own attributes
    {
        public Guid HistoryId { get; set; }
        public string ActionLabel { get; set; }

        public string Comment { get; set; }
        public DateTime Date { get; set; }

        //scenario Activity
        public string ScenarioActivity{ get; set; }
        

        //Customer
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        //Agent
        public string AgentId { get; set; }
        public string AgentName { get; set; }




        //reference properities  
        //Bill 
        public string BillNumber { get; set; }
        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }





    }
}