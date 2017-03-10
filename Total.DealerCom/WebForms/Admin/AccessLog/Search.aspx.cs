using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Utility;
using Total.DealerCom.Web.Properties;

namespace TotalDealer_2008.AccessLog
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

            FacadeRepository.GetUserFacade().PopulateRoleList(ref dropdownUserType);

            FacadeRepository.GetLookupFacade().Populate(ref dropdownCat,
                                                        new LookupSearch
                                                            {
                                                                IDParent = null,
                                                                Lookup = Constants.ArticleCategory,
                                                                ShowInactive = false
                                                            }, false);

            Conversion.PopulateMonths(ref dtFromMonth);
            Conversion.PopulateMonths(ref dtnToMonth);

            Conversion.PopulateYears(ref dtToYear, DateTime.Now.Year);
            Conversion.PopulateYears(ref dtFromYear, DateTime.Now.Year);

            txtTitle.Text = string.Empty;

            DropdownCatSelectedIndexChanged(this, new EventArgs());

            btnDownload.Visible = false;
        }

        protected void BtnSearchClick(object sender, EventArgs e)
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
            if (
                !Conversion.IsEarlierThan(dtFromYear.SelectedValue, dtToYear.SelectedValue, dtFromMonth.SelectedValue,
                                          dtnToMonth.SelectedValue))
            {
                lblError.Text = Resources.Search_BindData_From_date_cannot_be_later_than_to_date_;
                return;
            }

            var param = new LogEntry
                {
                    IDArticleCat = Convert.ToInt32(dropdownCat.SelectedValue),
                    IDRole = dropdownUserType.SelectedValue,
                    IDArticleType = Convert.ToInt32(dropdownType.SelectedValue),
                    StartMonth = Conversion.MonthToInt(dtFromMonth.SelectedValue),
                    StartYear = Convert.ToInt32(dtFromYear.SelectedValue),
                    EndMonth = Conversion.MonthToInt(dtnToMonth.SelectedValue),
                    EndYear = Convert.ToInt32(dtToYear.SelectedValue),
                    Title = txtTitle.Text,
                    UserId = txtUserID.Text,
                    UserName = txtName.Text
                };

            IEnumerable<LogEntry> data = FacadeRepository.GetLogFacade().Search(param);

            grdResults.DataSource = data;
            grdResults.DataBind();

            btnDownload.Visible = true;
        }

        protected void DropdownCatSelectedIndexChanged(object sender, EventArgs e)
        {
            //Finding parent Id of selected dropdown category
            var lookup =
                FacadeRepository.GetLookupFacade().GetLookup(
                    new LookupSearch {IDParent = null, Lookup = Constants.ArticleCategory, ShowInactive = false}).First(
                        o => o.Id == dropdownCat.SelectedValue);

            var parentId = "";
            if (lookup != null)
            {
                parentId = lookup.Id;
            }

            //Populating the new types for the selected category
            dropdownCat = FacadeRepository.GetLookupFacade().Populate(ref dropdownType,
                                                                      new LookupSearch
                                                                          {
                                                                              IDParent = Convert.ToInt32(parentId),
                                                                              Lookup = Constants.ArticleType,
                                                                              ShowInactive = false
                                                                          }, false);
        }

        protected void BtnDownloadClick(object sender, EventArgs e)
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

        protected void GrdResultsPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grdResults.PageIndex = e.NewPageIndex;
            BindData();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        public static void PrintWebControl(Control ctrl, string script)
        {
            var stringWrite = new StringWriter();
            var htmlWrite = new HtmlTextWriter(stringWrite);
            var webControl = ctrl as WebControl;
            if (webControl != null)
            {
                webControl.Width = new Unit(100, UnitType.Percentage);
            }
            var pg = new Page {EnableEventValidation = false};
            if (script != string.Empty)
            {
                pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", script);
            }

            var frm = new HtmlForm();
            pg.Controls.Add(frm);
            frm.Attributes.Add("runat", "server");
            frm.Controls.Add(ctrl);
            pg.DesignerInitialize();
            pg.RenderControl(htmlWrite);
            string strHtml = stringWrite.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHtml);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }

        public static void PrintWebControl(Control ctrl)
        {
            PrintWebControl(ctrl, string.Empty);
        }

        protected void BtnPrintClick(object sender, EventArgs e)
        {
            PrintWebControl(grdResults);
        }

    }
}
