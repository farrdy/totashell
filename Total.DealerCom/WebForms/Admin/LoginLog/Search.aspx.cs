using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Utility;

namespace TotalDealer_2008.LoginLog
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LookupSetup();

            }

        }

        /// <summary>
        /// Sets up initial control values
        /// </summary>
        public void LookupSetup()
        {
            lblError.Text = string.Empty;

            Conversion.PopulateMonths(ref dtFromMonth);
            Conversion.PopulateMonths(ref dtnToMonth);

            Conversion.PopulateYears(ref dtToYear, DateTime.Now.Year);
            Conversion.PopulateYears(ref dtFromYear, DateTime.Now.Year);
          
            btnDownload.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grdResults.PageIndex = 0;
            BindData();
        }

        /// <summary>
        /// Performs search and binds search results to grid control
        /// </summary>
        private void BindData()
        {
            lblError.Text = string.Empty;
            if(!Conversion.IsEarlierThan(dtFromYear.SelectedValue, dtToYear.SelectedValue, dtFromMonth.SelectedValue, dtnToMonth.SelectedValue))
            {
                lblError.Text = "From-date cannot be later than to-date.";
                return;
            }

            var param = new LogEntry();

            param.StartMonth = Conversion.MonthToInt(dtFromMonth.SelectedValue);
            param.StartYear = Convert.ToInt32(dtFromYear.SelectedValue);
            param.EndMonth = Conversion.MonthToInt(dtnToMonth.SelectedValue);
            param.EndYear = Convert.ToInt32(dtToYear.SelectedValue);

            param.UserId = txtUserID.Text;
            param.UserName = txtName.Text;

            IEnumerable<LogEntry> data = FacadeRepository.GetLogFacade().LoginSearch(param);

            grdResults.DataSource = data;
            grdResults.DataBind();

            btnDownload.Visible = true;
        }


        protected void btnDownload_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(grdResults, "Results_" + DateTime.Now.ToShortDateString() + ".xls");
        }


        public void ExportGridToExcel(GridView grdGridView, string fileName)
        {
            Response.Clear();
            Response.AddHeader("content-disposition",
                string.Format("attachment;filename={0}", fileName));
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            grdGridView.AllowPaging = false;
            grdGridView.AllowSorting = false;
            BindData();

            var stringWrite = new StringWriter();
            var htmlWrite = new HtmlTextWriter(stringWrite);
            grdGridView.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();


            grdGridView.AllowPaging = true;
            grdGridView.AllowSorting = true;
            BindData();
        }

        protected void grdResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdResults.PageIndex = e.NewPageIndex;
            BindData();
        }

        public override void VerifyRenderingInServerForm(Control control)
        { }

    }
}
