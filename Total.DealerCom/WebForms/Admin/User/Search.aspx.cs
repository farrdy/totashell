using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Utility;

namespace TotalDealer_2008.User
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

                if(Request["Updated"] != null)
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
            //Getting article categories
            FacadeRepository.GetLookupFacade().Populate(ref dropdownSalesArea,
                new LookupSearch { IDParent = null, Lookup = Constants.SalesArea, ShowInactive = false }, true);

            Session["RoleList"] = FacadeRepository.GetUserFacade().PopulateRoleList(ref dropdownUserType);

            //Initially buttons invisible
            btnDeactivate.Visible = false;
            //btnReactivate.Visible = false;
        }

        /// <summary>
        /// Performs search and binds search results to grid control
        /// </summary>
        private void BindData()
        {
            var param = new Total.DealerCom.Core.User();

            param.UserName = txtName.Text;
            //param.idSalesArea = dropdownSalesArea.SelectedValue;

            param.IDSalesArea = dropdownSalesArea.SelectedValue;
                //Convert.ToString(FacadeRepository.GetLookupFacade().ReturnLookupId(Constants.SalesArea,
                                                                              //dropdownSalesArea.SelectedValue));

            param.DeAct = chkDeactive.Checked;

            //if (Session["RoleList"] != null) roleList = (List<string>)Session["RoleList"];
            param.IDRole = dropdownUserType.SelectedValue;
                //roleList[dropdownUserType.SelectedIndex];
            
            param.Id = txtUserID.Text;

            IEnumerable<Total.DealerCom.Core.User> data = FacadeRepository.GetUserFacade().Search(param);

            grdResults.DataSource = data;
            grdResults.DataBind();

            if (grdResults.Rows.Count != 0)
            {
                btnDeactivate.Visible = !param.DeAct;
                //btnReactivate.Visible = param.DeAct;
            }
            else
            {
                btnDeactivate.Visible = false;
                //btnReactivate.Visible = false;
            }

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

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            var list = Util.GetSelectedOptionsNonString(grdResults, "UserSelector");
            FacadeRepository.GetUserFacade().Deactivate(list);
            BindData();
        }

        protected void btnReactivate_Click(object sender, EventArgs e)
        {
            var list = Util.GetSelectedOptionsNonString(grdResults, "UserSelector");
            FacadeRepository.GetUserFacade().Activate(list);
            BindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add.aspx", false);
        }
    }
}
