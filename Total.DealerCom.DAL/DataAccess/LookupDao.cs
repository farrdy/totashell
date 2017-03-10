using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.DataAccessLayer.DTO;

namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    internal class LookupDao
    {

        public static void Edit(Lookup lookup)
        {
            DataFacade.ExecuteNonQuery("LookupEdit",
                                       new ParameterValue("idLookup", lookup.Id),
                                       new ParameterValue("Lookup", lookup.LookupName),
                                       new ParameterValue("Value", lookup.Value),
                                       new ParameterValue("SortOrder", lookup.SortOrder),
                                       new ParameterValue("Active", lookup.IsActive ? 1 : 0),
                                       new ParameterValue("idParent", lookup.IDParent)
                );
        }

        /// <summary>
        /// Returns a list of lookup values for any given <lookupName></lookupName>
        /// </summary>
        /// <param name="search">The name of the lookup that must be searched for</param>
        /// <returns>List of lookup values</returns>
        public static IEnumerable<Lookup> ReturnLookup(LookupSearch search)
        {
            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("Lookup", search.Lookup),
                    new ParameterValue("ShowInactive", search.ShowInactive ? 1 : 0)
                };
            if (search.IDParent != null)
            {
                paramList.Add(new ParameterValue("idParent", search.IDParent));
            }

            var dataSet = DataFacade.GetDataSet("LookupLoad",
                                                paramList.ToArray());

            var returnList = new List<Lookup>();

            if (dataSet.Tables.Count > 0)
            {
                returnList.AddRange(from DataTable t in dataSet.Tables
                                    from DataRow r in t.Rows
                                    select new Lookup
                                        {
                                            Id = r["idLookup"].ToString(),
                                            IDParent = r["idParent"].ToString(),
                                            LookupName = r["Lookup"].ToString(),
                                            Value = r["Value"].ToString(),
                                            SortOrder = r["SortOrder"].ToString(),
                                            IsActive = Convert.ToBoolean(r["Active"].ToString())
                                        });
            }

            return returnList;

        }


        public static List<UnitOfMeasureType> GetUOMType()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("UOMTypeGetAll",
                                                    paramList.ToArray());

            var returnList = new List<UnitOfMeasureType>();

            foreach (DataRow r in dataTable.Rows)
            {
                var uomtype = new UnitOfMeasureType();

                PopulateUOMType(uomtype, r);

                returnList.Add(uomtype);

            }

            return returnList;
        }

        private static UnitOfMeasureType PopulateUOMType(UnitOfMeasureType uomtype, DataRow dr)
        {
            if (dr["UOMType"] != DBNull.Value) uomtype.UOMType = Convert.ToString(dr["UOMType"]);

            return uomtype;
        }


        public static List<UnitOfMeasure> GetUOM()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("UnitOfMeasureGetAll",
                                                    paramList.ToArray());

            var returnList = new List<UnitOfMeasure>();

            foreach (DataRow r in dataTable.Rows)
            {
                var uom = new UnitOfMeasure();

                PopulateUOM(uom, r);

                returnList.Add(uom);

            }

            return returnList;
        }

        private static UnitOfMeasure PopulateUOM(UnitOfMeasure uom, DataRow dr)
        {
            if (dr["UnitOfMeasure"] != DBNull.Value) uom.UOM = Convert.ToString(dr["UnitOfMeasure"]);

            return uom;
        }

        public static List<Ranging> GetRanging()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("RangingGetAll",
                                                    paramList.ToArray());

            var returnList = new List<Ranging>();

            foreach (DataRow r in dataTable.Rows)
            {
                var range = new Ranging();

                PopulateRanging(range, r);

                returnList.Add(range);

            }

            return returnList;
        }

        private static Ranging PopulateRanging(Ranging ranging, DataRow dr)
        {
            if (dr["Ranging"] != DBNull.Value) ranging.Rang = Convert.ToString(dr["Ranging"]);

            return ranging;
        }
    }
}
