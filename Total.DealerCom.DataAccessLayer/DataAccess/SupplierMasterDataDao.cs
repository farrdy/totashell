using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    /// <summary>
    /// SupplierMasterDataDao Domain Object
    /// </summary>
    public partial class SupplierMasterDataDao
    {

        public static int Add(SupplierMasterData suppliermasterdata)
        {

            var r = DataFacade.GetDataRow("SupplierMasterDataInsert",

                                          new ParameterValue("SupplierID", suppliermasterdata.SupplierID),
                                          new ParameterValue("DateCreated", suppliermasterdata.DateCreated),
                                          new ParameterValue("SupplierSpecialistVerification",
                                                             suppliermasterdata.SupplierSpecialistVerification),
                                          new ParameterValue("SupplierSpecialistVerificationDate",
                                                             suppliermasterdata.SupplierSpecialistVerificationDate),
                                          new ParameterValue("AssignedCategoryManager",
                                                             suppliermasterdata.AssignedCategoryManager),
                                          new ParameterValue("IsApproved", suppliermasterdata.IsApproved),
                                          new ParameterValue("ApprovedDate", suppliermasterdata.ApprovedDate),
                                          new ParameterValue("Comments", suppliermasterdata.Comments),
                                          new ParameterValue("MasterDataStatus", suppliermasterdata.MasterDataStatus),
                                          new ParameterValue("MasterDataStatusDate",
                                                             suppliermasterdata.MasterDataStatusDate),
                                          new ParameterValue("Archive", suppliermasterdata.Archive)

                );

            var supplierMasterDataID = (int)r["SupplierMasterDataID"];
            return supplierMasterDataID;
        }

        public static int Update(SupplierMasterData suppliermasterdata)
        {

            var r = DataFacade.GetDataRow("SupplierMasterDataUpdate",
                                          new ParameterValue("SupplierMasterDataID",
                                                             suppliermasterdata.SupplierMasterDataID),
                                          new ParameterValue("SupplierID", suppliermasterdata.SupplierID),
                                          new ParameterValue("DateCreated", suppliermasterdata.DateCreated),
                                          new ParameterValue("SupplierSpecialistVerification",
                                                             suppliermasterdata.SupplierSpecialistVerification),
                                          new ParameterValue("SupplierSpecialistVerificationDate",
                                                             suppliermasterdata.SupplierSpecialistVerificationDate),
                                          new ParameterValue("AssignedCategoryManager",
                                                             suppliermasterdata.AssignedCategoryManager),
                                          new ParameterValue("IsApproved", suppliermasterdata.IsApproved),
                                          new ParameterValue("ApprovedDate", suppliermasterdata.ApprovedDate),
                                          new ParameterValue("Comments", suppliermasterdata.Comments),
                                          new ParameterValue("MasterDataStatus", suppliermasterdata.MasterDataStatus),
                                          new ParameterValue("MasterDataStatusDate",
                                                             suppliermasterdata.MasterDataStatusDate),
                                          new ParameterValue("Archive", suppliermasterdata.Archive)

                );

            var supplierMasterDataID = (int)r["SupplierMasterDataID"];
            return supplierMasterDataID;
        }

        public static SupplierMasterData SupplierMasterDataGet(int suppliermasterdataid)
        {
            var suppliermasterdata = new SupplierMasterData();
            var paramList = new List<ParameterValue> { new ParameterValue("SupplierMasterDataID", suppliermasterdataid) };
            var r = DataFacade.GetDataRow("SupplierMasterDataGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(suppliermasterdata, r);
            }
            return suppliermasterdata;
        }

        public static List<SupplierMasterData> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("SupplierMasterDataGetAll",
                                                    paramList.ToArray());

            var returnList = new List<SupplierMasterData>();

            foreach (DataRow r in dataTable.Rows)
            {
                var suppliermasterdata = new SupplierMasterData();

                Populate(suppliermasterdata, r);

                returnList.Add(suppliermasterdata);

            }

            return returnList;
        }

        public static SupplierMasterData Populate(SupplierMasterData suppliermasterdata, DataRow dr)
        {
            if (dr["SupplierMasterDataID"] != DBNull.Value)
                suppliermasterdata.SupplierMasterDataID = Convert.ToInt32(dr["SupplierMasterDataID"]);

            if (dr["SupplierID"] != DBNull.Value) suppliermasterdata.SupplierID = Convert.ToInt32(dr["SupplierID"]);

            if (dr["DateCreated"] != DBNull.Value)
                suppliermasterdata.DateCreated = Convert.ToDateTime(dr["DateCreated"]);

            if (dr["SupplierSpecialistVerification"] != DBNull.Value)
                suppliermasterdata.SupplierSpecialistVerification =
                    Convert.ToString(dr["SupplierSpecialistVerification"]);

            if (dr["SupplierSpecialistVerificationDate"] != DBNull.Value)
                suppliermasterdata.SupplierSpecialistVerificationDate =
                    Convert.ToDateTime(dr["SupplierSpecialistVerificationDate"]);

            if (dr["AssignedCategoryManager"] != DBNull.Value)
                suppliermasterdata.AssignedCategoryManager = Convert.ToString(dr["AssignedCategoryManager"]);

            if (dr["IsApproved"] != DBNull.Value) suppliermasterdata.IsApproved = Convert.ToBoolean(dr["IsApproved"]);

            if (dr["ApprovedDate"] != DBNull.Value)
                suppliermasterdata.ApprovedDate = Convert.ToDateTime(dr["ApprovedDate"]);

            if (dr["Comments"] != DBNull.Value) suppliermasterdata.Comments = Convert.ToString(dr["Comments"]);

            if (dr["MasterDataStatus"] != DBNull.Value)
                suppliermasterdata.MasterDataStatus = Convert.ToString(dr["MasterDataStatus"]);

            if (dr["MasterDataStatusDate"] != DBNull.Value)
                suppliermasterdata.MasterDataStatusDate = Convert.ToDateTime(dr["MasterDataStatusDate"]);

            if (dr["Archive"] != DBNull.Value) suppliermasterdata.Archive = Convert.ToBoolean(dr["Archive"]);



            return suppliermasterdata;
        }

        public static IEnumerable<SupplierSearch> Search(SupplierSearch suppliersearch)
        {
            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("StartDate", suppliersearch.StartDate),
                    new ParameterValue("EndDate", suppliersearch.EndDate),
                    new ParameterValue("Archive", suppliersearch.Supplier.Archive ? 1 : 0)
                };

            if (!String.IsNullOrEmpty(suppliersearch.Supplier.SupplierName))
            {
                paramList.Add(new ParameterValue("SupplierName", suppliersearch.Supplier.SupplierName));
            }
            if (!String.IsNullOrEmpty(suppliersearch.Supplier.MasterDataStatus))
            {
                paramList.Add(new ParameterValue("MasterDataStatus", suppliersearch.Supplier.MasterDataStatus));
            }
            if (!String.IsNullOrEmpty(suppliersearch.Supplier.Province))
            {
                paramList.Add(new ParameterValue("Province", suppliersearch.Supplier.Province));
            }
            if (!String.IsNullOrEmpty(suppliersearch.Requester.RequesterName))
            {
                paramList.Add(new ParameterValue("RequesterName", suppliersearch.Requester.RequesterName));
            }

            var dataTable = DataFacade.GetDataTable("SupplierMasterDataSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new SupplierSearch
                        {
                            Supplier = new Supplier
                            {
                                SupplierName = r["SupplierName"].ToString(),
                                Province = r["Province"].ToString(),
                                SupplierSpecialistStatus = r["SupplierSpecialistStatus"].ToString(),
                                CategoryManager = r["AssignedCategoryManager"].ToString(),
                                MasterDataComment = r["MasterDataComment"].ToString(),
                                MasterDataStatusDate = (DateTime)r["MasterDataStatusDate"],
                                MasterDataStatus = r["MasterDataStatus"].ToString(),
                                RequesterID = (int)r["RequesterID"],
                                SupplierID = (int)r["SupplierID"]
                            },
                            Requester = new Requester
                            {
                                RequestDate = (DateTime)r["RequestDate"],
                                Motivation = r["Motivation"].ToString(),
                                RequesterName = r["RequesterName"].ToString(),
                            }

                        }).ToList();
        }

        public static void SupplierMasterDataArchive(string suppliersasterdata)
        {
            DataFacade.ExecuteNonQuery("SupplierMasterDataArchive",
                                       new ParameterValue("SupplierMasterDataID", suppliersasterdata),
                                       new ParameterValue("Archive", 1));
        }
    }
}


