using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtRecovery.Api.DTOs.LocalDTOs
{
    public class CustomerDTO
    {
        public Guid CustomerId { get; set; }
        public string LegalIdentifier { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Profile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public bool Litigation { get; set; }
        public double TotalPayed { get; set; }
        public double SommmeLitigation { get; set; }
        public double LatePayment { get; set; }

        public double NotPayed { get; set; }

        #region testing 
        //public ICollection<Bill> Bills { get; set; }
        #endregion


        //
        public string CustomerAbreviation { get; set; }

    }
    public class CustomerInfoDTO
    {
        public Guid CustomerId { get; set; }
        public string LegalIdentifier { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Profile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public bool Litigation { get; set; }
        //Pamet State 
        public double LatePayment { get; set; }

        public double NotPayed { get; set; } // the sum pf total from bills - sum mte3 les payments

        public double TotalPayed { get; set; } //sum of payments
        //
        public string CustomerAbreviation { get; set; }



    }

    public class CustomerUpdateScenarioDTO
    {
        public Guid CustomerId { get; set; }

        public Guid FK_Scenario { get; set; }
    }
}