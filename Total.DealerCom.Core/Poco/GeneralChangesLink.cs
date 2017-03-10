using System;

namespace Total.DealerCom.Core
{
    public class GeneralChangesLink
    {
        public int Id { get; set; }

        public GeneralChangesRequest GeneralChangesRequest { get; set; }

        public GeneralChangesItem GeneralChangesItem { get; set; }

        public bool IsSelected { get; set; }

        public bool? Approved { get; set; }

        public string Comments { get; set; }
      
        public bool? MasterDataApproved { get; set; }

        public DateTime? MasterDataStatusDateTime { get; set; }

        public bool? SpecialistVerificationApproved { get; set; }

        public DateTime? SpecialistVerificationStatusDateTime { get; set; }

    }
}
