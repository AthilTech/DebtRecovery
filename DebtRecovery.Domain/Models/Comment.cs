using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        // 
        public Guid FK_Customer { get; set; }
        public Customer Customer { get; set; }
    }
}
