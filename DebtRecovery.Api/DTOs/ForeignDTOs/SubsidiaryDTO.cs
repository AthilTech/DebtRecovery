using System;
using System.Collections.Generic;
using System.Text;

namespace CounterManagement.Domain.ForeignDTO
{
   public class SubsidiaryDTO
    {
        public Guid SubsidiaryId { get; set; }
        public string SubsidiaryCode { get; set; }
        public string Label { get; set; }
        public string Logo { get; set; }
     
    }
}
