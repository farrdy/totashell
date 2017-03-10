




using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Total.DealerCom.Core
{
    /// <summary>
    /// SupplierDTO Domain Object
    /// </summary>
    public partial class Supplier
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
        public string SupplierSpecialistStatus { get; set; }
        public DateTime? SupplierSpecialistDate { get; set; }
        public string SupplierSpecialistComment { get; set; }
        public string CategoryManagerStatus { get; set; }
        public DateTime? CategoryManagerDate { get; set; }
        public string CategoryManager { get; set; }
        public string CategoryManagerComment { get; set; }
        public string MasterDataComment { get; set; }
        public string MasterDataStatus { get; set; }
        public DateTime? MasterDataStatusDate { get; set; }
        public bool Archive { get; set; }

    }

}

