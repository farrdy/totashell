using System;
using System.Collections.Generic;
using System.Data;
using Infrastructure.Server.DataAccess;
using Services.DTO;


namespace Services.DataAccess
{
    /// <summary>
    /// ProvinceDao Domain Object
    /// </summary>
    public partial class ProvinceDao
    {

        public static Province ProvinceGet(string prov)
        {
            var province = new Province();
            var paramList = new List<ParameterValue> {new ParameterValue("Province", prov)};

            var r = DataFacade.GetDataRow("ProvinceGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(province, r);
            }
            return province;
        }

        public static void Edit(Province province)
        {
            DataFacade.ExecuteNonQuery("ProvinceEdit",
                                       new ParameterValue("Province", province.Prov)

                );
        }

        public static List<Province> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("ProvinceGetAll",
                                                    paramList.ToArray());

            var returnList = new List<Province>();

            foreach (DataRow r in dataTable.Rows)
            {
                var province = new Province();

                Populate(province, r);

                returnList.Add(province);

            }

            return returnList;
        }

        private static Province Populate(Province province, DataRow dr)
        {
            if (dr["Province"] != DBNull.Value) province.Prov = Convert.ToString(dr["Province"]);

            return province;
        }
    }
}


