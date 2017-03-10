using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Infrastructure.Server.DataAccess;
using Services.DTO;

namespace Services.DataAccess
{
    internal class QuestionnaireDoa
    {

        public static IEnumerable<Questionnaire> GetQuestionnaires()
        {
            var dataTable = DataFacade.GetDataTable("QuestionnaireLoad",
                                                    new ParameterValue[0]);

            return (from DataRow r in dataTable.Rows
                    select new Questionnaire
                        {
                            IDQuestionnaire = r["idQuestionnaire"].ToString(),
                            Title = r["Title"].ToString()
                        }).ToList();
        }

        public static void QuestionnaireActive(string list, string active)
        {
            DataFacade.ExecuteNonQuery("QuestionnaireActivate",
                                       new[]
                                           {
                                               new ParameterValue("idQuestionnaires", list),
                                               new ParameterValue("Active", Convert.ToBoolean(active) ? 1 : 0)
                                           });
        }

        public static void TemplateQuestionnaireActive(string list, string active)
        {
            DataFacade.ExecuteNonQuery("TemplateQuestionnaireActivate",
                                       new[]
                                           {
                                               new ParameterValue("idTemplateQuestionnaires", list),
                                               new ParameterValue("Active", Convert.ToBoolean(active) ? 1 : 0)
                                           });
        }

        public static void TemplateQuestionActive(string list, string active)
        {
            DataFacade.ExecuteNonQuery("TemplateQuestionActivate",
                                       new[]
                                           {
                                               new ParameterValue("idTemplateQuestions", list),
                                               new ParameterValue("Active", Convert.ToBoolean(active) ? 1 : 0)
                                           });
        }

        public static void AnswerClear(string userID, string idQuestionnaire)
        {
            DataFacade.ExecuteNonQuery("AnswerClear",
                                       new[]
                                           {
                                               new ParameterValue("UserID", userID),
                                               new ParameterValue("idQuestionnaire", idQuestionnaire)
                                           });
        }

        public static void QuestionnaireDelete(string list)
        {
            DataFacade.ExecuteNonQuery("QuestionnaireDelete",
                                       new[] {new ParameterValue("idQuestionnaires", list)});
        }

        public static void TemplateQuestionnaireDelete(string list)
        {
            DataFacade.ExecuteNonQuery("TemplateQuestionnaireDelete",
                                       new[] {new ParameterValue("idTemplateQuestionnaires", list)});
        }

        public static IEnumerable<Question> GetQuestions(string id)
        {
            var dataTable = DataFacade.GetDataTable("QuestionLoad",
                                                    new[] {new ParameterValue("idQuestionnaire", id)});

            return (from DataRow r in dataTable.Rows
                    select new Question
                        {
                            IDQuestionnaire = r["idQuestionnaire"].ToString(),
                            IDQuestion = r["idQuestion"].ToString(),
                            _Question = r["Question"].ToString(),
                            Section = r["Section"].ToString(),
                            ColumnSelf = r["ColumnSelf"].ToString(),
                            ColumnPartner = r["ColumnPartner"].ToString(),
                            ColumnCustom = r["ColumnCustom"].ToString(),
                            Mandatory = r["Mandatory"].ToString(),
                            ShowOptionNumbers = r["ShowOptionNumbers"].ToString(),
                            IDTemplateQuestion = r["idTemplateQuestion"].ToString(),
                            AnswerCode = r["AnswerCode"].ToString(),
                            AnswerType = r["AnswerType"].ToString(),
                            IDAnswerType = r["idAnswerType"].ToString()
                        }).ToList();
        }

        public static IEnumerable<Question> GetTemplateQuestions(string id)
        {
            var dataTable = DataFacade.GetDataTable("TemplateQuestionLoad",
                                                    new[] {new ParameterValue("idTemplateQuestionnaire", id)});

            return (from DataRow r in dataTable.Rows
                    select new Question
                        {
                            IDTemplateQuestionnaire = r["idTemplateQuestionnaire"].ToString(),
                            _Question = r["Question"].ToString(),
                            Section = r["Section"].ToString(),
                            ColumnSelf = r["ColumnSelf"].ToString(),
                            ColumnPartner = r["ColumnPartner"].ToString(),
                            ColumnCustom = r["ColumnCustom"].ToString(),
                            Mandatory = r["Mandatory"].ToString(),
                            ShowOptionNumbers = r["ShowOptionNumbers"].ToString(),
                            IDTemplateQuestion = r["idTemplateQuestion"].ToString(),
                            AnswerCode = r["AnswerCode"].ToString(),
                            AnswerType = r["AnswerType"].ToString(),
                            IDAnswerType = r["idAnswerType"].ToString()
                        }).ToList();
        }


        public static IEnumerable<AnswerOption> QuestionOptionLoad(string id)
        {
            var dataTable = DataFacade.GetDataTable("QuestionOptionLoad",
                                                    new[] {new ParameterValue("idQuestion", id)});

            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            IDQuestionnaire = r["idQuestionnaire"].ToString(),
                            IDQuestionOption = r["idQuestionOption"].ToString(),
                            IDQuestion = r["idQuestion"].ToString(),
                            QuestionOption = r["QuestionOption"].ToString()
                        }).ToList();
        }

        public static IEnumerable<AnswerOption> TemplateQuestionSearch(string templateName, string deAct)
        {
            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(templateName))
            {
                paramList.Add(new ParameterValue("TemplateName", templateName));
            }
            if (!string.IsNullOrEmpty(deAct))
            {
                paramList.Add(new ParameterValue("DeAct", Convert.ToBoolean(deAct) ? 1 : 0));
            }

            var dataTable = DataFacade.GetDataTable("TemplateQuestionSearch", paramList.ToArray());

            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            IDTemplateQuestionnaire = r["idTemplateQuestionnaire"].ToString(),
                            IDTemplateQuestion = r["idTemplateQuestion"].ToString(),
                            IDAnswerType = r["idAnswerType"].ToString(),
                            Section = r["Section"].ToString(),
                            TemplateName = r["TemplateName"].ToString(),
                            Question = r["Question"].ToString(),
                            ColumnSelf = r["ColumnSelf"].ToString(),
                            ColumnPartner = r["ColumnPartner"].ToString(),
                            ColumnCustom = r["ColumnCustom"].ToString(),
                            Mandatory = r["Mandatory"].ToString(),
                            ShowOptionNumbers = r["ShowOptionNumbers"].ToString(),
                            Active = r["Active"].ToString(),
                        }).ToList();
        }

        public static IEnumerable<AnswerOption> TemplateQuestionOptionLoad(string id)
        {
            var dataTable = DataFacade.GetDataTable("TemplateQuestionOptionLoad1",
                                                    new[] {new ParameterValue("idTemplateQuestion", id)});

            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            IDTemplateQuestionnaire = r["idTemplateQuestionnaire"].ToString(),
                            IDTemplateQuestionOption = r["idTemplateQuestionOption"].ToString(),
                            IDTemplateQuestion = r["idTemplateQuestion"].ToString(),
                            QuestionOption = r["QuestionOption"].ToString()
                        }).ToList();
        }

        public static IEnumerable<AnswerOption> TemplateQuestionOptionsLoad(string id)
        {
            var dataTable = DataFacade.GetDataTable("TemplateQuestionOptionLoad",
                                                    new[] {new ParameterValue("idTemplateQuestion", id)});

            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            IDTemplateQuestionOption = r["idTemplateQuestionOption"].ToString(),
                            IDTemplateQuestion = r["idTemplateQuestion"].ToString(),
                            QuestionOption = r["QuestionOption"].ToString()
                        }).ToList();
        }

        public static string QuestionEdit(Question option)
        {
            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(option.IDQuestion))
            {
                paramList.Add(new ParameterValue("idQuestion", option.IDQuestion));
            }
            if (!string.IsNullOrEmpty(option.IDQuestionnaire))
            {
                paramList.Add(new ParameterValue("idQuestionnaire", option.IDQuestionnaire));
            }
            if (!string.IsNullOrEmpty(option.Section))
            {
                paramList.Add(new ParameterValue("Section", option.Section));
            }
            if (!string.IsNullOrEmpty(option._Question))
            {
                paramList.Add(new ParameterValue("Question", option._Question));
            }
            if (!string.IsNullOrEmpty(option.IDAnswerType))
            {
                paramList.Add(new ParameterValue("idAnswerType", option.IDAnswerType));
            }
            if (!string.IsNullOrEmpty(option.IDTemplateQuestionnaire))
            {
                paramList.Add(new ParameterValue("idTemplateQuestionnaire", option.IDTemplateQuestionnaire));
            }
            if (!string.IsNullOrEmpty(option.ColumnSelf))
            {
                paramList.Add(new ParameterValue("ColumnSelf", Convert.ToBoolean(option.ColumnSelf) ? 1 : 0));
            }
            if (!string.IsNullOrEmpty(option.ColumnPartner))
            {
                paramList.Add(new ParameterValue("ColumnPartner", Convert.ToBoolean(option.ColumnPartner) ? 1 : 0));
            }

            if (!string.IsNullOrEmpty(option.ShowOptionNumbers))
            {
                paramList.Add(new ParameterValue("ShowOptionNumbers",
                                                 Convert.ToBoolean(option.ShowOptionNumbers) ? 1 : 0));
            }
            if (!string.IsNullOrEmpty(option.Mandatory))
            {
                paramList.Add(new ParameterValue("Mandatory", Convert.ToBoolean(option.Mandatory) ? 1 : 0));
            }
            if (!string.IsNullOrEmpty(option.TemplateName))
            {
                paramList.Add(new ParameterValue("TemplateName", option.TemplateName));
            }
            if (!string.IsNullOrEmpty(option.Complete))
            {
                paramList.Add(new ParameterValue("Complete", Convert.ToBoolean(option.Complete) ? 1 : 0));
            }

            DataRow r = DataFacade.GetDataRow("QuestionEdit", paramList.ToArray());
            string idQuestion = r["idQuestion"].ToString();


            return idQuestion;
        }

        public static string TemplateQuestionEdit(Question option)
        {
            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(option.IDQuestion))
            {
                paramList.Add(new ParameterValue("idTemplateQuestion", option.IDQuestion));
            }
            if (!string.IsNullOrEmpty(option.Section))
            {
                paramList.Add(new ParameterValue("Section", option.Section));
            }
            if (!string.IsNullOrEmpty(option._Question))
            {
                paramList.Add(new ParameterValue("Question", option._Question));
            }
            if (!string.IsNullOrEmpty(option.IDAnswerType))
            {
                paramList.Add(new ParameterValue("idAnswerType", option.IDAnswerType));
            }
            if (!string.IsNullOrEmpty(option.IDTemplateQuestionnaire))
            {
                paramList.Add(new ParameterValue("idTemplateQuestionnaire", option.IDTemplateQuestionnaire));
            }
            if (!string.IsNullOrEmpty(option.ColumnSelf))
            {
                paramList.Add(new ParameterValue("ColumnSelf", Convert.ToBoolean(option.ColumnSelf) ? 1 : 0));
            }
            if (!string.IsNullOrEmpty(option.ColumnPartner))
            {
                paramList.Add(new ParameterValue("ColumnPartner", Convert.ToBoolean(option.ColumnPartner) ? 1 : 0));
            }

            if (!string.IsNullOrEmpty(option.ShowOptionNumbers))
            {
                paramList.Add(new ParameterValue("ShowOptionNumbers",
                                                 Convert.ToBoolean(option.ShowOptionNumbers) ? 1 : 0));
            }
            if (!string.IsNullOrEmpty(option.Mandatory))
            {
                paramList.Add(new ParameterValue("Mandatory", Convert.ToBoolean(option.Mandatory) ? 1 : 0));
            }
            if (!string.IsNullOrEmpty(option.TemplateName))
            {
                paramList.Add(new ParameterValue("TemplateName", option.TemplateName));
            }
            if (!string.IsNullOrEmpty(option.Complete))
            {
                paramList.Add(new ParameterValue("Complete", Convert.ToBoolean(option.Complete) ? 1 : 0));
            }

            DataRow r = DataFacade.GetDataRow("TemplateQuestionEdit", paramList.ToArray());
            string idQuestion = r["idTemplateQuestion"].ToString();


            return idQuestion;
        }


        public static void QuestionOptionEdit(AnswerOption option)
        {
            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(option.IDQuestionOption))
            {
                paramList.Add(new ParameterValue("idQuestionOption", option.IDQuestionOption));
            }
            if (!string.IsNullOrEmpty(option.IDQuestion))
            {
                paramList.Add(new ParameterValue("idQuestion", option.IDQuestion));
            }
            if (!string.IsNullOrEmpty(option.IDQuestionnaire))
            {
                paramList.Add(new ParameterValue("idQuestionnaire", option.IDQuestionnaire));
            }
            if (!string.IsNullOrEmpty(option.QuestionOption))
            {
                paramList.Add(new ParameterValue("QuestionOption", option.QuestionOption));
            }

            DataFacade.ExecuteNonQuery("QuestionOptionEdit", paramList.ToArray());
        }


        public static void AnswerInsert(AnswerOption option, string userID)
        {
            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(userID))
            {
                paramList.Add(new ParameterValue("UserID", userID));
            }

            if (!string.IsNullOrEmpty(option.IDQuestionOption))
            {
                paramList.Add(new ParameterValue("idQuestionOption", option.IDQuestionOption));
            }
            if (!string.IsNullOrEmpty(option.IDQuestion))
            {
                paramList.Add(new ParameterValue("idQuestion", option.IDQuestion));
            }
            if (!string.IsNullOrEmpty(option.IDQuestionnaire))
            {
                paramList.Add(new ParameterValue("idQuestionnaire", option.IDQuestionnaire));
            }
            if (!string.IsNullOrEmpty(option.ColumnNo))
            {
                paramList.Add(new ParameterValue("ColumnNo", option.ColumnNo));
            }
            if (!string.IsNullOrEmpty(option.Answer))
            {
                paramList.Add(new ParameterValue("Answer", option.Answer));
            }


            DataFacade.ExecuteNonQuery("AnswerInsert", paramList.ToArray());
        }



        public static void TemplateQuestionsUse(string idQuestionnaire, string idTemplateQuestions)
        {
            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(idQuestionnaire))
            {
                paramList.Add(new ParameterValue("idQuestionnaire", idQuestionnaire));
            }
            if (!string.IsNullOrEmpty(idTemplateQuestions))
            {
                paramList.Add(new ParameterValue("idTemplateQuestions", idTemplateQuestions));
            }

            DataFacade.ExecuteNonQuery("TemplateQuestionsUse", paramList.ToArray());
        }


        public static void TemplateQuestionOptionEdit(AnswerOption option)
        {
            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(option.IDQuestionOption))
            {
                paramList.Add(new ParameterValue("idTemplateQuestionOption", option.IDTemplateQuestionOption));
            }
            if (!string.IsNullOrEmpty(option.IDQuestion))
            {
                paramList.Add(new ParameterValue("idTemplateQuestion", option.IDTemplateQuestion));
            }
            if (!string.IsNullOrEmpty(option.IDQuestionnaire))
            {
                paramList.Add(new ParameterValue("idTemplateQuestionnaire", option.IDTemplateQuestionnaire));
            }
            if (!string.IsNullOrEmpty(option.QuestionOption))
            {
                paramList.Add(new ParameterValue("QuestionOption", option.QuestionOption));
            }

            DataFacade.ExecuteNonQuery("TemplateQuestionOptionEdit", paramList.ToArray());
        }

        public static void QuestionOptionDelete(string id)
        {
            DataFacade.ExecuteNonQuery("QuestionOptionDelete",
                                       new[] {new ParameterValue("idQuestionOption", id)});
        }

        public static void TemplateQuestionOptionDelete(string id)
        {
            DataFacade.ExecuteNonQuery("TemplateQuestionOptionDelete",
                                       new[] {new ParameterValue("idTemplateQuestionOption", id)});
        }

        public static Questionnaire FindQuestionnaire(string id)
        {
            var r = DataFacade.GetDataRow("QuestionnaireGet",
                                          new[] {new ParameterValue("idQuestionnaire", id)});

            if (r == null) return null;

            var l = new Questionnaire
                {
                    IDQuestionnaire = r["idQuestionnaire"].ToString(),
                    Title = r["Title"].ToString(),
                    DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                    Logo = r["Logo"].ToString(),
                    Description = r["Description"].ToString(),
                    Complete = r["Complete"].ToString(),
                    ShowNumbers = r["ShowNumbers"].ToString(),
                    Active = r["Active"].ToString(),
                    ReleaseGroup = r["ReleaseGroup"].ToString(),
                    ReleaseUserID = r["ReleaseUserID"].ToString(),
                };

            return l;
        }

        public static Questionnaire FindQuestionnaireTemplate(string id)
        {
            var r = DataFacade.GetDataRow("TemplateQuestionnaireGet",
                                          new[] {new ParameterValue("idTemplateQuestionnaire", id)});


            if (r == null) return null;

            var l = new Questionnaire
                {
                    IDTempQuestionnaire = r["idTemplateQuestionnaire"].ToString(),
                    Title = r["Title"].ToString(),
                    DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                    Logo = r["Logo"].ToString(),
                    TemplateName = r["TemplateName"].ToString(),
                    Description = r["Description"].ToString(),
                    Complete = r["Complete"].ToString(),
                    ShowNumbers = r["ShowNumbers"].ToString(),
                    Active = r["Active"].ToString(),
                    ReleaseGroup = r["ReleaseGroup"].ToString(),
                    ReleaseUserID = r["ReleaseUserID"].ToString(),
                };

            return l;
        }

        public static void QuestionsDelete(string articles)
        {
            DataFacade.ExecuteNonQuery("QuestionsDelete",
                                       new ParameterValue("idQuestions", articles));
        }

        public static void TemplateQuestionsDelete(string articles)
        {
            DataFacade.ExecuteNonQuery("TemplateQuestionDelete",
                                       new ParameterValue("idTemplateQuestions", articles));
        }


        public static AnswerOption FindQuestion(string id)
        {
            var r = DataFacade.GetDataRow("QuestionGet",
                                          new[] {new ParameterValue("idQuestion", id)});

            if (r == null) return new AnswerOption();

            var l = new AnswerOption
                {
                    IDQuestionnaire = r["idQuestionnaire"].ToString(),
                    IDQuestion = r["idQuestion"].ToString(),
                    IDAnswerType = r["idAnswerType"].ToString(),
                    Section = r["Section"].ToString(),
                    Question = r["Question"].ToString(),
                    ColumnSelf = r["ColumnSelf"].ToString(),
                    ColumnPartner = r["ColumnPartner"].ToString(),
                    ColumnCustom = r["ColumnCustom"].ToString(),
                    Mandatory = r["Mandatory"].ToString(),
                    ShowOptionNumbers = r["ShowOptionNumbers"].ToString(),
                };

            return l;
        }

        public static AnswerOption FindTemplateQuestion(string id)
        {
            var r = DataFacade.GetDataRow("TemplateQuestionGet",
                                          new[] {new ParameterValue("idTemplateQuestion", id)});

            if (r == null) return new AnswerOption();

            var l = new AnswerOption
                {
                    IDTemplateQuestionnaire = r["idTemplateQuestionnaire"].ToString(),
                    IDTemplateQuestion = r["idTemplateQuestion"].ToString(),
                    IDAnswerType = r["idAnswerType"].ToString(),
                    Section = r["Section"].ToString(),
                    Question = r["Question"].ToString(),
                    ColumnSelf = r["ColumnSelf"].ToString(),
                    ColumnPartner = r["ColumnPartner"].ToString(),
                    ColumnCustom = r["ColumnCustom"].ToString(),
                    Mandatory = r["Mandatory"].ToString(),
                    ShowOptionNumbers = r["ShowOptionNumbers"].ToString(),
                };

            return l;
        }

        public static List<AnswerOption> QuestionSectionLoad(string id)
        {
            var dataTable = DataFacade.GetDataTable("QuestionSectionLoad",
                                                    new[] {new ParameterValue("idQuestionnaire", id)});


            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            Section = r["Section"].ToString()
                        }).ToList();
        }

        public static List<AnswerOption> QuestionColumnsLoad(string id, string sections)
        {
            var dataTable = DataFacade.GetDataTable("QuestionColumnsLoad",
                                                    new[]
                                                        {
                                                            new ParameterValue("idQuestionnaire", id),
                                                            new ParameterValue("Sect", sections),
                                                            new ParameterValue("QSecRep", "1")
                                                        });

            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            IDQuestion = r["idQuestion"].ToString(), //
                            IDQuestionOption = r["idQuestionOption"].ToString(), //
                            Mandatory = r["Mandatory"].ToString(), //

                            QuestionOption = r["QuestionOption"].ToString(), //
                            Section = r["Section"].ToString(), //
                            ColumnSelf = r["ColumnSelf"].ToString(), //
                            ColumnPartner = r["ColumnPartner"].ToString(), //
                            ColumnCustom = r["ColumnCustom"].ToString(), //

                            MultipleAnswers = r["bMultipleAnswers"].ToString(),
                        }).ToList();
        }

        public static List<AnswerOption> QuestionResultsLoad(string id, string sections)
        {
            var dataTable = DataFacade.GetDataTable("QuestionResultsLoad",
                                                    new[]
                                                        {
                                                            new ParameterValue("idQuestionnaire", id),
                                                            new ParameterValue("Sect", sections),
                                                            new ParameterValue("QSecRep", "1")
                                                        });


            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            UserID = r["UserID"].ToString(), //
                            IDQuestionnaire = r["idQuestionnaire"].ToString(), //
                            IDQuestion = r["idQuestion"].ToString(), //
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(), //
                            IDQuestionOption = r["idQuestionOption"].ToString(), //


                            QuestionOption = r["QuestionOption"].ToString(), //
                            Section = r["Section"].ToString(), //
                            ColumnSelf = r["ColumnSelf"].ToString(), //
                            ColumnPartner = r["ColumnPartner"].ToString(), //
                            ColumnCustom = r["ColumnCustom"].ToString(), //

                            AnswerCode = r["AnswerCode"].ToString(), //

                            Title = r["Title"].ToString(), //
                            Name = r["Name"].ToString(), //
                            ShowOptionNumbers = r["ShowOptionNumbers"].ToString(), //

                            Answer1 = r["Answer1"].ToString(),
                            Answer2 = r["Answer2"].ToString(),
                            Answer3 = r["Answer3"].ToString(),
                            MultipleAnswers = r["bMultipleAnswers"].ToString(),
                        }).ToList();
        }

        public static List<AnswerOption> TemplateQuestionSectionLoad(string id)
        {
            var dataTable = DataFacade.GetDataTable("TemplateQuestionSectionLoad",
                                                    new[] {new ParameterValue("idTemplateQuestionnaire", id)});


            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            Section = r["Section"].ToString()
                        }).ToList();
        }

        public static List<AnswerOption> GetAnswerTypes()
        {
            var dataTable = DataFacade.GetDataTable("AnswerTypeLoad",
                                                    new ParameterValue[0]);


            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            IDAnswerType = r["idAnswerType"].ToString(),
                            AnswerType = r["AnswerType"].ToString(),
                            AnswerCode = r["AnswerCode"].ToString()
                        }).ToList();
        }

        public static IEnumerable<QuestionnaireReport> ReportQuestionnaireDetail(string id)
        {
            var dataTable = DataFacade.GetDataTable("ReportQuestionnaireDetail",
                                                    new[] {new ParameterValue("idQuestionnaire", id)});

            return (from DataRow r in dataTable.Rows
                    select new QuestionnaireReport
                        {
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                            ReportDate = r["ReportDate"].ToString(),
                            UserID = r["UserID"].ToString(),
                            Name = r["Name"].ToString(),
                            Responded = r["Responded"].ToString()
                        }).ToList();
        }

        public static IEnumerable<QuestionnaireReport> ReportQuestionOptionSummary(string id)
        {
            var dataTable = DataFacade.GetDataTable("ReportQuestionOptionSummary",
                                                    new[] {new ParameterValue("idQuestionnaire", id)});

            return (from DataRow r in dataTable.Rows
                    select new QuestionnaireReport
                        {
                            QuestionOption = r["QuestionOption"].ToString(),
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                            Section = r["Section"].ToString(),
                            YesCount = r["YesCount"].ToString(),
                            Title = r["Title"].ToString()
                        }).ToList();
        }

        public static IEnumerable<QuestionnaireReport> ReportQuestionOptionDetail(string id)
        {
            var dataTable = DataFacade.GetDataTable("ReportQuestionOptionDetail",
                                                    new[] {new ParameterValue("idQuestionnaire", id)});

            return (from DataRow r in dataTable.Rows
                    select new QuestionnaireReport
                        {
                            Title = r["Title"].ToString(),
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                            Section = r["Section"].ToString(),
                            QuestionOption = r["QuestionOption"].ToString(),
                            Name = r["Name"].ToString(),
                            Self = r["Self"].ToString(),
                            Partner = r["Partner"].ToString(),
                            Third = r["Third"].ToString()
                        }).ToList();
        }

        public static IEnumerable<QuestionnaireReport> ReportQuestion(string id)
        {
            var dataTable = DataFacade.GetDataTable("ReportQuestion",
                                                    new[] {new ParameterValue("idQuestionnaire", id)});

            return (from DataRow r in dataTable.Rows
                    select new QuestionnaireReport
                        {
                            Title = r["Title"].ToString(),
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                            Section = r["Section"].ToString(),
                            QuestionOption = r["QuestionOption"].ToString(),
                            Question = r["Question"].ToString()
                        }).ToList();
        }

        public static IEnumerable<QuestionnaireReport> ReportQuestionnaireSummary(string id)
        {
            var dataTable = DataFacade.GetDataTable("ReportQuestionnaireSummary",
                                                    new[] {new ParameterValue("idQuestionnaire", id)});

            return (from DataRow r in dataTable.Rows
                    select new QuestionnaireReport
                        {
                            AnswerCount = r["AnswerCount"].ToString(),
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                            OutstandingCount = r["OutstandingCount"].ToString(),
                            ReleaseCount = r["ReleaseCount"].ToString(),
                            Title = r["Title"].ToString()
                        }).ToList();
        }

        public static List<AnswerOption> AnswerOptionLoad(Questionnaire question)
        {
            var dataTable = DataFacade.GetDataTable("AnswerOptionLoad",
                                                    new[]
                                                        {
                                                            new ParameterValue("idQuestionnaire", question.IDQuestionnaire)
                                                            , new ParameterValue("UserID", question.UserID)
                                                        });

            return (from DataRow r in dataTable.Rows
                    select new AnswerOption
                        {
                            IDQuestionnaire = r["idQuestionnaire"].ToString(),
                            IDQuestion = r["idQuestion"].ToString(),
                            IDQuestionOption = r["idQuestionOption"].ToString(),
                            Answer1 = r["Answer1"].ToString(),
                            Answer2 = r["Answer2"].ToString(),
                            Answer3 = r["Answer3"].ToString(),
                            QuestionOption = r["QuestionOption"].ToString(),
                            Section = r["Section"].ToString(),
                            ColumnSelf = r["ColumnSelf"].ToString(),
                            ColumnPartner = r["ColumnPartner"].ToString(),
                            ColumnCustom = r["ColumnCustom"].ToString(),
                            ShowOptionNumbers = r["ShowOptionNumbers"].ToString(),
                            AnswerCode = r["AnswerCode"].ToString(),
                        }).ToList();
        }

        public static IEnumerable<Questionnaire> QuestionnaireSearch(Questionnaire group)
        {
            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("DeAct", group.DeAct ? 1 : 0)
                };

            if ((group.StartYear == group.EndYear) && (group.StartMonth == group.EndMonth))
            {
                if (group.EndMonth == 12)
                {
                    group.EndYear++;
                    group.EndMonth = 1;
                }
                else
                {
                    group.EndMonth++;
                }
            }

            if (!string.IsNullOrEmpty(group.Title))
            {
                paramList.Add(new ParameterValue("Title", group.Title));
            }
            if (group.StartYear != null)
            {
                paramList.Add(new ParameterValue("StartYear", group.StartYear));
            }
            if (group.StartMonth != null)
            {
                paramList.Add(new ParameterValue("StartMonth", group.StartMonth));
            }
            if (group.EndYear != null)
            {
                paramList.Add(new ParameterValue("EndYear", group.EndYear));
            }
            if (group.EndMonth != null)
            {
                paramList.Add(new ParameterValue("EndMonth", group.EndMonth));
            }

            var dataTable = DataFacade.GetDataTable("QuestionnaireSearch", paramList.ToArray());

            return (from DataRow r in dataTable.Rows
                    select new Questionnaire
                        {
                            IDQuestionnaire = r["idQuestionnaire"].ToString(),
                            Title = r["Title"].ToString(),
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                            Logo = r["Logo"].ToString(),
                            Description = r["Description"].ToString(),
                            Complete = r["Complete"].ToString(),
                            ShowNumbers = r["ShowNumbers"].ToString(),
                            Active = r["Active"].ToString(),
                            ReleaseGroup = r["ReleaseGroup"].ToString(),
                            ReleaseUserID = r["ReleaseUserID"].ToString()
                        }).ToList();
        }

        public static IEnumerable<Questionnaire> TemplateQuestionnaireSearch(Questionnaire group)
        {
            if ((group.StartYear == group.EndYear) && (group.StartMonth == group.EndMonth))
            {
                if (group.EndMonth == 12)
                {
                    group.EndYear++;
                    group.EndMonth = 1;
                }
                else
                {
                    group.EndMonth++;
                }
            }

            var paramList = new List<ParameterValue>
                {
                    new ParameterValue("DeAct", group.DeAct ? 1 : 0)
                };

            if (!string.IsNullOrEmpty(group.Title))
            {
                paramList.Add(new ParameterValue("Title", group.Title));
            }
            if (group.StartYear != null)
            {
                paramList.Add(new ParameterValue("StartYear", group.StartYear));
            }
            if (group.StartMonth != null)
            {
                paramList.Add(new ParameterValue("StartMonth", group.StartMonth));
            }
            if (group.EndYear != null)
            {
                paramList.Add(new ParameterValue("EndYear", group.EndYear));
            }
            if (group.EndMonth != null)
            {
                paramList.Add(new ParameterValue("EndMonth", group.EndMonth));
            }

            var dataTable = DataFacade.GetDataTable("TemplateQuestionnaireSearch", paramList.ToArray());

            return (from DataRow r in dataTable.Rows
                    select new Questionnaire
                        {
                            IDTempQuestionnaire = r["idTemplateQuestionnaire"].ToString(),
                            Title = r["Title"].ToString(),
                            DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                            Logo = r["Logo"].ToString(),
                            Description = r["Description"].ToString(),
                            Complete = r["Complete"].ToString(),
                            TemplateName = r["TemplateName"].ToString(),
                            ShowNumbers = r["ShowNumbers"].ToString(),
                            Active = r["Active"].ToString(),
                            ReleaseGroup = r["ReleaseGroup"].ToString(),
                            ReleaseUserID = r["ReleaseUserID"].ToString()
                        }).ToList();
        }

        public static string QuestionnaireEdit(Questionnaire group)
        {

            var paramList = new List<ParameterValue>();

            if (!string.IsNullOrEmpty(group.IDQuestionnaire))
            {
                paramList.Add(new ParameterValue("idQuestionnaire", group.IDQuestionnaire));
            }
            if (!string.IsNullOrEmpty(group.IDTempQuestionnaire))
            {
                paramList.Add(new ParameterValue("idTempQuestionnaire", group.IDTempQuestionnaire));
            }
            if (!string.IsNullOrEmpty(group.DateQuestionnaire))
            {
                paramList.Add(new ParameterValue("DateQuestionnaire", group.DateQuestionnaire));
            }
            if (!string.IsNullOrEmpty(group.Title))
            {
                paramList.Add(new ParameterValue("Title", group.Title));
            }
            if (!string.IsNullOrEmpty(group.Logo))
            {
                paramList.Add(new ParameterValue("Logo", group.Logo));
            }
            if (!string.IsNullOrEmpty(group.Description))
            {
                paramList.Add(new ParameterValue("Description", group.Description));
            }
            if (!string.IsNullOrEmpty(group.Complete))
            {
                paramList.Add(new ParameterValue("Complete", group.Complete));
            }
            if (!string.IsNullOrEmpty(group.ShowNumbers))
            {
                paramList.Add(new ParameterValue("ShowNumbers", group.ShowNumbers));
            }
            if (!string.IsNullOrEmpty(group.ReleaseGroup))
            {
                paramList.Add(new ParameterValue("ReleaseGroup", group.ReleaseGroup));
            }
            if (!string.IsNullOrEmpty(group.ReleaseUserID))
            {
                paramList.Add(new ParameterValue("ReleaseUserID", group.ReleaseUserID));
            }
            if (!string.IsNullOrEmpty(group.TemplateName))
            {
                paramList.Add(new ParameterValue("TemplateName", group.TemplateName));
            }

            DataRow r = DataFacade.GetDataRow("QuestionnaireEdit", paramList.ToArray());

            string idQuestionnaire = r["idQuestionnaire"].ToString();
            return idQuestionnaire;
        }


        public static IEnumerable<Questionnaire> Search(Questionnaire group)
        {
            var paramList = new List<ParameterValue>();
            if (!String.IsNullOrEmpty(group.IDQuestionnaire))
            {
                paramList.Add(new ParameterValue("idQuestionnaire", group.IDQuestionnaire));
            }
            if (!String.IsNullOrEmpty(group.UserID))
            {
                paramList.Add(new ParameterValue("UserID", group.UserID));
            }
            if (!String.IsNullOrEmpty(group.Name))
            {
                paramList.Add(new ParameterValue("Name", group.Name));
            }

            var dataTable = DataFacade.GetDataTable("AnswerSearch", paramList.ToArray());

            var returnList = (from DataRow r in dataTable.Rows
                              select new Questionnaire
                                  {
                                      Name = r["Name"].ToString(),
                                      UserID = r["UserID"].ToString(),
                                      IDQuestionnaire = r["idQuestionnaire"].ToString(),
                                      DateAnswer = r["DateAnswer"].ToString()
                                  }).ToList();

            if (returnList.Count > 0)
            {
                return returnList;
            }

            return null;

        }

        public static List<Questionnaire> QuestionnaireInbox(Questionnaire group)
        {
            var paramList = new List<ParameterValue>();

            if (!String.IsNullOrEmpty(group.UserID))
            {
                paramList.Add(new ParameterValue("UserID", group.UserID));
            }


            var dataTable = DataFacade.GetDataTable("QuestionnaireInbox", paramList.ToArray());

            var returnList = (from DataRow r in dataTable.Rows
                              select new Questionnaire
                                  {
                                      Title = r["Title"].ToString(),
                                      DateQuestionnaire = r["DateQuestionnaire"].ToString(),
                                      IDQuestionnaire = r["idQuestionnaire"].ToString(),
                                      DaysLeft = r["DaysLeft"].ToString()
                                  }).ToList();

            if (returnList.Count != 0)
            {
                return returnList;
            }

            return null;

        }
    }
}
