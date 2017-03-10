using System;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Utility;

namespace TotalDealer_2008.User
{
    public partial class Add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Update User";

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

            dropdownUserType_SelectedIndexChanged(this, new EventArgs());
        }

        private void LoadUser()
        {
            lblError.Text = string.Empty;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //Not using object initializers, since they suck...
            //Prevents proper inspection and produces vague errors when exceptions are encountered on 
            //type translations for DataContext
            if (txtName.Text == string.Empty)
            {
                lblError.Text = "Name cannot be empty";
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                lblError.Text = "Email cannot be empty";
                return;
            }
           
            if (!Conversion.IsEmail(txtEmail.Text))
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
                if (dropdownSalesArea.Visible) user.IDSalesArea = dropdownSalesArea.SelectedValue;
                user.IDRole = dropdownUserType.SelectedValue;
                if (dropdownRegion.Visible) user.IDRegion = dropdownRegion.SelectedValue;
                if (chkBoutique.Visible) user.LaBoutique = chkBoutique.Checked;
                FacadeRepository.GetUserFacade().Add(ref user);

                //TODO: Send out User email to tell them they've been added
                string email =
                    FacadeRepository.GetEmailFacade().SendEmail(new Email {UserID = user.Id, Password = user.Password});

                if (email != string.Empty)
                {
                    Response.Redirect(
                        "~/User/Search.aspx?Updated=" + "User " + user.UserName + " added. Email sent to " + email, false);
                }else
                {
                    Response.Redirect(
                        "~/User/Search.aspx?Updated=" + "User " + user.UserName + " added. Email sending failed.", false);
                }
                
            }
            else
            {
                lblError.Text = "Outlet / Employee number cannot be empty";
                return;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx", true);
        }

        protected void dropdownUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownUserType.Items[dropdownUserType.SelectedIndex].Text != "Dealer")
            {
                lblSalesArea.Visible = false;
                lblRegion.Visible = false;
                lblBoutique.Visible = false;

                dropdownRegion.Visible = false;
                dropdownSalesArea.Visible = false;
                chkBoutique.Visible = false;
            }else
            {
                lblSalesArea.Visible = true;
                lblRegion.Visible = true;
                lblBoutique.Visible = true;

                dropdownRegion.Visible = true;
                dropdownSalesArea.Visible = true;
                chkBoutique.Visible = true;
            }
        }

    }
}
