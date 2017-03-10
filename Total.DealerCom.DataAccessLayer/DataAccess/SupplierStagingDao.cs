using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    /// <summary>
    /// SupplierStagingDao Domain Object
    /// </summary>
    public partial class SupplierStagingDao
    {

        public static int Add(SupplierStaging supplierstaging)
        {

            var r = DataFacade.GetDataRow("SupplierStagingInsert",

              new ParameterValue("SupplierName", supplierstaging.SupplierName),
              new ParameterValue("Address1", supplierstaging.Address1),
              new ParameterValue("Address2", supplierstaging.Address2),
              new ParameterValue("City", supplierstaging.City),
              new ParameterValue("Province", supplierstaging.Province),
              new ParameterValue("PostalCode", supplierstaging.PostalCode),
              new ParameterValue("Phone", supplierstaging.Phone),
              new ParameterValue("ContactName", supplierstaging.ContactName),
              new ParameterValue("Cellphone", supplierstaging.Cellphone),
              new ParameterValue("VATNo", supplierstaging.VATNo),
              new ParameterValue("Fax", supplierstaging.Fax),
              new ParameterValue("EMail", supplierstaging.EMail),
              new ParameterValue("RequesterID", supplierstaging.RequesterID)
             );
            int SupplierID = Convert.ToInt32(r["SupplierID"]);
            return SupplierID;
        }

        public static int Update(SupplierStaging supplierstaging)
        {
            var r = DataFacade.GetDataRow("SupplierStagingUpdate",
             new ParameterValue("SupplierID", supplierstaging.SupplierID),
              new ParameterValue("SupplierName", supplierstaging.SupplierName),
              new ParameterValue("Address1", supplierstaging.Address1),
              new ParameterValue("Address2", supplierstaging.Address2),
              new ParameterValue("City", supplierstaging.City),
              new ParameterValue("Province", supplierstaging.Province),
              new ParameterValue("PostalCode", supplierstaging.PostalCode),
              new ParameterValue("Phone", supplierstaging.Phone),
              new ParameterValue("ContactName", supplierstaging.ContactName),
              new ParameterValue("Cellphone", supplierstaging.Cellphone),
              new ParameterValue("VATNo", supplierstaging.VATNo),
              new ParameterValue("Fax", supplierstaging.Fax),
              new ParameterValue("EMail", supplierstaging.EMail)
             );

            return Convert.ToInt32(r["SupplierID"]);
        }

        public static List<SupplierStaging> CheckSuppliers(int requesterid)
        {
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("RequesterID", requesterid));

            var returnList = new List<SupplierStaging>();

            var dataTable = DataFacade.GetDataTable("RequesterStagingCheckSuppliers",
                                          paramList.ToArray());

            foreach (DataRow r in dataTable.Rows)
            {
                SupplierStaging supplierstaging = new SupplierStaging();

                Populate(supplierstaging, r);
                returnList.Add(supplierstaging);
            }
            return returnList;
        }

        public static SupplierStaging SupplierStagingGet(int supplierid)
        {
            SupplierStaging supplierstaging = new SupplierStaging();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("SupplierID", supplierid));

            var r = DataFacade.GetDataRow("SupplierStagingGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(supplierstaging, r);
            }
            return supplierstaging;
        }

        public static List<SupplierStaging> SupplierRequesterStagingGet(int requesterid)
        {
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("RequesterID", requesterid));

            var returnList = new List<SupplierStaging>();

            var dataTable = DataFacade.GetDataTable("SupplierRequesterStagingGet",
                                          paramList.ToArray());

            foreach (DataRow r in dataTable.Rows)
            {
                SupplierStaging supplierstaging = new SupplierStaging();

                Populate(supplierstaging, r);
                returnList.Add(supplierstaging);
            }
            return returnList;
        }

        public static List<SupplierStaging> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("SupplierStagingGetAll",
                                                    paramList.ToArray());

            var returnList = new List<SupplierStaging>();

            foreach (DataRow r in dataTable.Rows)
            {
                SupplierStaging supplierstaging = new SupplierStaging();

                Populate(supplierstaging, r);

                returnList.Add(supplierstaging);

            }

            return returnList;
        }

        public static int SaveToFinal(int requesterid, int supplierid)
        {
            var r = DataFacade.GetDataRow("SupplierStagingSaveToFinal",
                                        new ParameterValue("RequesterID", requesterid)
                                        , new ParameterValue("SupplierID", supplierid));
            return Convert.ToInt32(r["SupplierID"]);
        }

        private static SupplierStaging Populate(SupplierStaging supplierstaging, DataRow dr)
        {
            if (dr["SupplierID"] != DBNull.Value) supplierstaging.SupplierID = Convert.ToInt32(dr["SupplierID"]);

            if (dr["SupplierName"] != DBNull.Value) supplierstaging.SupplierName = Convert.ToString(dr["SupplierName"]);

            if (dr["Address1"] != DBNull.Value) supplierstaging.Address1 = Convert.ToString(dr["Address1"]);

            if (dr["Address2"] != DBNull.Value) supplierstaging.Address2 = Convert.ToString(dr["Address2"]);

            if (dr["City"] != DBNull.Value) supplierstaging.City = Convert.ToString(dr["City"]);

            if (dr["Province"] != DBNull.Value) supplierstaging.Province = Convert.ToString(dr["Province"]);

            if (dr["PostalCode"] != DBNull.Value) supplierstaging.PostalCode = Convert.ToInt32(dr["PostalCode"]);

            if (dr["Phone"] != DBNull.Value) supplierstaging.Phone = Convert.ToString(dr["Phone"]);

            if (dr["ContactName"] != DBNull.Value) supplierstaging.ContactName = Convert.ToString(dr["ContactName"]);

            if (dr["Cellphone"] != DBNull.Value) supplierstaging.Cellphone = Convert.ToString(dr["Cellphone"]);

            if (dr["VATNo"] != DBNull.Value) supplierstaging.VATNo = Convert.ToString(dr["VATNo"]);

            if (dr["Fax"] != DBNull.Value) supplierstaging.Fax = Convert.ToString(dr["Fax"]);

            if (dr["EMail"] != DBNull.Value) supplierstaging.EMail = Convert.ToString(dr["EMail"]);

            if (dr["RequesterID"] != DBNull.Value) supplierstaging.RequesterID = Convert.ToInt32(dr["RequesterID"]);

            if (dr["DateCreated"] != DBNull.Value) supplierstaging.DateCreated = Convert.ToDateTime(dr["DateCreated"]);



            return supplierstaging;
        }

    }

}



