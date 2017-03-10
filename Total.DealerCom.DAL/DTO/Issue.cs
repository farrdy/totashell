namespace Services.DTO
{
    public class Issue
    {
        public int? IDInstance { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string OutletNo { get; set; }

        public string DealerUser { get; set; }

        public int? IDProduct { get; set; }

        public int? IDTank { get; set; }

        public string DateDryFrom { get; set; }

        public string DateDryTo { get; set; }

        public string IDRequestStatus { get; set; }

        public int? IDSoc { get; set; }
    }
}