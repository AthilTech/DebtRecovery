using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
   public class Note
    {     //properities
        public Guid NoteId { get; set; }
        public DateTime Date { get; set; }
        public string  Type { get; set; }
        //reference  properities
        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }
    }
}
