using System;
using System.Configuration;
using System.Net.Mail;
using System.Xml;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;
using Services.Utility;
using MailMessage=System.Net.Mail.MailMessage;

namespace Services.Facade
{
    public class EmailFacade : IEmailFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string SendEmail(Email email)
        {
            return EmailDao.SendEmail(ref email);
        }

        public void SendMerchandiseEmail(Email email)
        {
            var client = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);
            var mailMessage = new MailMessage
            {
                From = new MailAddress(ConfigurationManager.AppSettings["StandingDryAdminEmailFrom"])
            };
            mailMessage.To.Add(new MailAddress(ConfigurationManager.AppSettings["MerchandiseEmailTo"]));
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "Merchandising DVD Request";
            mailMessage.Body = "Name: " + email.Name + "<br/>Surname: " + email.Surname + "<br/>Site Name: " + email.SiteName + "<br/>Site Address: " + email.SiteAddress + "<br/>Contact Number: " + email.Contact;

            try
            {
                //Sending email to dealer informing them of the online change
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to send email to " + ConfigurationManager.AppSettings["MerchandiseEmailTo"] + ". " + e.Message, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestStatus"></param>
        /// <param name="instance"></param>
        public void SendEmail(string requestStatus, IssueResult instance)
        {
            string strXslt = "", strAdminXslt = "";
 
            var template = new Email();
            if(requestStatus == Constants.REQUEST_STATUS_OPEN)
            {
                template.Subject = "Instance added";
                template.AdminSubject = "A new Instance has been added";
                template._Email = instance.Email;
                template.AdminEmail = ConfigurationManager.AppSettings["StandingDryAdminEmail"];
                strXslt = ("DealerCreateInstanceLetterTemplate");
                strAdminXslt = ("AdminCreateInstanceLetterTemplate");
            }

            if (requestStatus == Constants.REQUEST_STATUS_CLOSED)
            {
                template.Subject = "Instance closed";
                template.AdminSubject = "An Instance has been closed";
                template._Email = instance.Email;
                template.AdminEmail = ConfigurationManager.AppSettings["StandingDryAdminEmail"];
                strXslt = ("DealerClosedInstanceLetterTemplate");
                strAdminXslt = ("AdminClosedInstanceLetterTemplate");
            }

            if (requestStatus == Constants.REQUEST_STATUS_RETRACTED)
            {
                template.Subject = "Instance retracted";
                template.AdminSubject = "An Instance has been retracted";
                template._Email = instance.Email;
                template.AdminEmail = ConfigurationManager.AppSettings["StandingDryAdminEmail"];
                strXslt = ("DealerRetractedInstanceLetterTemplate");
                strAdminXslt = ("AdminRetractedInstanceLetterTemplate");
            }
          
            var client = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);

            string templatepath = ConfigurationManager.AppSettings["EmailTemplates"];
		    XmlDocument doc = XsltTransformer.Render(instance, templatepath + strXslt + ".xslt");
           
		    var mailMessage = new MailMessage
		                          {
		                              From = new MailAddress(ConfigurationManager.AppSettings["StandingDryAdminEmailFrom"])
		                          };
		    mailMessage.To.Add(new MailAddress(template._Email));
		    mailMessage.IsBodyHtml = true;
            mailMessage.Subject = template.Subject;
            mailMessage.Body = doc.InnerXml;

            try
            {
                //Sending email to dealer informing them of the online change
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to send email to " + template._Email + ". " + e.Message, e);
            }
           

            doc = XsltTransformer.Render(instance, templatepath + strAdminXslt + ".xslt");
            mailMessage = new MailMessage
                              {
                                  From =
                                      new MailAddress(ConfigurationManager.AppSettings["StandingDryAdminEmailFrom"])
                              };
		    mailMessage.To.Add(new MailAddress(template.AdminEmail));
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = template.AdminSubject;
            mailMessage.Body = doc.InnerXml;

            //Sending email to administration about the change
            try
            {
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                //Creating nicely formatted exception
                throw new Exception("Failed to send email to " + template.AdminEmail + ". " + e.Message, e);
            }
			
        }

        public void SendDealerEmail(Dealer dealer)
        {
            

            var template = new Email();

            template.Subject = "Dealer Updated Contact Details";
           
            template._Email = ConfigurationManager.AppSettings["DealerUpdateEmail"];
            const string strXslt = ("DealerUpdateTemplate");


            var client = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);

            string templatepath = ConfigurationManager.AppSettings["EmailTemplates"];
            XmlDocument doc = XsltTransformer.Render(dealer, templatepath + strXslt + ".xslt");

            var mailMessage = new MailMessage
                                  {
                                      From = new MailAddress(dealer.DealerEmail)
                                  };
            mailMessage.To.Add(new MailAddress(template._Email));
            mailMessage.CC.Add(dealer.DealerEmail);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = template.Subject;
            mailMessage.Body = doc.InnerXml;

            try
            {
                //Sending email to dealer informing them of the online change
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to send email to " + template._Email + ". " + e.Message, e);
            }




        }

        public void SendFAQEmail()
        {
            var template = new Email();

            template.Subject = "FAQ Message";

            template._Email = ConfigurationManager.AppSettings["FAQEmail"];
            const string strXslt = ("FAQEmailTemplate");


            var client = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);

            string templatepath = ConfigurationManager.AppSettings["EmailTemplates"];
          
            var mailMessage = new MailMessage
            {
                From = new MailAddress(template._Email)
            };
            mailMessage.To.Add(new MailAddress(template._Email));
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = template.Subject;
            mailMessage.Body = "A new FAQ message has been posted";

            try
            {
                //Sending email to dealer informing them of the online change
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to send email to " + template._Email + ". " + e.Message, e);
            }




        }

    }
}
