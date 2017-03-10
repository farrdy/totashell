using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    public static class RecipesItemDao
    {
        public static RecipesItem RecipesItemGet(int itemId)
        {
            if (itemId < 1)
                return new RecipesItem();

            var r = DataFacade.GetDataRow("RecipesItemGet",
                                          new ParameterValue("Id", itemId));

            if (r == null)
                return new RecipesItem();

            return new RecipesItem
                {
                    Id = (int) r["Id"],
                    IngredientName = r["IngredientName"].ToString(),
                    BaseUOMQty = r["BaseUOMQty"].ToString(),
                    Quantity = Convert.ToDecimal(r["Quantity"]),
                    ReportedInUOMQty = r["ReportedInUOMQty"].ToString(),
                    Cost = Convert.ToDecimal(r["Cost"]),
                    Supplier = r["Supplier"].ToString(),
                    ProductCode = r["ProductCode"].ToString(),
                    SupplierUOM = r["SupplierUOM"].ToString(),
                    RecipesRequest = new RecipesRequest {Id = (int) r["RecipesRequestId"]}
                };
        }

        public static IEnumerable<RecipesItem> RecipesItemsGet(RecipesRequest request)
        {
            var data = DataFacade.GetDataTable("RecipesItemsGet",
                                               new ParameterValue("RecipeRequestId", request.Id));

            return data.Rows.Cast<DataRow>().Select(r => new RecipesItem
                {
                    Id = (int) r["Id"],
                    IngredientName = r["IngredientName"].ToString(),
                    BaseUOMQty = r["BaseUOMQty"].ToString(),
                    Quantity = Convert.ToDecimal(r["Quantity"]),
                    ReportedInUOMQty = r["ReportedInUOMQty"].ToString(),
                    Cost = Convert.ToDecimal(r["Cost"]),
                    Supplier = r["Supplier"].ToString(),
                    ProductCode = r["ProductCode"].ToString(),
                    SupplierUOM = r["SupplierUOM"].ToString(),
                    RecipesRequest = request
                })
                .ToList();
        }

        public static RecipesItem Create(RecipesItem recipesItem)
        {
            var r = DataFacade.GetDataRow("RecipesItemCreate",
                                          new ParameterValue("IngredientName", recipesItem.IngredientName),
                                          new ParameterValue("BaseUOMQty", recipesItem.BaseUOMQty),
                                          new ParameterValue("Quantity", recipesItem.Quantity),
                                          new ParameterValue("ReportedInUOMQty", recipesItem.ReportedInUOMQty),
                                          new ParameterValue("Cost", recipesItem.Cost),
                                          new ParameterValue("Supplier", recipesItem.Supplier),
                                          new ParameterValue("ProductCode", recipesItem.ProductCode),
                                          new ParameterValue("SupplierUOM", recipesItem.SupplierUOM),
                                          new ParameterValue("RecipesRequestId", recipesItem.RecipesRequest.Id)
                );

            return new RecipesItem
                {
                    Id = (int) r["Id"],
                    IngredientName = r["IngredientName"].ToString(),
                    BaseUOMQty = r["BaseUOMQty"].ToString(),
                    Quantity = Convert.ToDecimal(r["Quantity"]),
                    ReportedInUOMQty = r["ReportedInUOMQty"].ToString(),
                    Cost = Convert.ToDecimal(r["Cost"]),
                    Supplier = r["Supplier"].ToString(),
                    ProductCode = r["ProductCode"].ToString(),
                    SupplierUOM = r["SupplierUOM"].ToString(),
                    RecipesRequest = new RecipesRequest { Id = (int)r["RecipesRequestId"] }
                };
        }

        public static RecipesItem Update(RecipesItem recipesItem)
        {
            var r = DataFacade.GetDataRow("RecipesItemUpdate",
                                          new ParameterValue("Id", recipesItem.Id),
                                          new ParameterValue("IngredientName", recipesItem.IngredientName),
                                          new ParameterValue("BaseUOMQty", recipesItem.BaseUOMQty),
                                          new ParameterValue("Quantity", recipesItem.Quantity),
                                          new ParameterValue("ReportedInUOMQty", recipesItem.ReportedInUOMQty),
                                          new ParameterValue("Cost", recipesItem.Cost),
                                          new ParameterValue("Supplier", recipesItem.Supplier),
                                          new ParameterValue("ProductCode", recipesItem.ProductCode),
                                          new ParameterValue("SupplierUOM", recipesItem.SupplierUOM),
                                          new ParameterValue("RecipesRequestId", recipesItem.RecipesRequest.Id)
                );

            return new RecipesItem
                {
                    Id = (int) r["Id"],
                    IngredientName = r["IngredientName"].ToString(),
                    BaseUOMQty = r["BaseUOMQty"].ToString(),
                    Quantity = Convert.ToDecimal(r["Quantity"]),
                    ReportedInUOMQty = r["ReportedInUOMQty"].ToString(),
                    Cost = Convert.ToDecimal(r["Cost"]),
                    Supplier = r["Supplier"].ToString(),
                    ProductCode = r["ProductCode"].ToString(),
                    SupplierUOM = r["SupplierUOM"].ToString(),
                    RecipesRequest = new RecipesRequest { Id = (int)r["RecipesRequestId"] }
                };
        }

        public static void Delete(int id)
        {
            DataFacade.ExecuteNonQuery("RecipesItemDelete",
                                       new ParameterValue("Id", id));
        }
    }
}