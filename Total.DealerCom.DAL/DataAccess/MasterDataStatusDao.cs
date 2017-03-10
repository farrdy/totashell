using System;
using System.Collections.Generic;
using System.Data;
using Infrastructure.Server.DataAccess;
using Services.DTO;


namespace Services.DataAccess
{
    /// <summary>
    /// MasterDataStatusDao Domain Object
    /// </summary>
    public partial class MasterDataStatusDao
    {

        public static MasterDataStatus MasterDataStatusGet(string status)
        {
            var masterdatastatus = new MasterDataStatus();
            var paramList = new List<ParameterValue> {new ParameterValue("Status", status)};

            var r = DataFacade.GetDataRow("MasterDataStatusGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(masterdatastatus, r);
            }
            return masterdatastatus;
        }


        public static List<MasterDataStatus> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("MasterDataStatusGetAll",
                                                    paramList.ToArray());

            var returnList = new List<MasterDataStatus>();

            foreach (DataRow r in dataTable.Rows)
            {
                var masterdatastatus = new MasterDataStatus();

                Populate(masterdatastatus, r);

                returnList.Add(masterdatastatus);

            }

            return returnList;
        }

        private static MasterDataStatus Populate(MasterDataStatus masterdatastatus, DataRow dr)
        {
            if (dr["Status"] != DBNull.Value) masterdatastatus.Status = Convert.ToString(dr["Status"]);
            return masterdatastatus;
        }
    }
}


