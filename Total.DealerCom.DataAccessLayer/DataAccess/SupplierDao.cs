using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;
using System.Linq;


namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    /// <summary>
    /// SupplierDao Domain Object
    /// </summary>
    public partial class SupplierDao
    {

        public static int Add(Supplier supplier)
        {

            var r = DataFacade.GetDataRow("SupplierInsert",
                new ParameterValue("SupplierName", supplier.SupplierName),
              new ParameterValue("Address1", supplier.Address1),
              new ParameterValue("Address2", supplier.Address2),
              new ParameterValue("City", supplier.City),
              new ParameterValue("Province", supplier.Province),
              new ParameterValue("PostalCode", supplier.PostalCode),
              new ParameterValue("Phone", supplier.Phone),
              new ParameterValue("ContactName", supplier.ContactName),
              new ParameterValue("Cellphone", supplier.Cellphone),
              new ParameterValue("VATNo", supplier.VATNo),
              new ParameterValue("Fax", supplier.Fax),
              new ParameterValue("EMail", supplier.EMail),
              new ParameterValue("RequesterID", supplier.RequesterID),
              new ParameterValue("SupplierSpecialistStatus", supplier.SupplierSpecialistStatus),
              new ParameterValue("SupplierSpecialistDate", supplier.SupplierSpecialistDate),
              new ParameterValue("SupplierSpecialistComment", supplier.SupplierSpecialistComment),
              new ParameterValue("CategoryManagerStatus", supplier.CategoryManagerStatus),
              new ParameterValue("CategoryManagerDate", supplier.CategoryManagerDate),
              new ParameterValue("CategoryManager", supplier.CategoryManager),
              new ParameterValue("CategoryManagerComment", supplier.CategoryManagerComment),
              new ParameterValue("MasterDataComment", supplier.MasterDataComment),
              new ParameterValue("MasterDataStatus", supplier.MasterDataStatus),
              new ParameterValue("MasterDataStatusDate", supplier.MasterDataStatusDate),
             new ParameterValue("Archive", supplier.Archive)

             );

            int SupplierID = Convert.ToInt32(r["SupplierID"]);
            return SupplierID;
        }

        public static int Update(Supplier supplier)
        {

            var r = DataFacade.GetDataRow("SupplierUpdate",
            new ParameterValue("SupplierID", supplier.SupplierID),
              new ParameterValue("SupplierName", supplier.SupplierName),
              new ParameterValue("Address1", supplier.Address1),
              new ParameterValue("Address2", supplier.Address2),
              new ParameterValue("City", supplier.City),
              new ParameterValue("Province", supplier.Province),
              new ParameterValue("PostalCode", supplier.PostalCode),
              new ParameterValue("Phone", supplier.Phone),
              new ParameterValue("ContactName", supplier.ContactName),
              new ParameterValue("Cellphone", supplier.Cellphone),
              new ParameterValue("VATNo", supplier.VATNo),
              new ParameterValue("Fax", supplier.Fax),
              new ParameterValue("EMail", supplier.EMail),
              new ParameterValue("RequesterID", supplier.RequesterID),
             new ParameterValue("SupplierSpecialistStatus", supplier.SupplierSpecialistStatus),
              new ParameterValue("SupplierSpecialistDate", supplier.SupplierSpecialistDate),
              new ParameterValue("SupplierSpecialistComment", supplier.SupplierSpecialistComment),
              new ParameterValue("CategoryManagerStatus", supplier.CategoryManagerStatus),
              new ParameterValue("CategoryManagerDate", supplier.CategoryManagerDate),
              new ParameterValue("CategoryManager", supplier.CategoryManager),
              new ParameterValue("CategoryManagerComment", supplier.CategoryManagerComment),
              new ParameterValue("MasterDataComment", supplier.MasterDataComment),
              new ParameterValue("MasterDataStatus", supplier.MasterDataStatus),
              new ParameterValue("MasterDataStatusDate", supplier.MasterDataStatusDate),
             new ParameterValue("Archive", supplier.Archive)

             );

            int SupplierID = Convert.ToInt32(r["SupplierID"]);
            return SupplierID;
        }

        public static Supplier SupplierGet(int supplierid)
        {
            Supplier supplier = new Supplier();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("SupplierID", supplierid));

            var r = DataFacade.GetDataRow("SupplierGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(supplier, r);
            }
            return supplier;
        }

        public static DataSet ExportToExcel(SupplierSearch suppliersearch)
        {

            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("StartDate", suppliersearch.StartDate),
                    new ParameterValue("EndDate", suppliersearch.EndDate),
                    new ParameterValue("Archive", suppliersearch.Supplier.Archive ? 1 : 0)
                };

            if (!String.IsNullOrEmpty(suppliersearch.Requester.RequesterID.ToString()))
            {
                paramList.Add(new ParameterValue("RequesterID", suppliersearch.Requester.RequesterID));
            }

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
            return DataFacade.GetDataSet("SupplierExcelSearch", paramList.ToArray());
        }

        public static DataSet SupplierProductSearch(SupplierSearch suppliersearch)
        {

            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("StartDate", suppliersearch.StartDate),
                    new ParameterValue("EndDate", suppliersearch.EndDate),
                    new ParameterValue("Archive", suppliersearch.Supplier.Archive ? 1 : 0)
                };

            if (!String.IsNullOrEmpty(suppliersearch.Requester.RequesterID.ToString()))
            {
                paramList.Add(new ParameterValue("RequesterID", suppliersearch.Requester.RequesterID));
            }

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
            return DataFacade.GetDataSet("SupplierProductSearch", paramList.ToArray());
        }


        public static List<Supplier> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("SupplierGetAll",
                                                    paramList.ToArray());

            var returnList = new List<Supplier>();

            foreach (DataRow r in dataTable.Rows)
            {
                Supplier supplier = new Supplier();

                Populate(supplier, r);

                returnList.Add(supplier);

            }

            return returnList;
        }

        public static IEnumerable<SupplierSearch> Search(SupplierSearch suppliersearch)
        {
            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("StartDate", suppliersearch.StartDate),
                    new ParameterValue("EndDate", suppliersearch.EndDate),
                    new ParameterValue("Archive", suppliersearch.Supplier.Archive ? 1 : 0)
                };

            if (!String.IsNullOrEmpty(suppliersearch.Requester.RequesterID.ToString()))
            {
                paramList.Add(new ParameterValue("RequesterID", suppliersearch.Requester.RequesterID));
            }

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

            var dataTable = DataFacade.GetDataTable("SupplierSearch",
                                                    paramList.ToArray());

           //null approved date
            DateTime? nullDate;
            nullDate = null;

            return (from DataRow r in dataTable.Rows
                    select new SupplierSearch
                    {
                        Supplier = new Supplier
                        {
                            SupplierName = r["SupplierName"].ToString(),
                            Province = r["Province"].ToString(),
                            SupplierSpecialistStatus = r["SupplierSpecialistStatus"].ToString(),
                            CategoryManager = r["CategoryManager"].ToString(),
                            MasterDataComment = r["MasterDataComment"].ToString(),
                            MasterDataStatusDate = !String.IsNullOrEmpty(r["MasterDataStatusDate"].ToString()) ? Convert.ToDateTime(r["MasterDataStatusDate"]) : nullDate,
                            MasterDataStatus = r["MasterDataStatus"].ToString(),
                            CategoryManagerStatus = r["CategoryManagerStatus"].ToString(),
                            SupplierID = (int)r["SupplierID"],
                            Archive = Convert.ToBoolean(r["Archive"].ToString())
                        },
                        Requester = new Requester
                        {
                            RequestDate = Convert.ToDateTime(r["RequestDate"]),
                            Motivation = r["Motivation"].ToString(),
                            RequesterName = r["RequesterName"].ToString(),
                            RequesterID = (int)r["RequesterID"],
                            ContactNo = r["ContactNo"].ToString(),
                            EmailAddress = r["EmailAddress"].ToString(),
                            SiteName = r["SiteName"].ToString(),
                            SiteNumber = r["SiteNumber"].ToString()

                        }

                    }).ToList();
        }

        public static void SupplierArchive(string suppliersid, bool archive)
        {
            DataFacade.ExecuteNonQuery("SupplierArchive",
                                       new ParameterValue("SuppliersID", suppliersid),
                                       new ParameterValue("Archive", archive));
        }


        public static IEnumerable<SupplierRequest> GetSupplierRequests(SupplierRequest suppliersearch)
        {
            var paramList = new List<ParameterValue>();
                
            if (!String.IsNullOrEmpty(suppliersearch.RequesterID.ToString()))
            {
                paramList.Add(new ParameterValue("RequesterID", suppliersearch.RequesterID));
            }

           var dataSet = DataFacade.GetDataSet("SupplierRequestGet", paramList.ToArray());

            var returnList = new List<SupplierRequest>();

            foreach (var requestItem in dataSet.Tables["Table"].Rows.Cast<DataRow>().Select(x => new SupplierRequest
            {
                Requester =
                    dataSet.Tables["Table1"].Rows.Cast<DataRow>().Where(
                        y => (int)y["RequesterID"] == (int)x["RequesterID"]).Select(
                            y => new Requester
                            {
                                RequesterID = Convert.ToInt32(y["RequesterID"]),
                                RequestDate = Convert.ToDateTime(y["RequestDate"]),
                                SiteName = y["SiteName"].ToString(),
                                SiteNumber = y["SiteNumber"].ToString(),
                                EmailAddress = y["EmailAddress"].ToString(),
                                ContactNo = y["ContactNo"].ToString(),
                                RequesterName = y["RequesterName"].ToString()
                            }).FirstOrDefault(),
                   Supplier =
                        dataSet.Tables["Table2"].Rows.Cast<DataRow>().Where(
                        y => (int)y["RequesterID"] == (int)x["RequesterID"]).Select(
                        y => new Supplier
                        {
                            SupplierID = (int)y["SupplierID"],
                            SupplierName = y["SupplierName"].ToString(),
                            Address1 = y["Address1"].ToString(),
                            Address2 = y["Address2"].ToString(),
                            City = y["City"].ToString(),
                            Province = y["Province"].ToString(),
                            PostalCode = Convert.ToInt32(y["PostalCode"]),
                            Phone = y["Phone"].ToString(),
                            ContactName = y["ContactName"].ToString(),
                            Cellphone = y["Cellphone"].ToString(),
                            VATNo = y["VATNo"].ToString(),
                            Fax = y["Fax"].ToString(),
                            EMail = y["EMail"].ToString()
                        }).FirstOrDefault()
            }))
            {
                requestItem.SupplierProduct =
                    dataSet.Tables["Table3"].Rows.Cast<DataRow>().Where(
                        x => (int)x["SupplierID"] == requestItem.Supplier.SupplierID).Select(x => new SupplierProduct
                        {
                            SupplierID = (int)x["SupplierID"],
                            RetailBarcode = x["RetailBarcode"].ToString(),
                            RetailPackSize = x["RetailPackSize"].ToString(),
                            Ranging = x["Ranging"].ToString(),
                            OuterCaseCode = x["OuterCaseCode"].ToString(),
                            PackBarcode = x["PackBarcode"].ToString(),
                            ProductCode = x["ProductCode"].ToString(),
                            ProductDescription = x["ProductDescription"].ToString(),
                            ISISRetailItemNaming = x["ISISRetailItemNaming"].ToString(),
                            Category = x["Category"].ToString(),
                            Brand = x["Brand"].ToString(),
                            UOMType = x["UOMType"].ToString(),
                            PackSizeCase = Convert.ToInt32(x["PackSizeCase"]),
                            CaseCost = Convert.ToDecimal(x["CaseCost"]),
                            Cost = Convert.ToDecimal(x["Cost"])
                        })
                        .ToList();

                returnList.Add(requestItem);
            }

            return returnList;
        }

        private static Supplier Populate(Supplier supplier, DataRow dr)
        {
            if (dr["SupplierID"] != DBNull.Value) supplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);

            if (dr["SupplierName"] != DBNull.Value) supplier.SupplierName = Convert.ToString(dr["SupplierName"]);

            if (dr["Address1"] != DBNull.Value) supplier.Address1 = Convert.ToString(dr["Address1"]);

            if (dr["Address2"] != DBNull.Value) supplier.Address2 = Convert.ToString(dr["Address2"]);

            if (dr["City"] != DBNull.Value) supplier.City = Convert.ToString(dr["City"]);

            if (dr["Province"] != DBNull.Value) supplier.Province = Convert.ToString(dr["Province"]);

            if (dr["PostalCode"] != DBNull.Value) supplier.PostalCode = Convert.ToInt32(dr["PostalCode"]);

            if (dr["Phone"] != DBNull.Value) supplier.Phone = Convert.ToString(dr["Phone"]);

            if (dr["ContactName"] != DBNull.Value) supplier.ContactName = Convert.ToString(dr["ContactName"]);

            if (dr["Cellphone"] != DBNull.Value) supplier.Cellphone = Convert.ToString(dr["Cellphone"]);

            if (dr["VATNo"] != DBNull.Value) supplier.VATNo = Convert.ToString(dr["VATNo"]);

            if (dr["Fax"] != DBNull.Value) supplier.Fax = Convert.ToString(dr["Fax"]);

            if (dr["EMail"] != DBNull.Value) supplier.EMail = Convert.ToString(dr["EMail"]);

            if (dr["RequesterID"] != DBNull.Value) supplier.RequesterID = Convert.ToInt32(dr["RequesterID"]);

            if (dr["DateCreated"] != DBNull.Value) supplier.DateCreated = Convert.ToDateTime(dr["DateCreated"]);

            if (dr["SupplierSpecialistStatus"] != DBNull.Value) supplier.SupplierSpecialistStatus = Convert.ToString(dr["SupplierSpecialistStatus"]);

            if (dr["SupplierSpecialistDate"] != DBNull.Value) supplier.SupplierSpecialistDate = Convert.ToDateTime(dr["SupplierSpecialistDate"]);

            if (dr["SupplierSpecialistComment"] != DBNull.Value) supplier.SupplierSpecialistComment = Convert.ToString(dr["SupplierSpecialistComment"]);

            if (dr["CategoryManagerStatus"] != DBNull.Value) supplier.CategoryManagerStatus = Convert.ToString(dr["CategoryManagerStatus"]);

            if (dr["CategoryManagerDate"] != DBNull.Value) supplier.CategoryManagerDate = Convert.ToDateTime(dr["CategoryManagerDate"]);

            if (dr["CategoryManager"] != DBNull.Value) supplier.CategoryManager = Convert.ToString(dr["CategoryManager"]);

            if (dr["CategoryManagerComment"] != DBNull.Value) supplier.CategoryManagerComment = Convert.ToString(dr["CategoryManagerComment"]);

            if (dr["MasterDataComment"] != DBNull.Value) supplier.MasterDataComment = Convert.ToString(dr["MasterDataComment"]);

            if (dr["MasterDataStatus"] != DBNull.Value) supplier.MasterDataStatus = Convert.ToString(dr["MasterDataStatus"]);

            if (dr["MasterDataStatusDate"] != DBNull.Value) supplier.MasterDataStatusDate = Convert.ToDateTime(dr["MasterDataStatusDate"]);

            if (dr["Archive"] != DBNull.Value) supplier.Archive = Convert.ToBoolean(dr["Archive"]);

            return supplier;
        }

    }

}



