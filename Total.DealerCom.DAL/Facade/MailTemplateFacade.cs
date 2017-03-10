using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;
using System.Web.UI.WebControls;


namespace Services.Facade
{
    /// <summary>
    /// MailTemplatefacade  
    /// </summary>
    public class MailTemplateFacade : IMailTemplateFacade
    {

        public string Add(MailTemplate mailtemplate)
        {

            return MailTemplateDao.Add(mailtemplate);
        }

        public string Update(MailTemplate mailtemplate)
        {

            return MailTemplateDao.Update(mailtemplate);
        }

        public MailTemplate MailTemplateGet(string templatename)
        {
            return MailTemplateDao.MailTemplateGet(templatename);
        }


        public List<MailTemplate> GetAll()
        {
            return MailTemplateDao.GetAll();
        }

        public List<string> PopulateMailTemplateList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var mailtemplate = MailTemplateDao.GetAll();
            var returnList = new List<string>();
            returnList.Add("--Select a template--");
            dropDownList.Items.Add(new ListItem("--Select a template--"));
            foreach (var p in mailtemplate)
            {
                returnList.Add(p.TemplateName);
                dropDownList.Items.Add(new ListItem(p.TemplateName));
            }
            dropDownList.SelectedIndex = 0;
            return returnList;
        }
    }

}







