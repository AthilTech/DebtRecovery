using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class NoteDTO
    {
        public Guid NoteId { get; set; }
        public string NoteSubject { get; set; }
        public string Content { get; set; }

        public DateTime Date { get; set; }
        public string Type { get; set; }
        public Guid FK_Bill { get; set; }
    }
}