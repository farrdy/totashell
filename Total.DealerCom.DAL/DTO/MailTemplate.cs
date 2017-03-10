using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.DTO
{
    /// <summary>
    /// MailTemplateDTO Domain Object
    /// </summary>
    public partial class MailTemplate
    {

        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string TemplateHTML { get; set; }

    }

}

