using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtRecovery.Domain.Models
{
    public class Manager : User
    {
        public Guid ManagerId { get; set; }
        public ICollection<Agent> Agents { get; set; }

    }
}
