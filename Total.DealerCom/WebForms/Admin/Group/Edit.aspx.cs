using System;
using System.Collections.Generic;
using Total.DealerCom.DataAccessLayer.Utility;
using System.Web.UI.WebControls;

namespace TotalDealer_2008.Group
{
    public partial class Edit : BasePage
    {
        private string _groupId = string.Empty;
        private string _groupName = string.Empty;
        private string _special = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["GroupId"] != null)
            {
                _groupId = Request["GroupId"];
            }
            if (Request["GroupName"] != null)
            {
                _groupName = Request["GroupName"];
            }
            if (Request["Special"] != null)
            {
                _special = Request["Special"];
                if(_special.ToUpper() != "USER GROUP")
                {
                    txtGroupName.ReadOnly = true;
                }
            }

            if (!IsPostBack)
            {
                LookupSetup();
                txtGroupName.Text = _groupName;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if(txtGroupName.Text != string.Empty)
            {
                string result = FacadeRepository.GetGroupFacade().Edit(_groupId, txtGroupName.Text);
                if (result != string.Empty)
                {
                    lblStatus.Text = _groupName + " group updated.";
                    Response.Redirect("Search.aspx?Message=Group updated", true);
                }
                else
                {
                    lblStatus.Text = _groupName + " update failed.";
                }
            }
            else
            {
                lblError.Text = "Group name cannot be empty.";
                txtGroupName.Focus();
            }

            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx", true);
        }

        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            var data = Util.GetSelectedOptions(grdMembers, "UserSelector");
            if(data == string.Empty)
            {
                lblError.Text = "No members selected to remove.";
                return;
            }


            FacadeRepository.GetGroupFacade().GroupMemberDelete("" + _groupId + "", data);
            LookupSetup();
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            var data = Util.GetSelectedOptions(grdNonMembers, "UserSelector");
            if (data == string.Empty)
            {
                lblError.Text = "No members selected to add.";
                return;
            }

            FacadeRepository.GetGroupFacade().GroupMemberInsert("" + _groupId + "", data);
            LookupSetup();
        }
        


        private void LookupSetup()
        {
            BindMemberData();
            BindNonMemberData();
        }

        /// <summary>
        /// Performs search and binds search results to grid control
        /// </summary>
        private void BindMemberData()
        {
            IEnumerable<Total.DealerCom.Core.User> data = FacadeRepository.GetGroupFacade().GetGroupMembersIncluded(_groupId);

            grdMembers.DataSource = data;
            grdMembers.DataBind();
        }

        /// <summary>
        /// Performs search and binds search results to grid control
        /// </summary>
        private void BindNonMemberData()
        {
            IEnumerable<Total.DealerCom.Core.User> data = FacadeRepository.GetGroupFacade().GetGroupMembersNotIncluded(_groupId);

            grdNonMembers.DataSource = data;
            grdNonMembers.DataBind();
        }
       

        protected void grdNonMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNonMembers.PageIndex = e.NewPageIndex;
            BindNonMemberData();
        }

        protected void grdMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMembers.PageIndex = e.NewPageIndex;
            BindMemberData();
        }


       
    }
}
