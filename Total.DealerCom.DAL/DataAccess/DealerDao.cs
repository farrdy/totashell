using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    public class DealerDao
    {
        public static void Add(Dealer dealer)
        {
            DataFacade.ExecuteNonQuery("DealerInsert",
                                       new ParameterValue("DealerId", dealer.DealerId),
                                       new ParameterValue("DealerName", dealer.DealerName),
                                       new ParameterValue("DealerEmail", dealer.DealerEmail),
                                       new ParameterValue("DealerTelCountry", dealer.DealerTelCountry),
                                       new ParameterValue("DealerTelCode", dealer.DealerTelCode),
                                       new ParameterValue("DealerTelNo", dealer.DealerTelNo),
                                       new ParameterValue("DealerAltTelCountry", dealer.DealerAltTelCountry),
                                       new ParameterValue("DealerAltTelCode", dealer.DealerAltTelCode),
                                       new ParameterValue("DealerAltTelNo", dealer.DealerAltTelNo),
                                       new ParameterValue("DealerFaxCountry", dealer.DealerFaxCountry),
                                       new ParameterValue("DealerFaxCode", dealer.DealerFaxCode),
                                       new ParameterValue("DealerFaxNo", dealer.DealerFaxNo),
                                       new ParameterValue("DealerPostalAddress", dealer.DealerPostalAddress),
                                       new ParameterValue("DealerPostalSuburb", dealer.DealerPostalSuburb),
                                       new ParameterValue("DealerPostalCode", dealer.DealerPostalCode),
                                       new ParameterValue("DealerPhysicalAddress", dealer.DealerPhysicalAddress),
                                       new ParameterValue("DealerPhysicalSuburb", dealer.DealerPhysicalSuburb),
                                       new ParameterValue("DealerPhysicalCode", dealer.DealerPhysicalCode),
                                       new ParameterValue("UpdateDate", dealer.UpdateDate),
                                       new ParameterValue("UpdateUserId", dealer.UpdateUserId)
                );

        }

        public static Dealer GetDealerDetails(string dealerId)
        {
            var d = new Dealer();
            var paramList = new List<ParameterValue>();
            if (dealerId != null)
            {
                paramList.Add(new ParameterValue("DealerId", dealerId));
            }

            var r = DataFacade.GetDataRow("GetDealerDetails",
                                          paramList.ToArray());

            if (r != null)
            {
                d.DealerId = r["DealerId"].ToString();
                d.DealerName = (r["DealerName"].ToString());
                d.DealerEmail = r["DealerEmail"].ToString();
                d.DealerTelCountry = r["DealerTelCountry"].ToString();
                d.DealerTelCode = r["DealerTelCode"].ToString();
                d.DealerTelNo = r["DealerTelNo"].ToString();
                d.DealerAltTelCountry = r["DealerAltTelCountry"].ToString();
                d.DealerAltTelCode = r["DealerAltTelCode"].ToString();
                d.DealerAltTelNo = r["DealerAltTelNo"].ToString();
                d.DealerFaxCountry = r["DealerFaxCountry"].ToString();
                d.DealerFaxCode = r["DealerFaxCode"].ToString();
                d.DealerFaxNo = r["DealerFaxNo"].ToString();
                d.DealerPostalAddress = r["DealerPostalAddress"].ToString();
                d.DealerPostalSuburb = r["DealerPostalSuburb"].ToString();
                d.DealerPostalCode = r["DealerPostalCode"].ToString();
                d.DealerPhysicalAddress = r["DealerPhysicalAddress"].ToString();
                d.DealerPhysicalSuburb = r["DealerPhysicalSuburb"].ToString();
                d.DealerPhysicalCode = r["DealerPhysicalCode"].ToString();
            }


            return d;
        }

        public static void Update(Dealer d)
        {
            DataFacade.ExecuteNonQuery("MainDealerUpdate",
                                       new ParameterValue("DealerId", d.DealerId),
                                       new ParameterValue("DealerName", d.DealerName),
                                       new ParameterValue("DealerEmail", d.DealerEmail),
                                       new ParameterValue("DealerTelCountry", d.DealerTelCountry),
                                       new ParameterValue("DealerTelCode", d.DealerTelCode),
                                       new ParameterValue("DealerTelNo", d.DealerTelNo),
                                       new ParameterValue("DealerAltTelCountry", d.DealerAltTelCountry),
                                       new ParameterValue("DealerAltTelCode", d.DealerAltTelCode),
                                       new ParameterValue("DealerAltTelNo", d.DealerAltTelNo),
                                       new ParameterValue("DealerFaxCountry", d.DealerFaxCountry),
                                       new ParameterValue("DealerFaxCode", d.DealerFaxCode),
                                       new ParameterValue("DealerFaxNo", d.DealerFaxNo),
                                       new ParameterValue("DealerPostalAddress", d.DealerPostalAddress),
                                       new ParameterValue("DealerPostalSuburb", d.DealerPostalSuburb),
                                       new ParameterValue("DealerPostalCode", d.DealerPostalCode),
                                       new ParameterValue("DealerPhysicalAddress", d.DealerPhysicalAddress),
                                       new ParameterValue("DealerPhysicalSuburb", d.DealerPhysicalSuburb),
                                       new ParameterValue("DealerPhysicalCode", d.DealerPhysicalCode),
                                       new ParameterValue("UpdateDate", DateTime.Now),
                                       new ParameterValue("UpdateUserId", d.DealerId)
                );
        }

        public static IEnumerable<Dealer> GetDealerMaster()
        {

            var paramList = new List<ParameterValue>();



            var dataTable = DataFacade.GetDataTable("GetDealerMasterData",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new Dealer
                        {
                            DealerName = (r["DealerName"].ToString()),
                            DealerEmail = r["DealerEmail"].ToString(),
                            DealerTelCountry = r["DealerTelCountry"].ToString(),
                            DealerTelCode = r["DealerTelCode"].ToString(),
                            DealerTelNo = r["DealerTelNo"].ToString(),
                            DealerAltTelCountry = r["DealerAltTelCountry"].ToString(),
                            DealerAltTelCode = r["DealerAltTelCode"].ToString(),
                            DealerAltTelNo = r["DealerAltTelNo"].ToString(),
                            DealerFaxCountry = r["DealerFaxCountry"].ToString(),
                            DealerFaxCode = r["DealerFaxCode"].ToString(),
                            DealerFaxNo = r["DealerFaxNo"].ToString(),
                            DealerPostalAddress = r["DealerPostalAddress"].ToString(),
                            DealerPostalSuburb = r["DealerPostalSuburb"].ToString(),
                            DealerPostalCode = r["DealerPostalCode"].ToString(),
                            DealerPhysicalAddress = r["DealerPhysicalAddress"].ToString(),
                            DealerPhysicalSuburb = r["DealerPhysicalSuburb"].ToString(),
                            DealerPhysicalCode = r["DealerPhysicalCode"].ToString(),
                            UpdateDate = r["UpdateDate"].ToString()
                        }).ToList();
        }

        public static IEnumerable<Dealer> SearchDealerUpdates(Dealer dealer)
        {

            var paramList = new List<ParameterValue>();

            if ((dealer.StartYear == dealer.EndYear) && (dealer.StartMonth == dealer.EndMonth))
            {
                if (dealer.EndMonth == 12)
                {
                    dealer.EndYear++;
                    dealer.EndMonth = 1;
                }
                else
                {
                    dealer.EndMonth++;
                }
            }


            if (dealer.StartYear != null)
            {
                paramList.Add(new ParameterValue("StartYear", dealer.StartYear));
            }
            if (dealer.StartMonth != null)
            {
                paramList.Add(new ParameterValue("StartMonth", dealer.StartMonth));
            }
            if (dealer.EndYear != null)
            {
                paramList.Add(new ParameterValue("EndYear", dealer.EndYear));
            }
            if (dealer.EndMonth != null)
            {
                paramList.Add(new ParameterValue("EndMonth", dealer.EndMonth));
            }


            var dataTable = DataFacade.GetDataTable("SearchDealerUpdates",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new Dealer
                        {
                            DealerId = r["DealerId"].ToString(),
                            DealerName = (r["DealerName"].ToString()),
                            DealerEmail = r["DealerEmail"].ToString(),
                            DealerTelCountry = r["DealerTelCountry"].ToString(),
                            DealerTelCode = r["DealerTelCode"].ToString(),
                            DealerTelNo = r["DealerTelNo"].ToString(),
                            DealerAltTelCountry = r["DealerAltTelCountry"].ToString(),
                            DealerAltTelCode = r["DealerAltTelCode"].ToString(),
                            DealerAltTelNo = r["DealerAltTelNo"].ToString(),
                            DealerFaxCountry = r["DealerFaxCountry"].ToString(),
                            DealerFaxCode = r["DealerFaxCode"].ToString(),
                            DealerFaxNo = r["DealerFaxNo"].ToString(),
                            DealerPostalAddress = r["DealerPostalAddress"].ToString(),
                            DealerPostalSuburb = r["DealerPostalSuburb"].ToString(),
                            DealerPostalCode = r["DealerPostalCode"].ToString(),
                            DealerPhysicalAddress = r["DealerPhysicalAddress"].ToString(),
                            DealerPhysicalSuburb = r["DealerPhysicalSuburb"].ToString(),
                            DealerPhysicalCode = r["DealerPhysicalCode"].ToString(),
                            UpdateDate = r["UpdateDate"].ToString()
                        }).ToList();
        }
    }
}
