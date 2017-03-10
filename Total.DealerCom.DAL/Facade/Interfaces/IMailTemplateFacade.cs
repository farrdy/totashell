using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Services.DTO;


namespace Services.Facade.Interfaces
{
    /// <summary>
    /// IMailTemplatefacade  
    /// </summary>
    public interface IMailTemplateFacade
    {

        string Add(MailTemplate mailtemplate);

        string Update(MailTemplate mailtemplate);

        MailTemplate MailTemplateGet(string templatename);

        List<MailTemplate> GetAll();

        List<string> PopulateMailTemplateList(ref DropDownList dropDownList);

    }

}

