﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DebtRecovery.Domain.Models

{
  public  class BillTrip 

    {   public Guid BillTripId { get; set; }
        public Guid FK_Trip { get; set; }
        public Guid FK_Bill { get; set; }
        public Bill Bill { get; set; }
    }
}
