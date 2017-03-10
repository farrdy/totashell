using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Total.DealerCom.Core
{
    public class RecipesItem
    {
        public int Id { get; set; }

        public RecipesRequest RecipesRequest { get; set; }

        public string IngredientName { get; set; }

        public string BaseUOMQty { get; set; }

        public Decimal Quantity { get; set; }

        public string ReportedInUOMQty { get; set; }

        public Decimal Cost { get; set; }

        public string Supplier { get; set; }

        public string ProductCode { get; set; }

        public string SupplierUOM { get; set; }
    }
}
