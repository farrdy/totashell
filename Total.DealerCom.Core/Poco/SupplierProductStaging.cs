namespace Total.DealerCom.Core
{
    /// <summary>
    /// SupplierProductStagingDTO Domain Object
    /// </summary>
    public partial class SupplierProductStaging
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

    }

}

