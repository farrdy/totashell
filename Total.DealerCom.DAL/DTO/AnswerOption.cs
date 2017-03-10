namespace Services.DTO
{
    public class AnswerOption
    {
        public string IDQuestionnaire { get; set; }
        public string IDAnswerType { get; set; }
        public string AnswerType { get; set; }
        public string Active { get; set; }
        public string DateQuestionnaire { get; set; }

        public string IDTemplateQuestionnaire { get; set; }
        public string IDTemplateQuestionOption { get; set; }
        public string IDTemplateQuestion { get; set; }

        public string MultipleAnswers { get; set; }
        public string Name { get; set; }

        public string IDQuestion { get; set; }
        public string TemplateName { get; set; }
        public string Question { get; set; }

        public string ColumnNo { get; set; }
        public string Answer { get; set; }
        public string UserID { get; set; }

        public string IDQuestionOption { get; set; }

        public string Answer1 { get; set; }

        public string Mandatory { get; set; }

        public string Answer2 { get; set; }
        public string Answer3 { get; set; }

        public string Title { get; set; }

        public string QuestionOption { get; set; }

        public string Section { get; set; }
        public string ColumnSelf { get; set; }
        public string ColumnPartner { get; set; }
        public string ColumnCustom { get; set; }
        public string ShowOptionNumbers { get; set; }
        public string AnswerCode { get; set; }

    }
}