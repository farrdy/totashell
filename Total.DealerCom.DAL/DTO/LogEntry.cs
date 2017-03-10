namespace Services.DTO
{
    public class LogEntry
    {
        public string Title { get; set; }

        public string IDRole { get; set; }

        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int? IDArticleType { get; set; }

        public int? IDArticleCat { get; set; }

        public string ArticleType { get; set; }

        public string ArticleCat { get; set; }

        public string LogDate { get; set; }

        public string LastLogin { get; set; }

        public int? LoginCount { get; set; }

        public int? StartYear { get; set; }
        public int? StartMonth { get; set; }

        public int? EndYear { get; set; }
        public int? EndMonth { get; set; }
    }
}