using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class ScenarioDTO
    {
        public Guid ScenarioId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Desciption { get; set; }
    }
}