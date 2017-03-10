using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    public static class GeneralChangesRequestDao
    {
        public static IEnumerable<string> GetGeneralChangesMasterDataStatusses()
        {
            return DataFacade.GetDataTable("GeneralChangesMasterDataStatussesGet", new ParameterValue[0])
                .Rows.Cast<DataRow>().Select(x => x["MasterDataStatus"].ToString()).ToList();
        }

        public static IEnumerable<string> GetGeneralChangesSpecialistVerificationStatusses()
        {
            return DataFacade.GetDataTable("GeneralChangesSpecialistVerificationStatussesGet", new ParameterValue[0])
                .Rows.Cast<DataRow>().Select(x => x["SpecialistVerificationStatus"].ToString()).ToList();
        }

        public static IEnumerable<GeneralChangesRequest> GetGeneralChangesRequests(
            GeneralChangesRequestSearch requestFilter)
        {
            var dataSet = DataFacade.GetDataSet("GeneralChangesRequestsGet",
                                                new ParameterValue("RequestId", requestFilter.Id),
                                                new ParameterValue("RequesterId",
                                                                   requestFilter.Requester == null
                                                                       ? -1
                                                                       : requestFilter.Requester.RequesterID),
                                                new ParameterValue("RequestDatetimeFrom", requestFilter.DateCreatedFrom),
                                                new ParameterValue("RequestDatetimeTo", requestFilter.DateCreatedTo),
                                                new ParameterValue("SpecialistVerificationStatus", (string)null),
                                                new ParameterValue("MasterDataStatus",
                                                                   !String.IsNullOrEmpty(requestFilter.MasterDataStatus)
                                                                       ? requestFilter.MasterDataStatus
                                                                       : null),
                                                new ParameterValue("RequesterSiteNumber",
                                                                   requestFilter.Requester == null ||
                                                                   String.IsNullOrEmpty(
                                                                       requestFilter.Requester.SiteNumber)
                                                                       ? null
                                                                       : requestFilter.Requester.SiteNumber),
                                                new ParameterValue("IncludeArchive", requestFilter.IncludeArchive)
                );

            var items = new List<GeneralChangesItem>();

            foreach (var group in dataSet.Tables["Table4"].Rows.Cast<DataRow>().Select(z => new GeneralChangesItemGroup
                {
                    Active = (bool)z["Active"],
                    GroupName = z["GroupName"].ToString(),
                    Id = (int)z["Id"],
                    SortOrder = (int)z["SortOrder"],
                    MinSelectionCount = (byte)z["MinSelectionCount"],
                    MaxSelectionCount = (byte)z["MaxSelectionCount"],
                    Approvable = (bool)z["Approvable"]
                }))
            {
                group.GeneralChangesItems = dataSet.Tables["Table3"].Rows.Cast<DataRow>().Where(
                    x => (int)x["GeneralChangesItemGroupId"] == group.Id).Select(row => new GeneralChangesItem
                        {
                            Active = (bool)row["Active"],
                            GeneralChangesItemGroup = group,
                            Id = (int)row["Id"],
                            ItemName = row["ItemName"].ToString(),
                            SortOrder = (int)row["SortOrder"]
                        }).ToList();

                items.AddRange(group.GeneralChangesItems);
            }

            var returnList = new List<GeneralChangesRequest>();

            foreach (
                var requestItem in
                    dataSet.Tables["Table"].Rows.Cast<DataRow>().Select(request => new GeneralChangesRequest
                        {
                            Id = (int)request["Id"],
                            Requester =
                                dataSet.Tables["Table1"].Rows.Cast<DataRow>().Where(
                                    x => (int)x["RequesterID"] == (int)request["RequesterId"]).Select(
                                        x => new Requester
                                            {
                                                RequesterID = (int)x["RequesterID"],
                                                RequestDate = (DateTime)x["RequestDate"],
                                                Motivation = x["Motivation"].ToString(),
                                                SiteName = x["SiteName"].ToString(),
                                                SiteNumber = x["SiteNumber"].ToString(),
                                                EmailAddress = x["EmailAddress"].ToString(),
                                                ContactNo = x["ContactNo"].ToString(),
                                                RequesterName = x["RequesterName"].ToString()
                                            }).FirstOrDefault(),
                            DateCreated = (DateTime)request["DateCreated"],
                            SpecialistVerificationStatus = request["SpecialistVerificationStatus"].ToString(),
                            SpecialistVerificationStatusDateTime =
                                request["SpecialistVerificationStatusDateTime"] as DateTime?,
                            IsApproved = (bool)request["IsApproved"],
                            SpecialistVerificationComments = request["SpecialistVerificationComments"].ToString(),
                            MasterDataComments = request["MasterDataComments"].ToString(),
                            ApprovedDateTime = request["ApprovedDateTime"] as DateTime?,
                            MasterDataStatus = request["MasterDataStatus"].ToString(),
                            MasterDataStatusDateTime = request["MasterDataStatusDateTime"] as DateTime?,
                            Archive = (bool)request["Archive"],
                            IsLoaded = (bool)request["IsLoaded"],
                            LoadedDateTime = request["LoadedDateTime"] as DateTime?,
                            MasterDataUserId = request["MasterDataUserId"].ToString(),
                            SpecialistVerificationUserId = request["SpecialistVerificationUserId"].ToString()
                        }))
            {
                GeneralChangesRequest reqItem = requestItem;
                requestItem.GeneralChangesItems = dataSet.Tables["Table2"].Rows.Cast<DataRow>().Where(
                    x => (int)x["GeneralChangesRequestId"] == reqItem.Id).Select(x => new GeneralChangesLink
                        {
                            Id = (int)x["Id"],
                            GeneralChangesRequest = reqItem,
                            GeneralChangesItem = items.FirstOrDefault(y => y.Id == (int)x["GeneralChangesItemId"]),
                            IsSelected = (bool)x["IsSelected"],
                            Comments = x["Comments"].ToString(),
                            Approved = x["Approved"] as bool?,
                            MasterDataApproved = x["MasterDataApproved"] as bool?,
                            SpecialistVerificationApproved = x["SpecialistVerificationApproved"] as bool?
                        }).ToList();

                returnList.Add(requestItem);
            }

            return returnList;
        }

        internal static GeneralChangesRequest Create(GeneralChangesRequest request)
        {
            var dr = DataFacade.GetDataRow("GeneralChangesRequestCreate",
                                           new ParameterValue("RequesterId", request.Requester.RequesterID),
                                           new ParameterValue("DateCreated", request.DateCreated),
                                           new ParameterValue("SpecialistVerificationStatus",
                                                              request.SpecialistVerificationStatus),
                                           new ParameterValue("SpecialistVerificationStatusDateTime",
                                                              request.SpecialistVerificationStatusDateTime),
                                           new ParameterValue("IsApproved", request.IsApproved),
                                           new ParameterValue("SpecialistVerificationComments",
                                                              request.SpecialistVerificationComments),
                                           new ParameterValue("MasterDataComments", request.MasterDataComments),
                                           new ParameterValue("ApprovedDateTime", request.ApprovedDateTime),
                                           new ParameterValue("MasterDataStatus", request.MasterDataStatus),
                                           new ParameterValue("MasterDataStatusDateTime",
                                                              request.MasterDataStatusDateTime),
                                           new ParameterValue("Archive", request.Archive),
                                           new ParameterValue("IsLoaded", request.IsLoaded),
                                           new ParameterValue("LoadedDateTime", request.LoadedDateTime),
                                           new ParameterValue("MasterDataUserId",
                                                              String.IsNullOrEmpty(request.MasterDataUserId)
                                                                  ? null
                                                                  : request.MasterDataUserId),
                                           new ParameterValue("SpecialistVerificationUserId",
                                                              String.IsNullOrEmpty(request.SpecialistVerificationUserId)
                                                                  ? null
                                                                  : request.SpecialistVerificationUserId)
                );

            return GetGeneralChangesRequests(new GeneralChangesRequestSearch
                {
                    Id = Convert.ToInt32(dr["Id"]),
                }).FirstOrDefault();
        }

        internal static GeneralChangesRequest Update(GeneralChangesRequest request)
        {
            var dr = DataFacade.GetDataRow("GeneralChangesRequestUpdate",
                                           new ParameterValue("Id", request.Id),
                                           new ParameterValue("RequesterId", request.Requester.RequesterID),
                                           new ParameterValue("DateCreated", request.DateCreated),
                                           new ParameterValue("SpecialistVerificationStatus",
                                                              request.SpecialistVerificationStatus),
                                           new ParameterValue("SpecialistVerificationStatusDateTime",
                                                              request.SpecialistVerificationStatusDateTime),
                                           new ParameterValue("IsApproved", request.IsApproved),
                                           new ParameterValue("SpecialistVerificationComments",
                                                              request.SpecialistVerificationComments),
                                           new ParameterValue("MasterDataComments", request.MasterDataComments),
                                           new ParameterValue("ApprovedDateTime", request.ApprovedDateTime),
                                           new ParameterValue("MasterDataStatus", request.MasterDataStatus),
                                           new ParameterValue("MasterDataStatusDateTime",
                                                              request.MasterDataStatusDateTime),
                                           new ParameterValue("Archive", request.Archive),
                                           new ParameterValue("IsLoaded", request.IsLoaded),
                                           new ParameterValue("LoadedDateTime", request.LoadedDateTime),
                                           new ParameterValue("MasterDataUserId",
                                                              String.IsNullOrEmpty(request.MasterDataUserId)
                                                                  ? null
                                                                  : request.MasterDataUserId),
                                           new ParameterValue("SpecialistVerificationUserId",
                                                              String.IsNullOrEmpty(request.SpecialistVerificationUserId)
                                                                  ? null
                                                                  : request.SpecialistVerificationUserId)
                );

            return GetGeneralChangesRequests(new GeneralChangesRequestSearch
                {
                    Id = (int)dr["Id"],
                }).FirstOrDefault();
        }

        public static void GeneralChangesRequestToggleArchive(string list)
        {
            DataFacade.ExecuteNonQuery("GeneralChangesRequestToggleArchive",
                                       new ParameterValue("requestIdList", list));
        }

        public static DataSet GetGeneralChangesRequestsExport(GeneralChangesRequestSearch requestFilter)
        {
            return DataFacade.GetDataSet("GeneralChangesRequestsExportGet",
                                         new ParameterValue("RequestId", requestFilter.Id),
                                         new ParameterValue("RequesterId",
                                                            requestFilter.Requester == null
                                                                ? -1
                                                                : requestFilter.Requester.RequesterID),
                                         new ParameterValue("RequestDatetimeFrom", requestFilter.DateCreatedFrom),
                                         new ParameterValue("RequestDatetimeTo", requestFilter.DateCreatedTo),
                                         new ParameterValue("SpecialistVerificationStatus", (string)null),
                                         new ParameterValue("MasterDataStatus",
                                                            !String.IsNullOrEmpty(requestFilter.MasterDataStatus)
                                                                ? requestFilter.MasterDataStatus
                                                                : null),
                                         new ParameterValue("RequesterSiteNumber",
                                                            requestFilter.Requester == null ||
                                                            String.IsNullOrEmpty(requestFilter.Requester.SiteNumber)
                                                                ? null
                                                                : requestFilter.Requester.SiteNumber),
                                         new ParameterValue("IncludeArchive", requestFilter.IncludeArchive)
                );
        }

        public static GeneralChangesItem GeneralChangesItemGet(string itemname)
        {
            GeneralChangesItem generalchangesitem = new GeneralChangesItem();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("ItemName", itemname));

            var r = DataFacade.GetDataRow("GeneralChangesItemGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(generalchangesitem, r);
            }
            return generalchangesitem;
        }

        public static GeneralChangesItemGroup GeneralChangesItemGroupGet(string groupname)
        {
            GeneralChangesItemGroup generalchangesitemgroup = new GeneralChangesItemGroup();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("GroupName", groupname));

            var r = DataFacade.GetDataRow("GeneralChangesItemGroupGet",
                                          paramList.ToArray());
            if (r != null)
            {
                PopulateGroup(generalchangesitemgroup, r);
            }
            return generalchangesitemgroup;
        }
        private static GeneralChangesItem Populate(GeneralChangesItem generalchangesitem, DataRow dr)
        {
            if (dr["ItemName"] != DBNull.Value) generalchangesitem.ItemName = dr["ItemName"].ToString();
            return generalchangesitem;
        }

        private static GeneralChangesItemGroup PopulateGroup(GeneralChangesItemGroup generalchangesitemgroup, DataRow dr)
        {
            if (dr["GroupName"] != DBNull.Value) generalchangesitemgroup.GroupName = dr["GroupName"].ToString();
            return generalchangesitemgroup;
        }
    }
}
