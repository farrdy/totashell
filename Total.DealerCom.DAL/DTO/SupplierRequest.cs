using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DTO
{
    public class SupplierRequest
    {
        public DateTime? StartDate { get; set; }

        public int RequesterID { get; set; }

        public DateTime? EndDate { get; set; }

        public Requester Requester { get; set; }

        public Supplier Supplier { get; set; }
        
        public IEnumerable<SupplierProduct> SupplierProduct { get; set; }

    }
}
