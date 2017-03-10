using System;

namespace TotalDealer_2008.User
{
    public partial class ResetPassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Master.FindControl("menu").Visible = false;
            Title = "Reset Password";
            lblStatus.Text = string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetUserPassword();
        }

        private void ResetUserPassword()
        {
            lblError.Text = string.Empty;
            if(txtUserId.Text == string.Empty)
            {
                lblError.Text = "User ID is mandatory";
                txtUserId.Focus();
                return;
            }

            //Attempt to get new password for user
            var newPassword = FacadeRepository.GetUserFacade().ResetPassword(new Total.DealerCom.Core.User { Id = txtUserId.Text });

            if (newPassword != string.Empty)
            {
                //Attempting to email the new password to the user
                var email = FacadeRepository.GetUserFacade().SendUserPassword(newPassword,
                                                                                    new Total.DealerCom.Core.User { Id = txtUserId.Text });
                lblStatus.Text = "Password sent to email address: " + email;
            }
            else
            {
                throw new Exception("Password reset failed.");
            }

        }
    }
}
