using System;
using Total.DealerCom.DataAccessLayer;
using System.Linq;
using WebUI.Context;
using System.Web.Optimization;


namespace TotalDealer_2008
{
    public partial class Master : System.Web.UI.MasterPage
    {
        //private static string _userStatus = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Title.Text = "Total Dealer Communication";

            //if (Session["Name"] != null)
            //{
            //    MasterPageUserLabel = "Logged on user: " + Session["Name"] + " ";
            //}
            //else
            //{
            //    if (Session["AdminName"] != null)
            //    {
            //        MasterPageUserLabel = "Logged on user: " + Session["AdminName"] + ". Logged on as: " +
            //                                 Session["Name"] + " ";
            //    }
            //}

            ////Checking if user is logged on, else transfer user to logon screen
            //if(Session[Constants.UserID] == null)
            //{
            //    //Checking if the session has expired
            //    Response.Redirect("~/Login.aspx?Expired=true");
            //}
            //else
            //{
            //    //We don't want to reload the menu everytime the masterpage is merged with the content page
            //    //TODO: Encapsulate the menu call below to a stored procedure. One probably already exists
            //    if ((!IsPostBack && Session[menu.ID] == null))
            //    {
            //        PerformLogin();
            //    }
            //    else
            //    {
            //        if (Session["Login"] != null)
            //        {
            //            if(Session["Login"].ToString() == "true")
            //            {
            //                PerformLogin();
            //            }
            //        }

            //        //Loading the menu from session
            //        if (Session[menu.ID] != null)
            //        {
            //            xmlDataSource.Data = Session[menu.ID].ToString();
            //            Session[menu.ID] = xmlDataSource.Data;
            //            Session["Login"] = null;
            //        }
            //        else
            //        {
            //            xmlDataSource.Data = null;
            //        }
            //    }  
            //}
            //SetFocus();
        }

        //private void PerformLogin()
        //{
        //    string xmlString =
        //        WebSiteContext.GetInstance().FacadeRepository.GetUserFacade().GetMenuXml(
        //            Session[Constants.UserID].ToString());

        //    if(xmlString == string.Empty)
        //    {
        //        Session[menu.ID] = null;
        //        return;
        //    }

        //    xmlDataSource.Data = xmlString;

        //    //Saving the bit of menu XML to session
        //    Session[menu.ID] = xmlDataSource.Data;
        //    Session["Login"] = null;
        //}

        //public string MasterPageUserLabel
        //{
        //    get { return _userStatus; }
        //    set { _userStatus = value; }
        //} 

        //protected void SetFocus()
        //{
        //    var control = MainContentPlaceholder.Controls.Cast<System.Web.UI.Control>()
        //      .Where(o => o is System.Web.UI.WebControls.TextBox)
        //      .FirstOrDefault();

        //    if (control != null)
        //    {
        //        control.Focus();
        //    }
        //}

        //protected void lblUsers_Load(object sender, EventArgs e)
        //{
        //    lblUsers.Text = _userStatus;
        //}
    }
}
