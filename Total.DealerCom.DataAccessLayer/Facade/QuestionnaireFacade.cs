using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Facade
{
    class QuestionnaireFacade : IQuestionnaireFacade
    {
        public List<string> PopulateQuestionnaireList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var questionList = QuestionnaireDoa.GetQuestionnaires();

            var returnValue = new List<string>();

            dropDownList.Items.Add(new ListItem("", "0"));
            foreach (var g in questionList)
            {
                dropDownList.Items.Add(new ListItem(g.Title, g.IDQuestionnaire));
            }

            return returnValue;
        }

       
        public void PopulateAnswerTypeList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var answerList = QuestionnaireDoa.GetAnswerTypes();

            dropDownList.Items.Add(new ListItem("", "0"));
            foreach (var g in answerList)
            {
                dropDownList.Items.Add(new ListItem(g.AnswerType, g.IDAnswerType));
            }
        }

        public AnswerOption FindQuestion(string id)
        {
            return QuestionnaireDoa.FindQuestion(id);
        }

        public AnswerOption FindTemplateQuestion(string id)
        {
            return QuestionnaireDoa.FindTemplateQuestion(id);
        }

        public List<AnswerOption> AnswerOptionLoad(Questionnaire question)
        {
            return QuestionnaireDoa.AnswerOptionLoad(question);
        }

        public IEnumerable<QuestionnaireReport> GetReportQuestionnaireSummary(string id)
        {
            return QuestionnaireDoa.ReportQuestionnaireSummary(id);
        }

        public IEnumerable<QuestionnaireReport> GetReportQuestionnaireDetail(string id)
        {
            return QuestionnaireDoa.ReportQuestionnaireDetail(id);
        }

        public IEnumerable<QuestionnaireReport> GetReportQuestionOptionSummary(string id)
        {
            return QuestionnaireDoa.ReportQuestionOptionSummary(id);
        }

        public IEnumerable<QuestionnaireReport> GetReportQuestionOptionDetail(string id)
        {
            return QuestionnaireDoa.ReportQuestionOptionDetail(id);
        }

        public IEnumerable<QuestionnaireReport> GetReportQuestion(string id)
        {
            return QuestionnaireDoa.ReportQuestion(id);
        }

        public IEnumerable<Questionnaire> Search(Questionnaire group)
        {
            return QuestionnaireDoa.Search(group);
        }

        public List<Questionnaire> QuestionnaireInbox(Questionnaire group)
        {
            return QuestionnaireDoa.QuestionnaireInbox(group);
        }

        public IEnumerable<Questionnaire> QuestionnaireSearch(Questionnaire group)
        {
            return QuestionnaireDoa.QuestionnaireSearch(group);
        }

        public IEnumerable<Questionnaire> TemplateQuestionnaireSearch(Questionnaire group)
        {
            return QuestionnaireDoa.TemplateQuestionnaireSearch(group);
        }

        public IEnumerable<Question> GetQuestions(string id)
        {
            return QuestionnaireDoa.GetQuestions(id);
        }

        public IEnumerable<Question> GetTemplateQuestions(string id)
        {
            return QuestionnaireDoa.GetTemplateQuestions(id);
        }

        public void QuestionsDelete(string questions)
        {
            QuestionnaireDoa.QuestionsDelete(questions);
        }

        public void TemplateQuestionsDelete(string questions)
        {
            QuestionnaireDoa.TemplateQuestionsDelete(questions);
        }


        public IEnumerable<AnswerOption> TemplateQuestionSearch (string templateName, string deAct)
        {
            return QuestionnaireDoa.TemplateQuestionSearch(templateName, deAct);
        }

       public string QuestionnaireEdit(Questionnaire group)
       {
           return QuestionnaireDoa.QuestionnaireEdit(group);
       }

        public void QuestionnaireActive(string list, string Active)
        {
            QuestionnaireDoa.QuestionnaireActive(list, Active);
        }

        public void TemplateQuestionnaireActive(string list, string Active)
        {
            QuestionnaireDoa.TemplateQuestionnaireActive(list, Active);
        }

        public void TemplateQuestionActive(string list, string Active)
        {
            QuestionnaireDoa.TemplateQuestionActive(list, Active);
        }

        public void QuestionnaireDelete(string list)
        {
            QuestionnaireDoa.QuestionnaireDelete(list);
        }

        public void AnswerClear(string UserID, string idQuestionnaire)
        {
            QuestionnaireDoa.AnswerClear(UserID, idQuestionnaire);
        }

        public void AnswerInsert(AnswerOption option, string UserID)
        {
            QuestionnaireDoa.AnswerInsert(option, UserID);
        }

        public void TemplateQuestionnaireDelete(string list)
        {
            QuestionnaireDoa.TemplateQuestionnaireDelete(list);
        }

        public void QuestionOptionEdit(AnswerOption option)
        {
            QuestionnaireDoa.QuestionOptionEdit(option);
        }

        public void TemplateQuestionOptionEdit(AnswerOption option)
        {
            QuestionnaireDoa.TemplateQuestionOptionEdit(option);
        }

        public void QuestionOptionDelete(string id)
        {
            QuestionnaireDoa.QuestionOptionDelete(id);
        }

        public void TemplateQuestionOptionDelete(string id)
        {
            QuestionnaireDoa.TemplateQuestionOptionDelete(id);
        }

        public Questionnaire GetQuestionnaire(string id)
        {
            return QuestionnaireDoa.FindQuestionnaire(id);
        }

        public Questionnaire GetQuestionnaireTemplate(string id)
        {
            return QuestionnaireDoa.FindQuestionnaireTemplate(id);
        }

        public string QuestionEdit(Question option)
        {
            return QuestionnaireDoa.QuestionEdit(option);
        }

        public string TemplateQuestionEdit(Question option)
        {
            return QuestionnaireDoa.TemplateQuestionEdit(option);
        }

        public void TemplateQuestionsUse(string idQuestionnaire, string idTemplateQuestions)
        {
            QuestionnaireDoa.TemplateQuestionsUse(idQuestionnaire, idTemplateQuestions);
        }


        public IEnumerable<AnswerOption> QuestionOptionLoad(string id)
        {
            return QuestionnaireDoa.QuestionOptionLoad(id);
        }

        public IEnumerable<AnswerOption> TemplateQuestionOptionLoad(string id)
        {
            return QuestionnaireDoa.TemplateQuestionOptionLoad(id);
        }

        public IEnumerable<AnswerOption> TemplateQuestionOptionsLoad(string id)
        {
            return QuestionnaireDoa.TemplateQuestionOptionsLoad(id);
        }

        public List<AnswerOption> QuestionSectionLoad(string id)
        {
            return QuestionnaireDoa.QuestionSectionLoad(id);
        }

        public List<AnswerOption> TemplateQuestionSectionLoad(string id)
        {
            return QuestionnaireDoa.QuestionSectionLoad(id);
        }

        public List<AnswerOption> QuestionColumnsLoad(string idQuestionnaire, string sections)
        {
            return QuestionnaireDoa.QuestionColumnsLoad(idQuestionnaire, sections);
        }

        public List<AnswerOption> QuestionResultsLoad(string idQuestionnaire, string sections)
        {
            return QuestionnaireDoa.QuestionResultsLoad(idQuestionnaire, sections);
        }

        public List<AnswerOption> GetAnswerTypes()
        {
            return QuestionnaireDoa.GetAnswerTypes();
        }
    }
}
