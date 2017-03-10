using System.Collections.Generic;
using Services.DTO;


namespace Services.Facade.Interfaces
{
    public interface IArticleFacade
    {
        IEnumerable<Article> Search(ArticleSearch param);

        void LogArticleView(Article article);

        void ArticlesDelete(string articles);
        void ArticlesArchive(string articles);
        void ArticlesUnarchive(string articles);
        void ArticlesDeactivate(string articles);
        void ArticlesActivate(string articles);
        void ArticleAdd(ArticleSearch articles);

        List<Article> ArticleInbox(ArticleSearch param);
    }
}