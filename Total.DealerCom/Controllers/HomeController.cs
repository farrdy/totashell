using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Context;
using System.Web.Optimization;
using Total.DealerCom.DataAccessLayer;

namespace Total.DealerCom.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        #region Shared MasterPage methods

        private static string _userStatus = string.Empty;
        private string xmlMenuData { get; set; }

        private void PerformLogin()
        {

            xmlMenuData =
               WebSiteContext.GetInstance().FacadeRepository.GetUserFacade().GetMenuItems(
                   Session[Constants.UserID].ToString());


            //Saving the bit of menu XML to session
            Session["MainMenu"] = xmlMenuData;
            Session["Login"] = null;
        }
        
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetMainMenu()
        {
            //Checking if user is logged on, else transfer user to logon screen
            if (Session[Constants.UserID] == null)
            {
                //Checking if the session has expired
                return RedirectToRoute("ExpiredLogin");
                //Response.Redirect("~/Login.aspx?Expired=true");
                
            }
            else
            {
                //We don't want to reload the menu everytime the masterpage is merged with the content page
                //TODO: Encapsulate the menu call below to a stored procedure. One probably already exists
                if (Session["MainMenu"] == null)
                {
                    PerformLogin();
                }
                else
                {
                    if (Session["Login"] != null)
                    {
                        if (Session["Login"].ToString() == "true")
                        {
                            PerformLogin();
                        }
                    }

                    //Loading the menu from session
                    if (Session["MainMenu"] != null)
                    {
                        xmlMenuData = Session["MainMenu"].ToString();
                        Session["MainMenu"] = xmlMenuData;
                        Session["Login"] = null;
                    }
                    //else
                    //{
                    //    xmlMenuData = null;
                    //}
                }

                ViewBag.Menu = xmlMenuData;
                return PartialView("Partials/MainMenu");
            }
            
           // return View("~/Views/Shared/Partials/MainMenu.cshtml");
        }

        public ActionResult GetFooter()
        {
            return PartialView("Partials/Footer");
        }

    }
}