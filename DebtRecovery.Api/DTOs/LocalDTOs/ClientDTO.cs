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
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Profile { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }
        public string Type { get; set; }
        public bool Litige { get; set; }
 }
    public class ClientInfoDTO
    {
        
        public string Name { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Profile { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public bool Litige { get; set; }
        //Pamet State 
        public double LatePayment { get; set; }
        public double IncomingPayment { get; set; }
        public double TotalPayed { get; set; }



    }
}