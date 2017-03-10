using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    public class FAQDao
    {
        public static string Add(FAQ faq)
        {

            var r = DataFacade.GetDataRow("FAQInsert",
                                          new ParameterValue("Question", faq.Question),
                                          new ParameterValue("QuestionDateCreated", faq.QuestionDateCreated),
                                          new ParameterValue("Status", faq.Status.ToString()),
                                          new ParameterValue("QuestionUserId", faq.QuestionUserId)
                );

            return r["QuestionId"].ToString();
        }


        public static FAQ GetFAQ(int questionId)
        {
            var f = new FAQ();
            var paramList = new List<ParameterValue> {new ParameterValue("QuestionId", questionId)};

            var r = DataFacade.GetDataRow("GetFAQ",
                                          paramList.ToArray());

            if (r != null)
            {
                f.QuestionId = r["QuestionId"].ToString();

                f.Question = r["Question"].ToString();
                f.QuestionDateCreated = Convert.ToDateTime(r["DateCreated"].ToString());
                f.QuestionUserId = r["UserId"].ToString();
                f.Status = Convert.ToBoolean(r["Status"].ToString());
                f.AnswerId = r["AnswerId"].ToString();
                f.Answer = r["Answer"].ToString();
                if (!String.IsNullOrEmpty(r["DateAnswered"].ToString()))
                    f.DateAnswered = Convert.ToDateTime(r["DateAnswered"].ToString());
                else
                    f.DateAnswered = null;
                f.UserAnswerId = r["UserAnsweredId"].ToString();
            }


            return f;
        }


        public static string FAQUpdate(FAQ faq)
        {

            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(faq.QuestionId))
            {
                paramList.Add(new ParameterValue("QuestionId", faq.QuestionId));
            }
            if (!string.IsNullOrEmpty(faq.Question))
            {
                paramList.Add(new ParameterValue("Question", faq.Question));
            }
            if (!string.IsNullOrEmpty(faq.AnswerId))
            {
                paramList.Add(new ParameterValue("AnswerId", faq.AnswerId));
            }
            if (!string.IsNullOrEmpty(faq.Answer))
            {
                paramList.Add(new ParameterValue("Answer", faq.Answer));
            }
            if (!string.IsNullOrEmpty(faq.DateAnswered.ToString()))
            {
                paramList.Add(new ParameterValue("DateAnswered", faq.DateAnswered));
            }
            if (!string.IsNullOrEmpty(faq.UserAnswerId))
            {
                paramList.Add(new ParameterValue("AnswerUserId", faq.UserAnswerId));
            }
            if (!string.IsNullOrEmpty(faq.Status.ToString()))
            {
                paramList.Add(new ParameterValue("Status", faq.Status.ToString()));
            }

            DataRow r = DataFacade.GetDataRow("FAQEdit", paramList.ToArray());

            return r[0].ToString();
        }

        public static FAQ LoadFAQ(FAQ faq, DataRow r)
        {
            if (r["QuestionId"] != DBNull.Value) faq.QuestionId = r["QuestionId"].ToString();
            faq.Question = r["Question"].ToString();
            faq.QuestionDateCreated = Convert.ToDateTime(r["DateCreated"].ToString());
            faq.QuestionUserId = r["UserId"].ToString();
            faq.Status = Convert.ToBoolean(r["Status"].ToString());
            faq.AnswerId = r["AnswerId"].ToString();
            faq.Answer = r["Answer"].ToString();
            faq.DateAnswered = Convert.ToDateTime(r["DateAnswered"].ToString());

            faq.UserAnswerId = r["UserAnsweredId"].ToString();

            return faq;

        }

        public static IEnumerable<FAQ> GetDetails()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("GetFAQDetails",
                                                    paramList.ToArray());

            var returnList = new List<FAQ>();

            foreach (DataRow r in dataTable.Rows)
            {
                var l = new FAQ();

                Populate(l, r);

                returnList.Add(l);

            }

            return returnList;
        }

        public static FAQ Populate(FAQ faq, DataRow dr)
        {
            faq.QuestionId = (dr["QuestionId"].ToString());
            faq.Question = dr["Question"].ToString();
            faq.QuestionDateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
            faq.QuestionUserId = dr["UserId"].ToString();
            faq.Status = Convert.ToBoolean(dr["Status"].ToString());
            faq.AnswerId = dr["AnswerId"].ToString();
            faq.Answer = dr["Answer"].ToString();
            faq.DateAnswered = Convert.ToDateTime(dr["DateAnswered"].ToString());
            faq.UserAnswerId = dr["UserAnsweredId"].ToString();

            return faq;
        }

        public static IEnumerable<FAQ> GetAllDetails()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("GetFAQAllDetails",
                                                    paramList.ToArray());

            var returnList = new List<FAQ>();

            foreach (DataRow r in dataTable.Rows)
            {
                var l = new FAQ
                    {
                        QuestionId = (r["QuestionId"].ToString()),
                        Question = r["Question"].ToString(),
                        QuestionDateCreated = Convert.ToDateTime(r["DateCreated"].ToString()),
                        QuestionUserId = r["UserId"].ToString(),
                        Status = Convert.ToBoolean(r["Status"].ToString()),
                        AnswerId = r["AnswerId"].ToString(),
                        Answer = r["Answer"].ToString()
                    };
                if (!String.IsNullOrEmpty(r["DateAnswered"].ToString()))
                    l.DateAnswered = Convert.ToDateTime(r["DateAnswered"].ToString());
                else
                {
                    l.DateAnswered = null;
                }

                l.UserAnswerId = r["UserAnsweredId"].ToString();

                returnList.Add(l);

            }

            return returnList;
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
