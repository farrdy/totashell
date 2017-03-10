using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Total.DealerCom.Core
{
    /// <summary>
    /// SupplierProductDTO Domain Object
    /// </summary>
    public partial class SupplierProduct
    {

        public int SupplierProductID { get; set; }
        public int SupplierID { get; set; }
        public string RetailBarcode { get; set; }
        public string RetailPackSize { get; set; }
        public string Ranging { get; set; }
        public string OuterCaseCode { get; set; }
        public string PackBarcode { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string ISISRetailItemNaming { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int PackSizeCase { get; set; }
        public string UOMType { get; set; }
        public decimal? Cost { get; set; }
        public decimal? CaseCost { get; set; }
        public bool Archive { get; set; }
        public string CategoryManagerStatus { get; set; }
        public DateTime? CategoryManagerStatusDate { get; set; }
        public string CategoryManagerComment { get; set; }
        public DateTime DateCreated { get; set; }
        public string MasterDataComment { get; set; }
        public string MasterDataStatus { get; set; }
        public DateTime? MasterDataStatusDate { get; set; }

    }

}

