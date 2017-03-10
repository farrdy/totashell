using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.DataAccess
{
    /// <summary>
    /// MailTemplateDao Domain Object
    /// </summary>
    public partial class MailTemplateDao
    {

        public static string Add(MailTemplate mailtemplate)
        {

            var r = DataFacade.GetDataRow("MailTemplateInsert",
             new ParameterValue("TemplateID", mailtemplate.TemplateID),

             new ParameterValue("TemplateHTML", mailtemplate.TemplateHTML)

             );

            string TemplateName = Convert.ToString(r["TemplateName"]);
            return TemplateName;
        }

        public static string Update(MailTemplate mailtemplate)
        {

            var r = DataFacade.GetDataRow("MailTemplateUpdate",
             new ParameterValue("TemplateID", mailtemplate.TemplateID),
              new ParameterValue("TemplateName", mailtemplate.TemplateName),
             new ParameterValue("TemplateHTML", mailtemplate.TemplateHTML)

             );

            string TemplateName = Convert.ToString(r["TemplateName"]);
            return TemplateName;
        }

        public static MailTemplate MailTemplateGet(string templatename)
        {
            MailTemplate mailtemplate = new MailTemplate();
            var paramList = new List<ParameterValue>();

            paramList.Add(new ParameterValue("TemplateName", templatename));

            var r = DataFacade.GetDataRow("MailTemplateGet",
                                          paramList.ToArray());
            if (r != null)
            {
                Populate(mailtemplate, r);
            }
            return mailtemplate;
        }


        public static List<MailTemplate> GetAll()
        {

            var paramList = new List<ParameterValue>();

            var dataTable = DataFacade.GetDataTable("MailTemplateGetAll",
                                                    paramList.ToArray());

            var returnList = new List<MailTemplate>();

            foreach (DataRow r in dataTable.Rows)
            {
                MailTemplate mailtemplate = new MailTemplate();
                Populate(mailtemplate, r);
                returnList.Add(mailtemplate);

            }

            return returnList;
        }

        private static MailTemplate Populate(MailTemplate mailtemplate, DataRow dr)
        {
            if (dr["TemplateID"] != DBNull.Value) mailtemplate.TemplateID = Convert.ToInt32(dr["TemplateID"]);

            if (dr["TemplateName"] != DBNull.Value) mailtemplate.TemplateName = Convert.ToString(dr["TemplateName"]);

            if (dr["TemplateHTML"] != DBNull.Value) mailtemplate.TemplateHTML = Convert.ToString(dr["TemplateHTML"]);
          return mailtemplate;
        }

    }

}



