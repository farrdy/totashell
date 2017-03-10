namespace Total.DealerCom.Core
{
    public class Dealer
    {
        public string DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerEmail { get; set; }
        public string DealerTelCountry { get; set; }
        public string DealerTelCode { get; set; }
        public string DealerTelNo { get; set; }
        public string DealerAltTelCountry { get; set; }
        public string DealerAltTelCode { get; set; }
        public string DealerAltTelNo { get; set; }
        public string DealerFaxCountry { get; set; }
        public string DealerFaxCode { get; set; }
        public string DealerFaxNo { get; set; }
        public string DealerPostalAddress { get; set; }
        public string DealerPostalSuburb { get; set; }
        public string DealerPostalTown { get; set; }
        public string DealerPostalCode { get; set; }
        public string DealerPhysicalAddress { get; set; }
        public string DealerPhysicalSuburb { get; set; }
        public string DealerPhysicalTown { get; set; }
        public string DealerPhysicalCode { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
         public int? StartYear { get; set; }
        public int? StartMonth { get; set; }

        public int? EndYear { get; set; }
        public int? EndMonth { get; set; }
    }
}
