using Infrastructure.Shared.Security;
using Infrastructure.UI.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;
using TotalDealer_2008;
using WebUI.Context;
using Total.DealerCom.DataAccessLayer.Utility;
using System.Web.Security;

namespace Total.DealerCom.Web.Controllers
{
    public class SecurityUserController : Controller
    {
        public static string UserName { get; set; }
        private readonly SessionManager _sessionManager;

        public SecurityUserController(BasePage page)
        {
            _sessionManager = new SessionManager(page);
        }

        public SecurityUserController()
        {
 
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string userPassword)
        {

                IUserFacade userFacade = FacadeRepository.GetUserFacade();

                SecurityUser securityUser = null;
                try
                {
                    securityUser = userFacade.Authenticate(userName, userPassword);

                }
                catch (System.Threading.ThreadAbortException se)
                {
                    ViewBag.Message = se.Message;
                }
                catch (SecurityException se)
                {
                    ViewBag.Message = se.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }

                if (securityUser != null)
                {
                    SecurityManager.CurrentUser = securityUser;

                    Session[Constants.UserID] = securityUser.UserId;
                    Session[Constants.RoleID] = securityUser.RoleId;
                    Session[Constants.PermissionString] = securityUser.UserPermission;
                    Session[Constants.Name] = securityUser.Name;

                    UserName = securityUser.Name;

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
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Response.Redirect("User/ChangePassword.aspx?Id=" + securityUser.UserId + "&Pass=" +
                                        HashHelper.Hash(userPassword) + "&Delete=True", false);
                    }
                }
                else
                {
                    ViewBag.WrongCredentials = "Username or password is incorrect.";
                }
          
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public void ResetUserPassword(String userId)
        {
            ViewBag.Error = string.Empty;
            
            if (String.IsNullOrEmpty(userId))
            {
                ViewBag.Error = "User ID is mandatory";
                return;
            }

            //Attempt to get new password for user
            var newPassword = FacadeRepository.GetUserFacade().ResetPassword(new Total.DealerCom.Core.User { Id = userId });

            if (newPassword != string.Empty)
            {
                //Attempting to email the new password to the user
                var email = FacadeRepository.GetUserFacade().SendUserPassword(newPassword,
                                                                                    new Total.DealerCom.Core.User { Id = userId });
                ViewBag.Status = "Password sent to email address: " + email;
            }
            else
            {
                throw new Exception("Password reset failed.");
            }
        }

        [HttpPost]
        public void ChangePassword(String userIdreset, String oldPassword, String newPassword, String confirmPassword)
        {
            //Attempt to get new password for user
            ViewBag.Error = string.Empty;

            if(String.IsNullOrEmpty(userIdreset))
            {
                ViewBag.Error = "User ID is mandatory";
                return;
            }

            if (String.IsNullOrEmpty(oldPassword))
            {
                ViewBag.Error = "Old Password is mandatory";
                return;
            }
            if (String.IsNullOrEmpty(newPassword))
            {
                ViewBag.Error  = "New Password is mandatory";
                return;
            }
            if(newPassword != confirmPassword)
            {
                ViewBag.Error = "New password not correctly confirmed.";
                return;
            }
           
            var dataRow = FacadeRepository.GetUserFacade().UpdatePassword(new Total.DealerCom.Core.User { Id = userIdreset, OldPassword = oldPassword, NewPassword = newPassword});

            ViewBag.StatusMessage = dataRow == null ? "Password change failed." : "Password change successful.";

            userIdreset = string.Empty;
            confirmPassword = string.Empty;
            oldPassword = string.Empty;
            newPassword = string.Empty;
        }
    

        /// <summary>
        /// Facade repository - Gives access to all other facades. Maybe use Unity later on; although this is cleaner.
        /// </summary>
        public static IFacadeFactory FacadeRepository
        {
            get
            {
                return WebSiteContext.GetInstance().FacadeRepository;
            }
        }

        /// <summary>
        /// Return the page namespace and class name as unique identifier
        /// </summary>
        //public string ScreenId
        //{
        //    get
        //    {
        //        return Page.GetType().BaseType.FullName;
        //    }
        //}

        public SessionManager SessionState
        {
            get { return _sessionManager; }
        }

        #region Nested type: SessionKeys

        protected class GlobalSessionKeys
        {
            //Put all global session goodies here!!;
        }

        #endregion
    }
}

