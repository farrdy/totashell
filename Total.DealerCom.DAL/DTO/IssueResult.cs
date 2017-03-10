using System;
using System.Xml.Serialization;

namespace Services.DTO
{
    [Serializable]
    [XmlRoot(ElementName = "Instance", IsNullable = false)]
    public class IssueResult
    {
        public string IDInstance { get; set; }

        public string DealerName { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string PODReference { get; set; }

        public string IDSOC { get; set; }

        public string SOCName { get; set; }

        public string Claim { get; set; }

        public string ClaimComment { get; set; }

        public string Volume { get; set; }

        public string IDIssueType { get; set; }

        public string IssueTypeName { get; set; }

        public string Duration { get; set; }

        public string Comment { get; set; }

        public string ATGOperational { get; set; }

        public string ATGCommFail { get; set; }

        public string UserId { get; set; }

        public string OutletNo { get; set; } //==UserId on InstanceSearch

        public string DealerUser { get; set; }

        public string IDProduct { get; set; }

        public string ProductName { get; set; }

        public string IDTank { get; set; }

        public string TankName { get; set; }

        public string DateDryFrom { get; set; }

        public string DateDryTo { get; set; }

        public string DateLogged { get; set; }

        public string DateClosed { get; set; }

        public string IDRequestStatus { get; set; }

        public string RequestStatusName { get; set; }

        public bool Adding { get; set; }
    }
}