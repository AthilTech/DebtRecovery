using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        // 
        public Guid fk_Bill { get; set; }
        public Bill Bill { get; set; }

    }
}
