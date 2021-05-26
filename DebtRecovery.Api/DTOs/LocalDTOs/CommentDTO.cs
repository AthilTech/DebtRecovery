using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class CommentDTO
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        // 
        public Guid FK_Customer { get; set; }
       
    }
}
