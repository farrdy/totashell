using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    internal class LogDao
    {
        public static IEnumerable<LogEntry> Search(LogEntry log)
        {

            var paramList = new List<ParameterValue>();


            if (log.IDArticleCat != null)
            {
                paramList.Add(new ParameterValue("idArticleCat", log.IDArticleCat));
            }
            if (log.IDArticleType != null)
            {
                paramList.Add(new ParameterValue("idArticleType", log.IDArticleType));
            }
            if (!String.IsNullOrEmpty(log.UserId))
            {
                paramList.Add(new ParameterValue("UserID", log.UserId));
            }
            if (!String.IsNullOrEmpty(log.UserName))
            {
                paramList.Add(new ParameterValue("Name", log.UserName));
            }
            if (log.StartYear != null)
            {
                paramList.Add(new ParameterValue("StartYear", log.StartYear));
            }
            if (log.StartMonth != null)
            {
                paramList.Add(new ParameterValue("StartMonth", log.StartMonth));
            }
            if (log.EndYear != null)
            {
                paramList.Add(new ParameterValue("EndYear", log.EndYear));
            }
            if (log.EndMonth != null)
            {
                paramList.Add(new ParameterValue("EndMonth", log.EndMonth));
            }
            if (!String.IsNullOrEmpty(log.Title))
            {
                paramList.Add(new ParameterValue("Title", log.Title));
            }
            if (!String.IsNullOrEmpty(log.IDRole))
            {
                paramList.Add(new ParameterValue("idRole", log.IDRole));
            }

            var dataTable = DataFacade.GetDataTable("LogAccessSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new LogEntry
                        {
                            LogDate = (r["LogDate"].ToString()),
                            UserId = r["UserID"].ToString(),
                            Title = r["Title"].ToString(),
                            UserName = r["Name"].ToString(),
                            ArticleType = (r["ArticleType"].ToString()),
                            ArticleCat = (r["ArticleCat"].ToString())
                        }).ToList();
        }

        public static IEnumerable<LogEntry> LoginSearch(LogEntry log)
        {

            var paramList = new List<ParameterValue>();

            if ((log.StartYear == log.EndYear) && (log.StartMonth == log.EndMonth))
            {
                if (log.EndMonth == 12)
                {
                    log.EndYear++;
                    log.EndMonth = 1;
                }
                else
                {
                    log.EndMonth++;
                }
            }

            if (!String.IsNullOrEmpty(log.UserId))
            {
                paramList.Add(new ParameterValue("UserID", log.UserId));
            }
            if (!String.IsNullOrEmpty(log.UserName))
            {
                paramList.Add(new ParameterValue("Name", log.UserName));
            }
            if (log.StartYear != null)
            {
                paramList.Add(new ParameterValue("StartYear", log.StartYear));
            }
            if (log.StartMonth != null)
            {
                paramList.Add(new ParameterValue("StartMonth", log.StartMonth));
            }
            if (log.EndYear != null)
            {
                paramList.Add(new ParameterValue("EndYear", log.EndYear));
            }
            if (log.EndMonth != null)
            {
                paramList.Add(new ParameterValue("EndMonth", log.EndMonth));
            }


            var dataTable = DataFacade.GetDataTable("LogLoginSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new LogEntry
                        {
                            UserId = r["UserID"].ToString(),
                            LastLogin = (r["LastLogin"].ToString()),
                            UserName = r["Name"].ToString(),
                            LoginCount = Convert.ToInt32(r["LoginCount"].ToString())
                        }).ToList();
        }
    }
}
