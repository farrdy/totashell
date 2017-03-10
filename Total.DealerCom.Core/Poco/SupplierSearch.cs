using System;

namespace Total.DealerCom.Core
{
    public class SupplierSearch
    {
        public Supplier Supplier { get; set; }

        public Requester Requester { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
