using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class ClientDTO
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Tel_m{ get; set; }
        public string Tel_f { get; set; }
        public string Profile { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }
        public string Type { get; set; }
    }
}