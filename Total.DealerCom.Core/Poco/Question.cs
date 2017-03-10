namespace Total.DealerCom.Core
{
    public class Question
    {
        public string IDQuestionnaire { get; set; }
        public string IDQuestion { get; set; }
        public string _Question { get; set; }
        public string Section { get; set; }

        public string ColumnSelf { get; set; }
        public string ColumnPartner { get; set; }
        public string ColumnCustom { get; set; }

        public string Mandatory { get; set; }
        public string ShowOptionNumbers { get; set; }

        public string IDTemplateQuestion { get; set; }

        public string AnswerCode { get; set; }
        public string AnswerType { get; set; }
        public string IDAnswerType { get; set; }

        public string Complete { get; set; }
        public string IDTemplateQuestionnaire { get; set; }
        public string TemplateName { get; set; }
    }
}