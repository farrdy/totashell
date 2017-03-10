using System;

namespace TotalDealer_2008.User
{
    public partial class ChangePassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Change Password";
            lblStatus.Text = string.Empty;

            if (!IsPostBack)
            {
                txtUserId.Text = string.Empty;
                txtOldPassword.Text = string.Empty;
                txtNewPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            //Attempt to get new password for user
            lblError.Text = string.Empty;
            if(txtUserId.Text == string.Empty)
            {
                lblError.Text = "User ID is mandatory";
                txtUserId.Focus();
                return;
            }

            if (txtOldPassword.Text == string.Empty)
            {
                lblError.Text = "Old Password is mandatory";
                txtOldPassword.Focus();
                return;
            }
            if (txtNewPassword.Text == string.Empty)
            {
                lblError.Text = "New Password is mandatory";
                txtNewPassword.Focus();
                return;
            }
            if(txtNewPassword.Text != txtConfirmPassword.Text)
            {
                lblError.Text = "New password not correctly confirmed.";
                txtConfirmPassword.Focus();
                return;
            }
           

            var dataRow = FacadeRepository.GetUserFacade().UpdatePassword(new Total.DealerCom.Core.User
            { Id = txtUserId.Text, OldPassword = txtOldPassword.Text, NewPassword = txtNewPassword.Text});

            lblStatus.Text = dataRow == null ? "Password change failed." : "Password change successful.";

            txtUserId.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtOldPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;


        }
    }
}
