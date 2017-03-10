using System;
using System.Collections.Generic;
using System.Data;
using Infrastructure.Server.DataAccess;
using Services.DTO;


namespace Services.DataAccess
{
    /// <summary>
    /// RequesterStagingDao Domain Object
    /// </summary>
    public partial class RequesterStagingDao
    {

        public static int Add(RequesterStaging requesterstaging)
        {

            var r = DataFacade.GetDataRow("RequesterStagingInsert",

                                          new ParameterValue("Motivation", requesterstaging.Motivation),
                                          new ParameterValue("SiteName", requesterstaging.SiteName),
                                          new ParameterValue("SiteNumber", requesterstaging.SiteNumber),
                                          new ParameterValue("EmailAddress", requesterstaging.EmailAddress),
                                          new ParameterValue("ContactNo", requesterstaging.ContactNo),
                                          new ParameterValue("RequesterName", requesterstaging.RequesterName)

                );

            return Convert.ToInt32(r["RequesterID"]);
        }

        public static int Update(RequesterStaging requesterstaging)
        {

            var r = DataFacade.GetDataRow("RequesterStagingUpdate",
                                          new ParameterValue("RequesterID", requesterstaging.RequesterID),
                                          new ParameterValue("Motivation", requesterstaging.Motivation),
                                          new ParameterValue("SiteName", requesterstaging.SiteName),
                                          new ParameterValue("SiteNumber", requesterstaging.SiteNumber),
                                          new ParameterValue("EmailAddress", requesterstaging.EmailAddress),
                                          new ParameterValue("ContactNo", requesterstaging.ContactNo),
                                          new ParameterValue("RequesterName", requesterstaging.RequesterName)

                );

            return Convert.ToInt32(r["RequesterID"]);
        }

        public static RequesterStaging RequesterStagingGet(string sitenumber)
        {
            var requesterstaging = new RequesterStaging();
            var paramList = new List<ParameterValue> { new ParameterValue("SiteNumber", sitenumber) };

            var r = DataFacade.GetDataRow("RequesterStagingGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(requesterstaging, r);
            }
            return requesterstaging;
        }

        public static void Delete(int requesterid)
        {
            DataFacade.ExecuteNonQuery("SupplierStagingDelete",
                                        new ParameterValue("RequesterID", requesterid));
        }

        
        public static List<RequesterStaging> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("RequesterStagingGetAll",
                                                    paramList.ToArray());

            var returnList = new List<RequesterStaging>();

            foreach (DataRow r in dataTable.Rows)
            {
                var requesterstaging = new RequesterStaging();

                Populate(requesterstaging, r);

                returnList.Add(requesterstaging);

            }

            return returnList;
        }

        private static RequesterStaging Populate(RequesterStaging requesterstaging, DataRow dr)
        {
            if (dr["RequesterID"] != DBNull.Value) requesterstaging.RequesterID = Convert.ToInt32(dr["RequesterID"]);

            if (dr["RequestDate"] != DBNull.Value) requesterstaging.RequestDate = Convert.ToDateTime(dr["RequestDate"]);

            if (dr["Motivation"] != DBNull.Value) requesterstaging.Motivation = Convert.ToString(dr["Motivation"]);

            if (dr["SiteName"] != DBNull.Value) requesterstaging.SiteName = Convert.ToString(dr["SiteName"]);

            if (dr["SiteNumber"] != DBNull.Value) requesterstaging.SiteNumber = Convert.ToString(dr["SiteNumber"]);

            if (dr["EmailAddress"] != DBNull.Value)
                requesterstaging.EmailAddress = Convert.ToString(dr["EmailAddress"]);

            if (dr["ContactNo"] != DBNull.Value) requesterstaging.ContactNo = Convert.ToString(dr["ContactNo"]);

            if (dr["RequesterName"] != DBNull.Value)
                requesterstaging.RequesterName = Convert.ToString(dr["RequesterName"]);



            return requesterstaging;
        }
    }
}


