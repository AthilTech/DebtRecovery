using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DebtRecovery.Api.DTOs.ForeignDTOs
{
   public class SubsidiaryDTO
    {
        public Guid SubsidiaryId { get; set; }
        public string SubsidiaryCode { get; set; }
        public string Label { get; set; }
        public string Logo { get; set; }
        public string MFG_Code { get; set; }
        public string MFG_Label { get; set; }

    }
}
