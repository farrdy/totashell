using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using Infrastructure.Shared.Security;
using Infrastructure.UI.Security;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace TotalDealer_2008
{
    public partial class Login : BasePage
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = GetApplicationVersion();
            Title = "Login - Total Dealer Communication";
            txtUserName.Focus();

            lblURL.Text = "email";
            lblURL.NavigateUrl = "mailto:" + ConfigurationManager.AppSettings["ContactEmail"];
            
            if(!string.IsNullOrEmpty(Request["Logout"]))
            {
                if(Request["Logout"] == "true")
                {
                    lblMessage.Text = "You have logged out.";
                    Session.Clear();
                }
            }

            if (!string.IsNullOrEmpty(Request["Expired"]))
            {
                if (Request["Expired"] == "true")
                {
                    lblMessage.Text = "Your session has expired. Please log in again.";
                    Session.Clear();
                }
            }
        }

        protected string GetApplicationVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


        protected void BtnResetPasswordClick(object sender, EventArgs e)
        {
            Response.Redirect("User/PasswordReset.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Clear();

            lblMessage.Text = string.Empty;
            if(txtPassword.Text == string.Empty || txtUserName.Text == string.Empty)
            {
                lblMessage.Text = "Please enter both the username and password.";
                return;
            }

            
            
            LoginUser(txtUserName.Text, txtPassword.Text);
        }

        public void LoginUser(string userName, string userPassword)
        {
            IUserFacade userFacade = FacadeRepository.GetUserFacade();
            lblMessage.Text = string.Empty;
            SecurityUser securityUser = null;
            try
            {
                securityUser = userFacade.Authenticate(userName, userPassword);

            }
            catch (System.Threading.ThreadAbortException se)
            {
                lblMessage.Text = se.Message;
            }
            catch (SecurityException se)
            {
                lblMessage.Text = se.Message;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

            if (securityUser != null)
            {
                
                SecurityManager.CurrentUser = securityUser;

                Session[Constants.UserID] = securityUser.UserId;
                Session[Constants.RoleID] = securityUser.RoleId;
                Session[Constants.PermissionString] = securityUser.UserPermission;
                Session[Constants.Name] = securityUser.Name;

                

                if (Request.QueryString["ReturnUrl"] != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(userName, false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                }

                if (!securityUser.MustChangePassword)
                {
                    Response.Redirect("~/Welcome.aspx", false);
                    Response.Redirect("~/WebForms/Admin/User/Search.aspx", false);
                }
                else
                {
                    Response.Redirect("User/ChangePassword.aspx?Id=" + securityUser.UserId + "&Pass=" +
                                    HashHelper.Hash(userPassword) + "&Delete=True", false);
                }
            }


        }
       
    }
}
