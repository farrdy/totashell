namespace Services.DTO
{
    public class GeneralChangesItem
    {
        public int Id { get; set; }

        public GeneralChangesItemGroup GeneralChangesItemGroup { get; set; }

        public string ItemName { get; set; }

        public bool Active { get; set; }

        public int SortOrder { get; set; }
    }
}
