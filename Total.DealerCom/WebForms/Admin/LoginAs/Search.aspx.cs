using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TotalDealer_2008.LoginAs
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Title = "User Search";

            if (!IsPostBack)
            {
                lblStatus.Text = string.Empty;
                LookupSetup();

                if (Request["Updated"] != null)
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = Request["Updated"];
                }
                else
                {
                    lblStatus.Visible = false;
                    lblStatus.Text = string.Empty;
                }
            }

        }

        /// <summary>
        /// Sets up initial control values
        /// </summary>
        public void LookupSetup()
        {
            Session["RoleList"] = FacadeRepository.GetUserFacade().PopulateRoleList(ref dropdownUserType);
        }

        /// <summary>
        /// Performs search and binds search results to grid control
        /// </summary>
        private void BindData()
        {
            var param = new Total.DealerCom.Core.User();

            param.UserName = txtName.Text;
            
            param.IDRole = dropdownUserType.SelectedValue;

            param.Id = txtUserID.Text;

            IEnumerable<Total.DealerCom.Core.User> data = FacadeRepository.GetUserFacade().Search(param);

            grdResults.DataSource = data;
            grdResults.DataBind();
        }

        protected void grdResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdResults.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grdResults.PageIndex = 0;
            lblStatus.Text = string.Empty;
            BindData();
        }
        
    }
}
