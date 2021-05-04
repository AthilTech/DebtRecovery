using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class ScenarioDTO
    {
        public Guid ScenarioId { get; set; }
        public string ScenarioLabel { get; set; }
        public bool IsCentralized { get; set; }
        public bool IsActive { get; set; }

        public int ActivitiesCount { get; set; }

    }
}