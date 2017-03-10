using System;

namespace Services.DTO
{
    /// <summary>
    /// SupplierStagingDTO Domain Object
    /// </summary>
    public partial class SupplierStaging
    {

        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int? PostalCode { get; set; }
        public string Phone { get; set; }
        public string ContactName { get; set; }
        public string Cellphone { get; set; }
        public string VATNo { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public int RequesterID { get; set; }
        public DateTime? DateCreated { get; set; }

    }

}

