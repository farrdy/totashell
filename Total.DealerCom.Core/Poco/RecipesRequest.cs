using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Total.DealerCom.Core
{
    public class RecipesRequest
    {
        public int Id { get; set; }

        public Requester Requester { get; set; }

        public DateTime DateCreated { get; set; }

        public string FoodTechnicianStatus { get; set; }

        public DateTime? FoodTechnicianStatusDateTime { get; set; }

        public string MasterDataStatus { get; set; }

        public DateTime? MasterDataStatusDateTime { get; set; }

        public bool Archive { get; set; }

        public bool IsLoaded { get; set; }

        public DateTime? LoadedDateTime { get; set; }

        public string FoodTechnicianComments { get; set; }

        public string MasterDataComments { get; set; }

        public bool IsApproved { get; set; }

        public DateTime? ApprovedDateTime { get; set; }

        public string RecipeCode { get; set; }

        public string RecipeDescription { get; set; }

        public string PreparedItemName { get; set; }

        public string PreparedItemBarcode { get; set; }

        public string ISISRecipeName { get; set; }

        public IEnumerable<RecipesItem> RecipesItems { get; set; }

        public string MasterDataUserId { get; set; }

        public string FoodTechnicianUserId { get; set; }
    }
}
