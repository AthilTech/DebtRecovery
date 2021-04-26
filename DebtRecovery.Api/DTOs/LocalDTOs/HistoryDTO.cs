using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class HistoryDTO
    {
        public Guid HistoryId { get; set; }
        public string Activity { get; set; }
        public string Comment { get; set; }
        public string Customer{ get; set; }
        public string Agent_Name { get; set; }
        public int Bill_Num { get; set; }
        public DateTime Date { get; set; }
    }
}