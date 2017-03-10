using System;

namespace Services.DTO
{
    public class Article
    {
        public string IdArticle { get; set; }

        public string Title { get; set; }

        public string IdArticleCat { get; set; }

        public string FileName { get; set; }

        public DateTime DateArticle { get; set; }

        public bool Active { get; set; }

        public bool Archive { get; set; }

        public string UserId { get; set; }

        public string ReleaseUserId { get; set; }

    }
}