using System;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Utility;

namespace TotalDealer_2008.User
{
    public partial class Edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Title = "Edit User";
            txtUserID.ReadOnly = true;

            if (!IsPostBack)
            {
                LookupSetup();

                LoadUser();
            }
        }

        /// <summary>
        /// Sets up initial control values
        /// </summary>
        public void LookupSetup()
        {
            lblError.Text = string.Empty;

            //Populating sales area dropdown
            FacadeRepository.GetLookupFacade().Populate(ref dropdownSalesArea,
                new LookupSearch { IDParent = null, Lookup = Constants.SalesArea, ShowInactive = false }, false);

            //Populating regions dropdown
            FacadeRepository.GetLookupFacade().Populate(ref dropdownRegion,
    new LookupSearch { IDParent = null, Lookup = Constants.Region, ShowInactive = false }, false);

            FacadeRepository.GetUserFacade().PopulateRoleList(ref dropdownUserType);
            
        }

        private void LoadUser()
        {
            lblError.Text = string.Empty;
            string userId = string.Empty;

            if (Request["UserID"] != null) userId = Request["UserID"];

            if (userId != string.Empty)
            {
                Total.DealerCom.Core.User user = FacadeRepository.GetUserFacade().Read(userId);
                txtUserID.Text = user.Id;
                txtName.Text = user.UserName;
                txtEmail.Text = user.Email;
                dropdownSalesArea.SelectedValue = user.IDSalesArea;
                dropdownUserType.SelectedValue = user.IDRole;
                dropdownRegion.SelectedValue = user.IDRegion;
                chkBoutique.Checked = user.LaBoutique;
            }else
            {
                lblError.Text = "No user selected.";
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //Not using object initializers, since they suck...
            //Prevents proper inspection and produces vague errors when exceptions are encountered on 
            //type translations for DataContext
            if(txtName.Text == string.Empty)
            {
                lblError.Text = "Name cannot be empty";
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                lblError.Text = "Email cannot be empty";
                return;
            }
          
            if(!Conversion.IsEmail(txtEmail.Text))
            {
                lblError.Text = "Invalid email was supplied. Please check the format of your email.";
                return;
            }
            

            if (txtUserID.Text != string.Empty)
            {
                var user = new Total.DealerCom.Core.User();
                user.Id = txtUserID.Text;
                user.UserName = txtName.Text;
                user.Email = txtEmail.Text;
                user.IDSalesArea = dropdownSalesArea.SelectedValue;
                user.IDRole = dropdownUserType.SelectedValue;
                user.IDRegion = dropdownRegion.SelectedValue;
                user.LaBoutique = chkBoutique.Checked;
                FacadeRepository.GetUserFacade().Update(user);

                Response.Redirect("Search.aspx?Updated=" + "User " + user.UserName + " updated.", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx", true);
        }

    }
}
