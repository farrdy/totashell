namespace Total.DealerCom.Core
{
    public class QuestionnaireReport
    {
        public string Title { get; set; }
        public string DateQuestionnaire { get; set; }
        public string AnswerCount { get; set; }
        public string ReleaseCount { get; set; }
        public string OutstandingCount { get; set; }

        public string ReportDate { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Responded { get; set; }

        public string QuestionOption { get; set; }
        public string Section { get; set; }
        public string YesCount { get; set; }

        public string Self { get; set; }
        public string Partner { get; set; }
        public string Third { get; set; }

        public string Question { get; set; }

    }
}