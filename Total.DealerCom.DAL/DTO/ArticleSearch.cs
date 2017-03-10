using System;

namespace Services.DTO
{
    public class ArticleSearch
    {
        public bool Archive { get; set; }
        public bool DeAct { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public string UserID { get; set; }

        public string ReleaseGroup { get; set; }
        public string ReleaseUserId { get; set; }

        public int? IDArticleType { get; set; }

        public int? IDArticleCat { get; set; }

        public DateTime DateArticle { get; set; }

        public int? StartYear { get; set; }
        public int? StartMonth { get; set; }

        public int? EndYear { get; set; }
        public int? EndMonth { get; set; }
    }
}