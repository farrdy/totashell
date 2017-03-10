
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IQuestionnaireFacade
    {
        List<string> PopulateQuestionnaireList(ref DropDownList dropDownList);
        IEnumerable<Questionnaire> Search(Questionnaire group);
        Questionnaire GetQuestionnaire(string id);
        Questionnaire GetQuestionnaireTemplate(string id);
        List<AnswerOption> AnswerOptionLoad(Questionnaire question);
        AnswerOption FindQuestion(string id);
        AnswerOption FindTemplateQuestion(string id);

        IEnumerable<QuestionnaireReport> GetReportQuestionnaireSummary(string id);
        IEnumerable<QuestionnaireReport> GetReportQuestionnaireDetail(string id);
        IEnumerable<QuestionnaireReport> GetReportQuestionOptionSummary(string id);
        IEnumerable<QuestionnaireReport> GetReportQuestionOptionDetail(string id);
        IEnumerable<QuestionnaireReport> GetReportQuestion(string id);
        IEnumerable<Questionnaire> QuestionnaireSearch(Questionnaire group);
        IEnumerable<Questionnaire> TemplateQuestionnaireSearch(Questionnaire group);
        IEnumerable<Question> GetQuestions(string id);
        IEnumerable<Question> GetTemplateQuestions(string id);
        
        void QuestionsDelete(string articles);
        void TemplateQuestionsDelete(string articles);
        string QuestionnaireEdit(Questionnaire group);
        IEnumerable<AnswerOption> QuestionOptionLoad(string id);
        IEnumerable<AnswerOption> TemplateQuestionOptionLoad(string id);
        IEnumerable<AnswerOption> TemplateQuestionOptionsLoad(string id);
        List<AnswerOption> QuestionSectionLoad(string id);
        List<AnswerOption> TemplateQuestionSectionLoad(string id);
        List<AnswerOption> GetAnswerTypes();
        void PopulateAnswerTypeList(ref DropDownList dropDownList);
        void QuestionOptionEdit(AnswerOption option);
        void TemplateQuestionOptionEdit(AnswerOption option);
        void QuestionOptionDelete(string id);
        void TemplateQuestionOptionDelete(string id);
        string QuestionEdit(Question option);
        string TemplateQuestionEdit(Question option);
        void QuestionnaireActive(string list, string active);
        void TemplateQuestionnaireActive(string list, string active);
        void TemplateQuestionActive(string list, string active);
        void QuestionnaireDelete(string list);
        void TemplateQuestionnaireDelete(string list);
        void TemplateQuestionsUse(string idQuestionnaire, string idTemplateQuestions);

        IEnumerable<AnswerOption> TemplateQuestionSearch(string templateName, string deAct);
        List<AnswerOption> QuestionColumnsLoad(string idQuestionnaire, string sections);
        List<AnswerOption> QuestionResultsLoad(string idQuestionnaire, string sections);
        List<Questionnaire> QuestionnaireInbox(Questionnaire group);
        void AnswerClear(string userID, string idQuestionnaire);
        void AnswerInsert(AnswerOption option, string userID);
    }
}
