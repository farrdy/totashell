using System;
using Infrastructure.Shared.Security;
using Infrastructure.UI.Security;
using Total.DealerCom.DataAccessLayer;

namespace TotalDealer_2008.LoginAs
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Request["UserID"];

            if (!string.IsNullOrEmpty(userId))
            {
                if (Session[Constants.RoleID].ToString() == Constants.ROLE_ADMIN || Session[Constants.RoleID].ToString() == Constants.ROLE_SUPERADMIN)
                {
                    Session[Constants.AdminUserID] = Session[Constants.UserID];
                    Session[Constants.AdminRoleID] = Session[Constants.RoleID];
                    Session[Constants.AdminPermissionString] = Session[Constants.PermissionString];
                    Session[Constants.AdminName] = Session[Constants.Name];
                }

                SecurityUser user = FacadeRepository.GetUserFacade().UserLoginAs(userId);

                Session[Constants.UserID] = user.UserId;
                Session[Constants.RoleID] = user.RoleId;
                Session[Constants.PermissionString] = user.UserPermission;
                Session[Constants.Name] = user.Name;

                SecurityManager.CurrentUser = user;

                Session["Login"] = "true";

                Response.Redirect("~/Home/Index", false);
            }
        }
    }
}
