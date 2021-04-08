using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class History
    //we need to create our own attributes
    {
        public Guid HistoryId { get; set; }
        public string Activity { get; set; }
        public string Comment { get; set; }
        public string Client { get; set; }
        public string Agent_Name { get; set; }
        public int Bill_Num { get; set; }
        public DateTime Date { get; set; }

        //reference properities  

        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }





    }
}