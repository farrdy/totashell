using System;

namespace Total.DealerCom.Core
{
    /// <summary>
    /// SupplierMasterDataDTO Domain Object
    /// </summary>
    public class SupplierMasterData
    {

        public int SupplierMasterDataID { get; set; }
        public int SupplierID { get; set; }
        public DateTime DateCreated { get; set; }
        public string SupplierSpecialistVerification { get; set; }
        public DateTime? SupplierSpecialistVerificationDate { get; set; }
        public string AssignedCategoryManager { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Comments { get; set; }
        public string MasterDataStatus { get; set; }
        public DateTime? MasterDataStatusDate { get; set; }
        public bool Archive { get; set; }
    }

}

