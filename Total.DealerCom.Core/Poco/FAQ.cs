using System;

namespace Total.DealerCom.Core
{
    public class FAQ
    {
        public string QuestionId { get; set; }
        public string AnswerId { get; set; }
        public string Question { get; set; }
        public DateTime QuestionDateCreated { get; set; }
        public string QuestionUserId { get; set; }
        public bool Status { get; set; }
        public string Answer { get; set; }
        public string UserAnswerId { get; set; }
        public DateTime? DateAnswered { get; set; }
    }
}
