using System;
using System.Collections.Generic;
using System.Data;
using Infrastructure.Server.DataAccess;
using Services.DTO;


namespace Services.DataAccess
{
    /// <summary>
    /// RangingDao Domain Object
    /// </summary>
    public partial class RangingDao
    {

        public static Ranging RangingGet(string rang)
        {
            var ranging = new Ranging();
            var paramList = new List<ParameterValue> {new ParameterValue("Ranging", rang)};

            var r = DataFacade.GetDataRow("RangingGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(ranging, r);
            }
            return ranging;
        }

        public static List<Ranging> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("RangingGetAll",
                                                    paramList.ToArray());

            var returnList = new List<Ranging>();

            foreach (DataRow r in dataTable.Rows)
            {
                var ranging = new Ranging();

                Populate(ranging, r);

                returnList.Add(ranging);

            }

            return returnList;
        }

        private static Ranging Populate(Ranging ranging, DataRow dr)
        {
            if (dr["Ranging"] != DBNull.Value) ranging.Rang = Convert.ToString(dr["Ranging"]);
            return ranging;
        }
    }
}


