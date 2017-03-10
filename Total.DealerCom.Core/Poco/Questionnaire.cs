namespace Total.DealerCom.Core
{
    public class Questionnaire
    {
        public string IDQuestionnaire { get; set; }

        public string Title { get; set; }

        public bool DeAct { get; set; }
        public string DaysLeft { get; set; }

        public string Outlet { get; set; }

        public string EmployeeName { get; set; }

        public string UserID { get; set; }
        public string Name { get; set; }

        public string IDTempQuestionnaire { get; set; }
        public string TemplateName { get; set; }

        public string DateAnswer { get; set; }

        public string DateQuestionnaire { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Complete { get; set; }
        public string ShowNumbers { get; set; }
        public string Active { get; set; }
        public string ReleaseGroup { get; set; }
        public string ReleaseUserID { get; set; }

        public int? StartYear { get; set; }
        public int? StartMonth { get; set; }

        public int? EndYear { get; set; }
        public int? EndMonth { get; set; }

    }
}