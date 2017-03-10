using System;
using System.Collections.Generic;
using System.Data;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    /// <summary>
    /// RequesterDao Domain Object
    /// </summary>
    public partial class RequesterDao
    {

        public static int Add(Requester requester)
        {

            var r = DataFacade.GetDataRow("RequesterInsert",
                                          new ParameterValue("Motivation", requester.Motivation),
                                          new ParameterValue("SiteName", requester.SiteName),
                                          new ParameterValue("SiteNumber", requester.SiteNumber),
                                          new ParameterValue("EmailAddress", requester.EmailAddress),
                                          new ParameterValue("ContactNo", requester.ContactNo),
                                          new ParameterValue("RequesterName", requester.RequesterName)

                );

            return Convert.ToInt32(r["RequesterID"]);
        }

        public static int Update(Requester requester)
        {

            var r = DataFacade.GetDataRow("RequesterUpdate",
                                          new ParameterValue("RequesterID", requester.RequesterID),
                                          new ParameterValue("Motivation", requester.Motivation),
                                          new ParameterValue("SiteName", requester.SiteName),
                                          new ParameterValue("SiteNumber", requester.SiteNumber),
                                          new ParameterValue("EmailAddress", requester.EmailAddress),
                                          new ParameterValue("ContactNo", requester.ContactNo),
                                          new ParameterValue("RequesterName", requester.RequesterName)

                );

            return Convert.ToInt32(r["RequesterID"]);
        }

        public static Requester RequesterGet(int requesterid)
        {
            var requester = new Requester();
            var paramList = new List<ParameterValue> {new ParameterValue("RequesterID", requesterid)};
            var r = DataFacade.GetDataRow("RequesterGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(requester, r);
            }
            return requester;
        }


        public static List<Requester> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("RequesterGetAll",
                                                    paramList.ToArray());

            var returnList = new List<Requester>();

            foreach (DataRow r in dataTable.Rows)
            {
                var requester = new Requester();

                Populate(requester, r);

                returnList.Add(requester);

            }

            return returnList;
        }



        public static Requester Populate(Requester requester, DataRow dr)
        {
            if (dr["RequesterID"] != DBNull.Value) requester.RequesterID = Convert.ToInt32(dr["RequesterID"]);

            if (dr["RequestDate"] != DBNull.Value) requester.RequestDate = Convert.ToDateTime(dr["RequestDate"]);

            if (dr["Motivation"] != DBNull.Value) requester.Motivation = Convert.ToString(dr["Motivation"]);

            if (dr["SiteName"] != DBNull.Value) requester.SiteName = Convert.ToString(dr["SiteName"]);

            if (dr["SiteNumber"] != DBNull.Value) requester.SiteNumber = Convert.ToString(dr["SiteNumber"]);

            if (dr["EmailAddress"] != DBNull.Value) requester.EmailAddress = Convert.ToString(dr["EmailAddress"]);

            if (dr["ContactNo"] != DBNull.Value) requester.ContactNo = Convert.ToString(dr["ContactNo"]);

            if (dr["RequesterName"] != DBNull.Value) requester.RequesterName = Convert.ToString(dr["RequesterName"]);



            return requester;
        }
    }
}


