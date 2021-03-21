using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public class History
    {
        public Guid HistoryId { get; set; }
        public DateTime   Date { get; set; }

        //reference  properities
        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }
    }
}
