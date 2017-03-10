﻿using System.Collections.Generic;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    public class ArticleFacade : IArticleFacade
    {
        #region IFacadeFactory Members

        public IEnumerable<Article> Search(ArticleSearch param)
        {
            return ArticleDao.Search(param);
        }

        public List<Article> ArticleInbox(ArticleSearch param)
        {
            return ArticleDao.ArticleInbox(param);
        }

        public void LogArticleView(Article article)
        {
            ArticleDao.LogArticleView(article);
        }

        public void ArticlesDelete(string articles)
        {
            ArticleDao.ArticlesDelete(articles);
        }

        public void ArticlesArchive(string articles)
        {
            ArticleDao.ArticlesArchive(articles);
        }

        public void ArticlesUnarchive(string articles)
        {
            ArticleDao.ArticlesUnarchive(articles);
        }

        public void ArticlesDeactivate(string articles)
        {
            ArticleDao.ArticlesDeactivate(articles);
        }

        public void ArticlesActivate(string articles)
        {
            ArticleDao.ArticlesActivate(articles);
        }

        public void ArticleAdd(ArticleSearch articles)
        {
            ArticleDao.ArticleAdd(articles);
        }
        
        #endregion
    }
}