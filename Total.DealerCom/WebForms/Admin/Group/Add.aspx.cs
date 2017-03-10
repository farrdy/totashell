using System;


namespace TotalDealer_2008.Group
{
    public partial class Add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text != string.Empty)
            {
                string result = FacadeRepository.GetGroupFacade().Edit("0", txtGroupName.Text);
                if (result != string.Empty)
                {
                    lblStatus.Text = txtGroupName.Text + " group updated.";
                    Response.Redirect("Search.aspx?Message=Group added", true);
                }
                else
                {
                    lblStatus.Text = txtGroupName.Text + " update failed.";
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
    }
}
