using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    public static class RecipesRequestDao
    {
        public static IEnumerable<string> GetRecipesMasterDataStatusses()
        {
            return DataFacade.GetDataTable("RecipesMasterDataStatussesGet", new ParameterValue[0])
                .Rows.Cast<DataRow>().Select(x => x["MasterDataStatus"].ToString()).ToList();
        }

        public static IEnumerable<string> GetRecipesFoodTechnicianStatusses()
        {
            return DataFacade.GetDataTable("RecipesFoodTechnicianStatussesGet", new ParameterValue[0])
                .Rows.Cast<DataRow>().Select(x => x["FoodTechnicianStatus"].ToString()).ToList();
        }

        public static IEnumerable<RecipesRequest> GetRecipesRequests(
            RecipesRequestSearch requestFilter)
        {
            var dataSet = DataFacade.GetDataSet("RecipesRequestsGet",
                                                new ParameterValue("RequestId", requestFilter.Id),
                                                new ParameterValue("RequesterId",
                                                                   requestFilter.Requester == null
                                                                       ? -1
                                                                       : requestFilter.Requester.RequesterID),
                                                new ParameterValue("RequestDatetimeFrom", requestFilter.DateCreatedFrom),
                                                new ParameterValue("RequestDatetimeTo", requestFilter.DateCreatedTo),
                                                new ParameterValue("FoodTechnicianStatus", (string)null),
                                                new ParameterValue("MasterDataStatus",
                                                                   !String.IsNullOrEmpty(requestFilter.MasterDataStatus)
                                                                       ? requestFilter.MasterDataStatus
                                                                       : null),
                                                new ParameterValue("RecipeCode",
                                                                   !String.IsNullOrEmpty(requestFilter.RecipeCode)
                                                                       ? requestFilter.RecipeCode
                                                                       : null),
                                                new ParameterValue("RequesterSiteNumber",
                                                                   requestFilter.Requester == null ||
                                                                   String.IsNullOrEmpty(
                                                                       requestFilter.Requester.SiteNumber)
                                                                       ? null
                                                                       : requestFilter.Requester.SiteNumber),
                                                new ParameterValue("IncludeArchive", requestFilter.IncludeArchive)
                );

            var returnList = new List<RecipesRequest>();

            foreach (var requestItem in dataSet.Tables["Table"].Rows.Cast<DataRow>().Select(x => new RecipesRequest
                {
                    Id = (int)x["Id"],
                    Requester =
                        dataSet.Tables["Table1"].Rows.Cast<DataRow>().Where(
                            y => (int)y["RequesterID"] == (int)x["RequesterId"]).Select(
                                y => new Requester
                                    {
                                        RequesterID = (int)y["RequesterID"],
                                        RequestDate = (DateTime)y["RequestDate"],
                                        Motivation = y["Motivation"].ToString(),
                                        SiteName = y["SiteName"].ToString(),
                                        SiteNumber = y["SiteNumber"].ToString(),
                                        EmailAddress = y["EmailAddress"].ToString(),
                                        ContactNo = y["ContactNo"].ToString(),
                                        RequesterName = y["RequesterName"].ToString()
                                    }).FirstOrDefault(),
                    DateCreated = (DateTime)x["DateCreated"],
                    FoodTechnicianStatus = x["FoodTechnicianStatus"].ToString(),
                    FoodTechnicianStatusDateTime = x["FoodTechnicianStatusDateTime"] as DateTime?,
                    MasterDataStatus = x["MasterDataStatus"].ToString(),
                    MasterDataStatusDateTime = x["MasterDataStatusDateTime"] as DateTime?,
                    Archive = (bool)x["Archive"],
                    IsLoaded = (bool)x["IsLoaded"],
                    LoadedDateTime = x["LoadedDateTime"] as DateTime?,
                    FoodTechnicianComments = x["FoodTechnicianComments"].ToString(),
                    MasterDataComments = x["MasterDataComments"].ToString(),
                    IsApproved = (bool)x["IsApproved"],
                    ApprovedDateTime = x["ApprovedDateTime"] as DateTime?,
                    RecipeCode = x["RecipeCode"].ToString(),
                    RecipeDescription = x["RecipeDescription"].ToString(),
                    PreparedItemName = x["PreparedItemName"].ToString(),
                    PreparedItemBarcode = x["PreparedItemBarcode"].ToString(),
                    ISISRecipeName = x["ISISRecipeName"].ToString(),
                    MasterDataUserId = x["MasterDataUserId"].ToString(),
                    FoodTechnicianUserId = x["FoodTechnicianUserId"].ToString()
                }))
            {
                requestItem.RecipesItems =
                    dataSet.Tables["Table2"].Rows.Cast<DataRow>().Where(
                        x => (int)x["RecipesRequestId"] == requestItem.Id).Select(x => new RecipesItem
                            {
                                Id = (int)x["Id"],
                                RecipesRequest = requestItem,
                                IngredientName = x["IngredientName"].ToString(),
                                BaseUOMQty = x["BaseUOMQty"].ToString(),
                                Quantity = Convert.ToDecimal(x["Quantity"]),
                                ReportedInUOMQty = x["ReportedInUOMQty"].ToString(),
                                Cost = Convert.ToDecimal(x["Cost"]),
                                Supplier = x["Supplier"].ToString(),
                                ProductCode = x["ProductCode"].ToString(),
                                SupplierUOM = x["SupplierUOM"].ToString()
                            })
                        .ToList();

                returnList.Add(requestItem);
            }

            return returnList;
        }

        public static IEnumerable<RecipesRequest> GetRecipesRequestsPending(
    RecipesRequestSearch requestFilter)
        {
            var dataSet = DataFacade.GetDataSet("RecipesRequestsGetPending",
                                                new ParameterValue("RequestId", requestFilter.Id),
                                                new ParameterValue("RequesterId",
                                                                   requestFilter.Requester == null
                                                                       ? -1
                                                                       : requestFilter.Requester.RequesterID),
                                                new ParameterValue("RequestDatetimeFrom", requestFilter.DateCreatedFrom),
                                                new ParameterValue("RequestDatetimeTo", requestFilter.DateCreatedTo),
                                                new ParameterValue("FoodTechnicianStatus", (string)null),
                                                new ParameterValue("MasterDataStatus",
                                                                   !String.IsNullOrEmpty(requestFilter.MasterDataStatus)
                                                                       ? requestFilter.MasterDataStatus
                                                                       : null),
                                                new ParameterValue("RecipeCode",
                                                                   !String.IsNullOrEmpty(requestFilter.RecipeCode)
                                                                       ? requestFilter.RecipeCode
                                                                       : null),
                                                new ParameterValue("RequesterSiteNumber",
                                                                   requestFilter.Requester == null ||
                                                                   String.IsNullOrEmpty(
                                                                       requestFilter.Requester.SiteNumber)
                                                                       ? null
                                                                       : requestFilter.Requester.SiteNumber),
                                                new ParameterValue("IncludeArchive", requestFilter.IncludeArchive)
                );

            var returnList = new List<RecipesRequest>();

            foreach (var requestItem in dataSet.Tables["Table"].Rows.Cast<DataRow>().Select(x => new RecipesRequest
            {
                Id = (int)x["Id"],
                Requester =
                    dataSet.Tables["Table1"].Rows.Cast<DataRow>().Where(
                        y => (int)y["RequesterID"] == (int)x["RequesterId"]).Select(
                            y => new Requester
                            {
                                RequesterID = (int)y["RequesterID"],
                                RequestDate = (DateTime)y["RequestDate"],
                                Motivation = y["Motivation"].ToString(),
                                SiteName = y["SiteName"].ToString(),
                                SiteNumber = y["SiteNumber"].ToString(),
                                EmailAddress = y["EmailAddress"].ToString(),
                                ContactNo = y["ContactNo"].ToString(),
                                RequesterName = y["RequesterName"].ToString()
                            }).FirstOrDefault(),
                DateCreated = (DateTime)x["DateCreated"],
                FoodTechnicianStatus = x["FoodTechnicianStatus"].ToString(),
                FoodTechnicianStatusDateTime = x["FoodTechnicianStatusDateTime"] as DateTime?,
                MasterDataStatus = x["MasterDataStatus"].ToString(),
                MasterDataStatusDateTime = x["MasterDataStatusDateTime"] as DateTime?,
                Archive = (bool)x["Archive"],
                IsLoaded = (bool)x["IsLoaded"],
                LoadedDateTime = x["LoadedDateTime"] as DateTime?,
                FoodTechnicianComments = x["FoodTechnicianComments"].ToString(),
                MasterDataComments = x["MasterDataComments"].ToString(),
                IsApproved = (bool)x["IsApproved"],
                ApprovedDateTime = x["ApprovedDateTime"] as DateTime?,
                RecipeCode = x["RecipeCode"].ToString(),
                RecipeDescription = x["RecipeDescription"].ToString(),
                PreparedItemName = x["PreparedItemName"].ToString(),
                PreparedItemBarcode = x["PreparedItemBarcode"].ToString(),
                ISISRecipeName = x["ISISRecipeName"].ToString(),
                MasterDataUserId = x["MasterDataUserId"].ToString(),
                FoodTechnicianUserId = x["FoodTechnicianUserId"].ToString()
            }))
            {
                requestItem.RecipesItems =
                    dataSet.Tables["Table2"].Rows.Cast<DataRow>().Where(
                        x => (int)x["RecipesRequestId"] == requestItem.Id).Select(x => new RecipesItem
                        {
                            Id = (int)x["Id"],
                            RecipesRequest = requestItem,
                            IngredientName = x["IngredientName"].ToString(),
                            BaseUOMQty = x["BaseUOMQty"].ToString(),
                            Quantity = Convert.ToDecimal(x["Quantity"]),
                            ReportedInUOMQty = x["ReportedInUOMQty"].ToString(),
                            Cost = Convert.ToDecimal(x["Cost"]),
                            Supplier = x["Supplier"].ToString(),
                            ProductCode = x["ProductCode"].ToString(),
                            SupplierUOM = x["SupplierUOM"].ToString()
                        })
                        .ToList();

                returnList.Add(requestItem);
            }

            return returnList;
        }

        public static RecipesRequest Create(RecipesRequest request)
        {
            var dr = DataFacade.GetDataRow("RecipesRequestCreate",
                                           new ParameterValue("RequesterId", request.Requester.RequesterID),
                                           new ParameterValue("DateCreated", request.DateCreated),
                                           new ParameterValue("FoodTechnicianStatus",
                                                              request.FoodTechnicianStatus),
                                           new ParameterValue("FoodTechnicianStatusDateTime",
                                                              request.FoodTechnicianStatusDateTime),
                                           new ParameterValue("MasterDataStatus", request.MasterDataStatus),
                                           new ParameterValue("MasterDataStatusDateTime",
                                                              request.MasterDataStatusDateTime),
                                           new ParameterValue("Archive", request.Archive),
                                           new ParameterValue("IsLoaded", request.IsLoaded),
                                           new ParameterValue("LoadedDateTime", request.LoadedDateTime),
                                           new ParameterValue("FoodTechnicianComments", request.FoodTechnicianComments),
                                           new ParameterValue("MasterDataComments", request.MasterDataComments),
                                           new ParameterValue("IsApproved", request.IsApproved),
                                           new ParameterValue("ApprovedDateTime", request.ApprovedDateTime),
                                           new ParameterValue("RecipeCode", request.RecipeCode),
                                           new ParameterValue("RecipeDescription", request.RecipeDescription),
                                           new ParameterValue("PreparedItemName", request.PreparedItemName),
                                           new ParameterValue("PreparedItemBarcode", request.PreparedItemBarcode),
                                           new ParameterValue("ISISRecipeName", request.ISISRecipeName),
                                           new ParameterValue("MasterDataUserId",
                                                              String.IsNullOrEmpty(request.MasterDataUserId)
                                                                  ? null
                                                                  : request.MasterDataUserId),
                                           new ParameterValue("FoodTechnicianUserId",
                                                              String.IsNullOrEmpty(request.FoodTechnicianUserId)
                                                                  ? null
                                                                  : request.FoodTechnicianUserId)
                );

            return GetRecipesRequestsPending(new RecipesRequestSearch
                {
                    Id = Convert.ToInt32(dr["Id"]),
                }).FirstOrDefault();
        }

        public static RecipesRequest Update(RecipesRequest request)
        {
            var dr = DataFacade.GetDataRow("RecipesRequestUpdate",
                                           new ParameterValue("Id", request.Id),
                                           new ParameterValue("RequesterId", request.Requester.RequesterID),
                                           new ParameterValue("DateCreated", request.DateCreated),
                                           new ParameterValue("FoodTechnicianStatus",
                                                              request.FoodTechnicianStatus),
                                           new ParameterValue("FoodTechnicianStatusDateTime",
                                                              request.FoodTechnicianStatusDateTime),
                                           new ParameterValue("MasterDataStatus", request.MasterDataStatus),
                                           new ParameterValue("MasterDataStatusDateTime",
                                                              request.MasterDataStatusDateTime),
                                           new ParameterValue("Archive", request.Archive),
                                           new ParameterValue("IsLoaded", request.IsLoaded),
                                           new ParameterValue("LoadedDateTime", request.LoadedDateTime),
                                           new ParameterValue("FoodTechnicianComments", request.FoodTechnicianComments),
                                           new ParameterValue("MasterDataComments", request.MasterDataComments),
                                           new ParameterValue("IsApproved", request.IsApproved),
                                           new ParameterValue("ApprovedDateTime", request.ApprovedDateTime),
                                           new ParameterValue("RecipeCode", request.RecipeCode),
                                           new ParameterValue("RecipeDescription", request.RecipeDescription),
                                           new ParameterValue("PreparedItemName", request.PreparedItemName),
                                           new ParameterValue("PreparedItemBarcode", request.PreparedItemBarcode),
                                           new ParameterValue("ISISRecipeName", request.ISISRecipeName),
                                           new ParameterValue("MasterDataUserId",
                                                              String.IsNullOrEmpty(request.MasterDataUserId)
                                                                  ? null
                                                                  : request.MasterDataUserId),
                                           new ParameterValue("FoodTechnicianUserId",
                                                              String.IsNullOrEmpty(request.FoodTechnicianUserId)
                                                                  ? null
                                                                  : request.FoodTechnicianUserId));

            return GetRecipesRequests(new RecipesRequestSearch
                {
                    Id = (int)dr["Id"],
                }).FirstOrDefault();
        }

        public static void RecipesRequestToggleArchive(string list)
        {
            DataFacade.ExecuteNonQuery("RecipesRequestToggleArchive", new ParameterValue("requestIdList", list));
        }

        public static RecipesRequest RecipesRequestsPendingGet(RecipesRequestSearch requestFilter)
        {
            var dr = DataFacade.GetDataRow("RecipesRequestsPendingGet",
                                                new ParameterValue("RequesterSiteNumber",
                                                                   requestFilter.Requester == null ||
                                                                   String.IsNullOrEmpty(
                                                                       requestFilter.Requester.SiteNumber)
                                                                       ? null
                                                                       : requestFilter.Requester.SiteNumber)
                );
            try
            {
                return GetRecipesRequestsPending(new RecipesRequestSearch
                {
                    Id = Convert.ToInt32(dr["Id"]),
                }).FirstOrDefault();
            }
            catch
            {
                return null;
            }

        }

        public static DataSet GetRecipesRequestsExport(RecipesRequestSearch requestFilter)
        {
            return DataFacade.GetDataSet("RecipesRequestsExportGet",
                                         new ParameterValue("RequestId", requestFilter.Id),
                                         new ParameterValue("RequesterId",
                                                            requestFilter.Requester == null
                                                                ? -1
                                                                : requestFilter.Requester.RequesterID),
                                         new ParameterValue("RequestDatetimeFrom", requestFilter.DateCreatedFrom),
                                         new ParameterValue("RequestDatetimeTo", requestFilter.DateCreatedTo),
                                         new ParameterValue("FoodTechnicianStatus", (string)null),
                                         new ParameterValue("MasterDataStatus",
                                                            !String.IsNullOrEmpty(requestFilter.MasterDataStatus)
                                                                ? requestFilter.MasterDataStatus
                                                                  : null), 
                                         new ParameterValue("RecipeCode",
                                                            !String.IsNullOrEmpty(requestFilter.RecipeCode)
                                                                ? requestFilter.RecipeCode
                                                                : null),   
                                         new ParameterValue("RequesterSiteNumber",
                                                            requestFilter.Requester == null ||
                                                            String.IsNullOrEmpty(requestFilter.Requester.SiteNumber)
                                                                ? null
                                                                : requestFilter.Requester.SiteNumber),
                                         new ParameterValue("IncludeArchive", requestFilter.IncludeArchive)
                );
        }
    }
}
