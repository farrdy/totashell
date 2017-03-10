using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Total.DealerCom.DataAccessLayer.Utility;

namespace TotalDealer_2008.Group
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Setting homepage message if one was requested
                if (Request["Message"] != null) lblStatus.Text = Request["Message"];
                else
                {
                    lblStatus.Text = string.Empty;
                }

                btnDelete.Visible = false;
            }
        }

        /// <summary>
        /// Performs search and binds search results to grid control
        /// </summary>
        private void BindData()
        {
            var param = new Total.DealerCom.Core.Group();

            param.GroupName = txtGroupName.Text;

            param.MemberName = txtName.Text;

            param.MemberId = txtNo.Text;

            IEnumerable<Total.DealerCom.Core.Group> data = FacadeRepository.GetGroupFacade().Search(param);

            grdResults.DataSource = data;
            grdResults.DataBind();

            //Clearing checkbox controls for groups that are not user groups. So users cannot delete them.
            for (int i=0;i <grdResults.Rows.Count;i++)
            {
                if (grdResults.Rows[i].Cells[2].Text.ToUpper() != "USER GROUP")
                {
                    grdResults.Rows[i].Cells[0].Controls.Clear();
                }
            }

            if (grdResults.Rows.Count > 0)
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
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

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add.aspx", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var data = Util.GetSelectedOptions(grdResults, "UserSelector");
            if(data == string.Empty)
            {
                lblError.Text = "No groups selected to delete.";
            }
            else
            {
                FacadeRepository.GetGroupFacade().Delete(data);
                BindData();
            }
        }


    }
}
