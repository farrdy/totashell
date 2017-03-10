using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    class ArticleDao
    {

        public static IEnumerable<Article> Search(ArticleSearch article)
        {
            if ((article.StartYear == article.EndYear) && (article.StartMonth == article.EndMonth))
            {
                if (article.EndMonth == 12)
                {
                    article.EndYear++;
                    article.EndMonth = 1;
                }
                else
                {
                    article.EndMonth++;
                }
            }

            var paramList = new List<ParameterValue>
                                {
                                    new ParameterValue("UserID", article.UserID),
                                    new ParameterValue("Archive", article.Archive ? 1 : 0),
                                   new ParameterValue("DeAct", article.DeAct ? 1 : 0)
                                };
            if (article.IDArticleCat != null)
            {
                paramList.Add(new ParameterValue("idArticleCat", article.IDArticleCat));
            }
            if (article.IDArticleType != null)
            {
                paramList.Add(new ParameterValue("idArticleType", article.IDArticleType));
            }
            if (article.StartYear != null)
            {
                paramList.Add(new ParameterValue("StartYear", article.StartYear));
            }
            if (article.StartMonth != null)
            {
                paramList.Add(new ParameterValue("StartMonth", article.StartMonth));
            }
            if (article.EndYear != null)
            {
                paramList.Add(new ParameterValue("EndYear", article.EndYear));
            }
            if (article.EndMonth != null)
            {
                paramList.Add(new ParameterValue("EndMonth", article.EndMonth));
            }
            if (!String.IsNullOrEmpty(article.Title))
            {
                paramList.Add(new ParameterValue("Title", article.Title));
            }

            var dataTable = DataFacade.GetDataTable("ArticleSearch",
                                                    paramList.ToArray());


            return (from DataRow r in dataTable.Rows
                    select new Article
                        {
                            IdArticle = r["IdArticle"].ToString(), Archive = Convert.ToBoolean(r["Archive"].ToString()), Active = Convert.ToBoolean(r["Active"].ToString()), Title = r["Title"].ToString(), DateArticle = Convert.ToDateTime(r["DateArticle"].ToString()), FileName = r["FileName"].ToString(), IdArticleCat = r["IdArticleCat"].ToString(), ReleaseUserId = r["ReleaseUserId"].ToString()
                        }).ToList();
        }

        public static List<Article> ArticleInbox(ArticleSearch article)
        {
            var paramList = new List<ParameterValue>
                                {
                                    new ParameterValue("UserID", article.UserID),
                                };
            
            var dataTable = DataFacade.GetDataTable("ArticleInbox",
                                                    paramList.ToArray());

            var returnList = (from DataRow r in dataTable.Rows
                              select new Article
                                  {
                                      IdArticle = r["IdArticle"].ToString(), Title = r["Title"].ToString(), DateArticle = Convert.ToDateTime(r["DateArticle"].ToString()), FileName = r["FileName"].ToString(),
                                  }).ToList();


            if (returnList.Count != 0)
            {
                return returnList;
            }
            return null;
        }

        public static void LogArticleView(Article article)
        {
            DataFacade.ExecuteNonQuery("LogAccessInsert",
                                        new ParameterValue("UserID", article.UserId),
                                        new ParameterValue("idArticle", article.IdArticle));
        }

        public static void ArticlesArchive(string articles)
        {
            DataFacade.ExecuteNonQuery("ArticlesArchive",
                                        new ParameterValue("idArticles", articles),
                                        new ParameterValue("Archive", 1));
        }

        public static void ArticlesUnarchive(string articles)
        {
            DataFacade.ExecuteNonQuery("ArticlesArchive",
                                        new ParameterValue("idArticles", articles),
                                        new ParameterValue("Archive", 0));
        }

        public static void ArticlesDelete(string articles)
        {
            DataFacade.ExecuteNonQuery("ArticlesDelete",
                                        new ParameterValue("idArticles", articles));
        }

        public static void ArticlesActivate(string articles)
        {
            DataFacade.ExecuteNonQuery("ArticlesActivate",
                                        new ParameterValue("idArticles", articles),
                                        new ParameterValue("Active", 1));
        }

        public static void ArticlesDeactivate(string articles)
        {
            DataFacade.ExecuteNonQuery("ArticlesActivate",
                                        new ParameterValue("idArticles", articles),
                                        new ParameterValue("Active", 0));
        }

        public static void ArticleAdd(ArticleSearch a)
        {
            DataFacade.ExecuteNonQuery("ArticleEdit",
                                        new ParameterValue("idArticle", 0),
                                        new ParameterValue("Title", a.Title),
                                        new ParameterValue("ReleaseGroup", a.ReleaseGroup),
                                        new ParameterValue("FileName", a.FileName),
                                        new ParameterValue("DateArticle", a.DateArticle),
                                        new ParameterValue("ReleaseUserID", a.ReleaseUserId),
                                        new ParameterValue("idArticleType", a.IDArticleType),
                                        new ParameterValue("idArticleCat", a.IDArticleCat));
        }
    }
}
