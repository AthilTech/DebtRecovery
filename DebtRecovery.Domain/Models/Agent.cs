using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtRecovery.Domain.Models
{
    public class Agent : User
    {
        public Guid AgentId { get; set; }


        //reference properities

        public Guid? FK_Manager { get; set; }
        //the question mark is to make it nullable thats how we avoid the cascade error 1785 https://stackoverflow.com/questions/12868912/specify-on-delete-no-action-in-asp-net-mvc-4-c-sharp-code-first
        public Manager Manager { get; set; }

        //client
        public ICollection<Client> Clients { get; set; }


    }
}
