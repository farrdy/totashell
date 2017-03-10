using System;

namespace Services.DTO
{
    public class RecipesRequestSearch
    {
        public int Id { get; set; }

        public Requester Requester { get; set; }

        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedTo { get; set; }

        public string RecipeCode { get; set; }

        public string MasterDataStatus { get; set; }

        public bool IncludeArchive { get; set; }
    }
}
