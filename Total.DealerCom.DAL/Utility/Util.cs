using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using ExcelLibrary.SpreadSheet;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Services.DTO;
using Services.Templates;
using System.Net.Mail;
using System.Configuration;
using BorderStyle = MigraDoc.DocumentObjectModel.BorderStyle;
using Cell = ExcelLibrary.SpreadSheet.Cell;
using Orientation = MigraDoc.DocumentObjectModel.Orientation;
using Style = MigraDoc.DocumentObjectModel.Style;
using Unit = MigraDoc.DocumentObjectModel.Unit;
using System.Data.SqlClient;


namespace Services.Utility
{
    public static class Util
    {
      
        
        /// <summary>
        /// Returns a comma delimited list of DataKeys that were selected from the GridView (i.e. checked), based on the given CheckBox ControlId
        /// </summary>
        /// <returns>Comma delimited list of Ids. IDs concatenated using apostrophe's, i.e. SQLServer based strings.</returns>
        public static string GetSelectedOptions(GridView grdResults, string controlId)
        {
            return String.Join(",",
                               GetSelectedOptionsNonString(grdResults, controlId, true).Select(
                                   x => String.Format("'{0}'", x)).ToArray());
        }

        /// <summary>
        /// Returns a comma delimited list of DataKeys that were selected from the GridView (i.e. checked), based on the given CheckBox ControlId
        /// </summary>
        /// <returns>Comma delimited list of Ids. Id's concatenated without apostrophe's</returns>
        public static string GetSelectedOptionsNonString(GridView grdResults, string controlId)
        {
            return String.Join(",", GetSelectedOptionsNonString(grdResults, controlId, true).ToArray());
        }

        public static void SendSupplierEMail(Requester requester, Supplier supplier, List<SupplierProduct> product,
                                            string masterDataStatus, string FileText)
        {
            Template Template = new Template();
            Items TemplateItems = new Items();
            var messageBody = new StringBuilder();
            TemplateItems.Enqueue("##reciepientname##", requester.EmailAddress);
            TemplateItems.Enqueue("##requestername##", requester.RequesterName);
            TemplateItems.Enqueue("##referenceno##", supplier.SupplierID.ToString());

            TemplateItems.Enqueue("##requestdate##", requester.RequestDate.ToString("dd-MM-yyyy HH:MM"));
            TemplateItems.Enqueue("##supplier##", supplier.SupplierName);

            messageBody.Append("<table width='80%'><tr bgcolor='#D8D8D8'><td>Product</td><td>Category Manager Status</td><td>Comment</td><td>Masterdata Status</td><td>Comment</td></tr>");
            foreach (var p in product)
            {
                messageBody.AppendFormat("<tr><td>" + p.ProductDescription + "</td><td>" + p.CategoryManagerStatus + "</td><td>" + p.CategoryManagerComment + "</td>");
                messageBody.AppendFormat("<td>" + p.MasterDataStatus + "</td><td>" + p.MasterDataComment + "</td></tr>");
            }
            messageBody.Append("</table>");
            TemplateItems.Enqueue("##product##", messageBody.ToString());

            TemplateItems.Enqueue("##comment##", supplier.SupplierSpecialistComment);

            String content = Template.BuildWithThisText(FileText, TemplateItems);

            string subject = "Request Reference " + supplier.SupplierID.ToString() + " :  " + supplier.MasterDataStatus;

            SendMail(ConfigurationManager.AppSettings["StandingDryAdminEmail"], requester.EmailAddress, subject, content, true);

        }

        public static void SendRecipeEMail(RecipesRequest reciperequest, string FileText)
        {
            Template Template = new Template();
            Items TemplateItems = new Items();
            var messageBody = new StringBuilder();
            TemplateItems.Enqueue("##reciepientname##", reciperequest.Requester.EmailAddress);
            TemplateItems.Enqueue("##requestername##", reciperequest.Requester.RequesterName);
            TemplateItems.Enqueue("##referenceno##", reciperequest.Id.ToString());

            TemplateItems.Enqueue("##requestdate##", reciperequest.Requester.RequestDate.ToString("dd-MM-yyyy HH:MM"));
            TemplateItems.Enqueue("##recipecode##", reciperequest.RecipeCode);

            messageBody.Append("<table width='80%'><tr bgcolor='#D8D8D8'><td>Ingredient Name</td><td>Reported In UOM Qty</td></tr>");
            foreach (var p in reciperequest.RecipesItems)
            {
                messageBody.AppendFormat("<tr><td>" + p.IngredientName + "</td><td>" + p.ReportedInUOMQty + "</td></tr>");
            }
            messageBody.Append("</table>");
            TemplateItems.Enqueue("##items##", messageBody.ToString());

            TemplateItems.Enqueue("##comment##", reciperequest.MasterDataComments);

            String content = Template.BuildWithThisText(FileText, TemplateItems);

            string subject = "Recipe Request Reference " + reciperequest.Id.ToString() + " :  " + reciperequest.MasterDataStatus;

            SendMail(ConfigurationManager.AppSettings["StandingDryAdminEmail"], reciperequest.Requester.EmailAddress, subject, content, true);

        }

        public static void SendErrorMessageEMail(string userid, string ErrorText,  string trace, string FileText)
        {

            Template Template = new Template();
            Items TemplateItems = new Items();
            var messageBody = new StringBuilder();
            TemplateItems.Enqueue("##error##", ErrorText);
           TemplateItems.Enqueue("##trace##", trace);
            TemplateItems.Enqueue("##userid##", userid);
            String content = Template.BuildWithThisText(FileText, TemplateItems);

            string subject = "Total Communication User Error - " + userid;

            SendMail(ConfigurationManager.AppSettings["FAQEmail"], ConfigurationManager.AppSettings["AdminEmail"], subject, content, true);
        }

        public static void SendGeneralChangesEMail(GeneralChangesRequest generalchangesrequest, string FileText)
        {
            Template Template = new Template();
            Items TemplateItems = new Items();
            var messageBody = new StringBuilder();
            TemplateItems.Enqueue("##reciepientname##", generalchangesrequest.Requester.EmailAddress);
            TemplateItems.Enqueue("##requestername##", generalchangesrequest.Requester.RequesterName);
            TemplateItems.Enqueue("##referenceno##", generalchangesrequest.Id.ToString());
            TemplateItems.Enqueue("##requestdate##", generalchangesrequest.Requester.RequestDate.ToString("dd-MM-yyyy HH:MM"));
            TemplateItems.Enqueue("##specialistverificationcomment##", generalchangesrequest.SpecialistVerificationComments);
            TemplateItems.Enqueue("##masterdatacomment##", generalchangesrequest.MasterDataComments);

            String content = Template.BuildWithThisText(FileText, TemplateItems);

            string subject = "General Changes Request Reference " + generalchangesrequest.Id.ToString() + " :  " + generalchangesrequest.MasterDataStatus;

            SendMail(ConfigurationManager.AppSettings["StandingDryAdminEmail"], generalchangesrequest.Requester.EmailAddress, subject, content, true);

        }

        public static void SendMail(string FromEmail, string To, string subject, string content, bool isHTML)
        {
            var message = new MailMessage(FromEmail, To) { Subject = subject };
            message.Body = content.ToString();
            message.IsBodyHtml = isHTML;

            var smtpMail = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);
            smtpMail.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailUserName"], ConfigurationManager.AppSettings["EmailPassword"]);
            smtpMail.Send(message);
        }

        /// <summary>
        /// Returns a comma delimited list of DataKeys that were selected from the GridView (i.e. checked), based on the given CheckBox ControlId
        /// </summary>
        /// <returns>Comma delimited list of Ids. Id's concatenated without apostrophe's</returns>
        public static List<string> GetSelectedOptionsNonString(GridView grdResults, string controlId, bool useControlId)
        {
            return (from GridViewRow a in grdResults.Rows
                    let s = a.FindControl(controlId) as CheckBox
                    where s != null && s.Checked
                    select grdResults.DataKeys[a.RowIndex]
                        into keyvalue
                        where keyvalue != null
                        select keyvalue.Value.ToString()).ToList();
        }

        /*
                private static void CheckModification(StringBuilder builder, string fieldDescription, string oldCreditController, string newCreditController)
                {
                    if (oldCreditController != newCreditController)
                    {
                        builder.Append(fieldDescription).Append(" [").Append(oldCreditController).Append("] -> [").Append(newCreditController).Append("]\n");
                    }
                }
        */

        public static void SendEmailSuppier(Requester requester, Supplier supplier, List<SupplierProduct> product,
                                            string masterDataStatus)
        {

            var message = new MailMessage(ConfigurationManager.AppSettings["StandingDryAdminEmail"],
                                          requester.EmailAddress) { Subject = "Ref : " + supplier.SupplierID + " -  " + masterDataStatus };

            var messageBody = new StringBuilder();

            messageBody.AppendFormat("Dear {0}<br/><br/>", requester.RequesterName);
            messageBody.AppendFormat("Request Reference: {0}", supplier.SupplierID);
            messageBody.AppendLine();
            messageBody.AppendFormat("<br/>Supplier : {0}<br/><br/>", supplier.SupplierName);
            messageBody.AppendFormat("Supplier Specialist Status: {0}<br/>", supplier.SupplierSpecialistStatus);

            if (!String.IsNullOrEmpty(supplier.SupplierSpecialistComment))
            {
                messageBody.AppendFormat("Supplier Specialist Comment: {0}", supplier.SupplierSpecialistComment);
            }
            messageBody.Append("<br/><br/>");
            foreach (var p in product)
            {
                messageBody.AppendFormat("Product:  {0}<br/>", p.ProductDescription);
                messageBody.AppendFormat("Category Manager Status:  {0}<br/>", p.CategoryManagerStatus);
                if (!String.IsNullOrEmpty(p.CategoryManagerComment))
                {
                    messageBody.AppendFormat("Category Manager Comment:  {0}", p.CategoryManagerComment);

                }
                messageBody.AppendFormat("<br/>MasterData Comment Status:  {0}<br/>", p.MasterDataStatus);
                if (!String.IsNullOrEmpty(p.MasterDataComment))
                {
                    messageBody.AppendFormat("MasterData Comment:  {0}", p.MasterDataComment);

                }
                messageBody.Append("<br/><br/>");
            }
            messageBody.Append("Kind regards,<br/>The Dry Stock Team <br/>");

            message.Body = messageBody.ToString();
            message.IsBodyHtml = true;

            var smtpMail = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);
            smtpMail.Send(message);
        }

        private static void CreateWorkbook(Stream stream, DataSet dataset)
        {
            if (dataset.Tables.Count == 0)
                throw new ArgumentException("DataSet needs to have at least one DataTable", "dataset");
            var workbook = new Workbook();
            foreach (DataTable dataTable in dataset.Tables)
            {
                var worksheet = new Worksheet(dataTable.TableName);
                for (int index1 = 0; index1 < dataTable.Columns.Count; ++index1)
                {
                    worksheet.Cells[0, index1] = new Cell(dataTable.Columns[index1].ColumnName);
                    for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
                    {
                        var type = dataTable.Columns[index1].DataType;
                        if (dataTable.Rows[index2][index1] == null || dataTable.Rows[index2][index1] == DBNull.Value)
                        {
                            worksheet.Cells[index2 + 1, index1] = new Cell(" ");
                        }
                        else if (type == typeof(DateTime))
                        {
                            worksheet.Cells[index2 + 1, index1] = new Cell(dataTable.Rows[index2][index1], "MM/DD/YYYY");
                        }
                        else if (type == typeof(double) || type == typeof(decimal) || type == typeof(float))
                        {
                            worksheet.Cells[index2 + 1, index1] = new Cell(dataTable.Rows[index2][index1], "#,##0.00");
                        }
                        else
                        {
                            worksheet.Cells[index2 + 1, index1] = new Cell(dataTable.Rows[index2][index1].ToString());

                        }
                    }
                }
                workbook.Worksheets.Add(worksheet);
            }

            //Add extra sheet to ensure file is bigger than about 7Kb, bug in ExcelLibrary/MS Excel 2010
            var w = new Worksheet(String.Format("Sheet {0}", dataset.Tables.Count + 1));
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    w.Cells[i, j] = new Cell(" ");
                }
            }
            workbook.Worksheets.Add(w);
            workbook.SaveToStream(stream);
        }

        public static void GenerateExcelReport(DataSet dataset, string filename = null)
        {
            filename =
                (
                    filename != null && !filename.EndsWith(".xls")
                        ? String.Format("{0}.xls", filename)
                        : filename)
                ??
                String.Format("{0}_{1}.xls", DateTime.Now.ToString("yyyyMMddHHmmss"), Guid.NewGuid().ToString("N"));

            using (var m = new MemoryStream())
            {
                CreateWorkbook(m, dataset);

                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition",
                                                                  "attachment; filename=" + Path.GetFileName(filename));
                System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                m.WriteTo(System.Web.HttpContext.Current.Response.OutputStream);
                System.Web.HttpContext.Current.Response.End();
            }
        }

        public static void GenerateSupplierPDFTable(DataSet dataset, string filename = null)
        {
            int count = 0;
            try
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25,
                                                                               25, 50, 20);

                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();

                string[] rowData = new string[14];
                string[] headers =
                    {
                        "Name", "S Number", "Site Name", "Requested", "Supplier Name", "Category Manager Status",
                        "Date", "Comment", "MasterData Status", "Date", "Comments", "Retail Barcode",
                        "Product Code", "Product Description"
                    };

                DataSet myDS = dataset;
                DataTableReader myReader = myDS.Tables[0].CreateDataReader();

                iTextSharp.text.pdf.PdfPTable dataTable = new iTextSharp.text.pdf.PdfPTable(headers.Length);
                dataTable.DefaultCell.Padding = 0;
                float[] headerwidths = { 10, 10, 7, 6, 12, 6, 5, 10, 6, 6, 10, 8, 8, 15 };
                dataTable.SetWidths(headerwidths);
                dataTable.WidthPercentage = 100;

                dataTable.DefaultCell.BorderWidth = 0;
                dataTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //Set cell text to left align

                for (int i = 0; i < headers.Length; i++)
                {

                    iTextSharp.text.Chunk myData = new iTextSharp.text.Chunk(headers[i],
                                                                             iTextSharp.text.FontFactory.GetFont(
                                                                                 iTextSharp.text.FontFactory.
                                                                                     HELVETICA_BOLD, 7,
                                                                                 new iTextSharp.text.BaseColor(46, 84,
                                                                                                               141)));
                    iTextSharp.text.Phrase myPhrase = new iTextSharp.text.Phrase(myData);
                    iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(myPhrase);
                    cell.BorderColor = new iTextSharp.text.BaseColor(99, 184, 255);
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(221, 221, 221);
                    dataTable.AddCell(cell);
                }
                dataTable.HeaderRows = 1;
                dataTable.DefaultCell.PaddingBottom = 3;

                //While there are records in the dataset
                while (myReader.Read())
                {
                    string name = myReader["RequesterName"].ToString() + ", " + myReader["SupplierName"].ToString();
                    //Format the insured's name
                    //Alternate row colors
                    if (count % 2 == 0)
                        dataTable.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(200, 213, 232);
                    else
                        dataTable.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);


                    //Add each record into an array
                    rowData[0] = myReader["RequesterName"].ToString();
                    rowData[1] = myReader["SiteNumber"].ToString();
                    rowData[2] = myReader["SiteName"].ToString();
                    rowData[3] = !String.IsNullOrEmpty(myReader["RequestDate"].ToString())
                                     ? Convert.ToDateTime(myReader["RequestDate"]).ToString("d.M.y")
                                     : myReader["RequestDate"].ToString();
                    rowData[4] = myReader["SupplierName"].ToString();
                    rowData[5] = myReader["CategoryManagerStatus"].ToString();
                    rowData[6] = !String.IsNullOrEmpty(myReader["CategoryManagerStatusDate"].ToString())
                                     ? Convert.ToDateTime(myReader["CategoryManagerStatusDate"]).ToString("d.M.y")
                                     : myReader["CategoryManagerStatusDate"].ToString();
                    rowData[7] = myReader["CategoryManagerComment"].ToString();
                    rowData[8] = myReader["MasterDataStatus"].ToString();
                    rowData[9] = !String.IsNullOrEmpty(myReader["MasterDataStatusDate"].ToString())
                                      ? Convert.ToDateTime(myReader["MasterDataStatusDate"]).ToString("d.M.y")
                                      : myReader["MasterDataStatusDate"].ToString();
                    rowData[10] = myReader["MasterDataComment"].ToString();
                    rowData[11] = myReader["RetailBarcode"].ToString();
                    rowData[12] = myReader["ProductCode"].ToString();
                    rowData[13] = myReader["ProductDescription"].ToString();

                    for (int j = 0; j < headers.Length; j++)
                    {
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(rowData[j],
                                               iTextSharp.text.FontFactory.GetFont(
                                                   iTextSharp.text.FontFactory.HELVETICA, 7)));
                        cell.BorderColor = new iTextSharp.text.BaseColor(99, 184, 255);
                        dataTable.AddCell(cell);
                    }

                    count++;
                }
                dataTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                dataTable.DefaultCell.PaddingTop = 10;
                dataTable.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);

                pdfDoc.Add(new iTextSharp.text.Paragraph(" "));
                pdfDoc.Add(dataTable);

                var path = Path.Combine(
                    Path.GetTempPath(),
                    Path.GetFileName(
                        filename != null && !filename.EndsWith(".pdf")
                            ? String.Format("{0}.pdf", filename)
                            : filename)
                    ??
                    String.Format("{0}_{1}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"), Guid.NewGuid().ToString("N")));

                pdfDoc.Close();
                System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition",
                                                                  "attachment; filename=" + Path.GetFileName(path));
                System.Web.HttpContext.Current.Response.Write(pdfDoc);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void GenerateGeneralChangesPDFTable(DataSet dataset, string filename = null)
        {
            int count = 0;
            try
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25,
                                                                               25, 50, 20);

                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();

                string[] rowData = new string[13];
                string[] headers =
                    {
                        "Name", "S Number", "Site Name", "Requested", "Specialist Verification",
                        "Date", "Comment", "MasterData Status", "Date", "Comments", "Group Name", "Item Name", "IsSelected"
                    };

                DataSet myDS = dataset;
                DataTableReader myReader = myDS.Tables[0].CreateDataReader();

                iTextSharp.text.pdf.PdfPTable dataTable = new iTextSharp.text.pdf.PdfPTable(headers.Length);
                dataTable.DefaultCell.Padding = 0;

                float[] headerwidths = { 10, 10, 12, 6, 12, 6, 12, 10, 6, 15, 7, 8, 6 };
                dataTable.SetWidths(headerwidths);
                dataTable.WidthPercentage = 100;

                dataTable.DefaultCell.BorderWidth = 0;
                dataTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //Set cell text to left align

                for (int i = 0; i < headers.Length; i++)
                {

                    iTextSharp.text.Chunk myData = new iTextSharp.text.Chunk(headers[i],
                                                                             iTextSharp.text.FontFactory.GetFont(
                                                                                 iTextSharp.text.FontFactory.
                                                                                     HELVETICA_BOLD, 7,
                                                                                 new iTextSharp.text.BaseColor(46, 84,
                                                                                                               141)));
                    iTextSharp.text.Phrase myPhrase = new iTextSharp.text.Phrase(myData);
                    iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(myPhrase);
                    cell.BorderColor = new iTextSharp.text.BaseColor(99, 184, 255);
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(221, 221, 221);
                    dataTable.AddCell(cell);
                }
                dataTable.HeaderRows = 1;
                dataTable.DefaultCell.PaddingBottom = 3;

                //While there are records in the dataset
                while (myReader.Read())
                {
                    string name = myReader["RequesterName"].ToString() + ", " + myReader["SiteNumber"].ToString();

                    //Add each record into an array
                    rowData[0] = myReader["RequesterName"].ToString();
                    rowData[1] = myReader["SiteNumber"].ToString();
                    rowData[2] = myReader["SiteName"].ToString();
                    rowData[3] = !String.IsNullOrEmpty(myReader["RequestDate"].ToString())
                                     ? Convert.ToDateTime(myReader["RequestDate"]).ToString("d.M.y")
                                     : myReader["RequestDate"].ToString();
                    rowData[4] = myReader["SpecialistVerificationStatus"].ToString();
                    rowData[5] = !String.IsNullOrEmpty(myReader["SpecialistVerificationCompletionDate"].ToString())
                                     ? Convert.ToDateTime(myReader["SpecialistVerificationCompletionDate"]).ToString("d.M.y")
                                     : myReader["SpecialistVerificationCompletionDate"].ToString();
                    rowData[6] = myReader["SpecialistVerificationComments"].ToString();
                    rowData[7] = myReader["MasterDataStatus"].ToString();
                    rowData[8] = !String.IsNullOrEmpty(myReader["MasterDataCompletionDate"].ToString())
                                      ? Convert.ToDateTime(myReader["MasterDataCompletionDate"]).ToString("d.M.y")
                                      : myReader["MasterDataCompletionDate"].ToString();
                    rowData[9] = myReader["MasterDataComments"].ToString();
                    rowData[10] = myReader["GroupName"].ToString();
                    rowData[11] = myReader["ItemName"].ToString();
                    rowData[12] = myReader["IsSelected"].ToString();
                    for (int j = 0; j < headers.Length; j++)
                    {
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(rowData[j],
                                               iTextSharp.text.FontFactory.GetFont(
                                                   iTextSharp.text.FontFactory.HELVETICA, 7)));
                        cell.BorderColor = new iTextSharp.text.BaseColor(99, 184, 255);
                        dataTable.AddCell(cell);
                    }

                    count++;
                }
                dataTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                dataTable.DefaultCell.PaddingTop = 10;

                pdfDoc.Add(new iTextSharp.text.Paragraph(" "));
                pdfDoc.Add(dataTable);

                var path = Path.Combine(
                    Path.GetTempPath(),
                    Path.GetFileName(
                        filename != null && !filename.EndsWith(".pdf")
                            ? String.Format("{0}.pdf", filename)
                            : filename)
                    ??
                    String.Format("{0}_{1}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"), Guid.NewGuid().ToString("N")));

                pdfDoc.Close();
                System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition",
                                                                  "attachment; filename=" + Path.GetFileName(path));
                System.Web.HttpContext.Current.Response.Write(pdfDoc);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static void GenerateRecipePDFTable(DataSet dataset, string filename = null)
        {
            int count = 0;
            try
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 25,
                                                                               25, 50, 20);

                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
             
                pdfDoc.Open();

                string[] rowData = new string[17];
                string[] headers =
                    {
                        "Name", "S Number", "Site Name", "Requested", "Food Technician Status", 
                         "Comments", "MasterData Status", 
                        "Date", "Comments",  "Prepared Item Name", "Prepared Item Barcode",
                        "Recipe Name in ISIS",
                        "Ingredient Name", "Base UOM Qty", "Quantity", "Reported in UOM Qty", "Cost"
                    };

                DataSet myDS = dataset;
                DataTableReader myReader = myDS.Tables[0].CreateDataReader();

                iTextSharp.text.pdf.PdfPTable dataTable = new iTextSharp.text.pdf.PdfPTable(headers.Length);
                dataTable.DefaultCell.Padding = 0;
                float[] headerwidths = { 5, 7, 7, 4, 7, 10, 6, 7, 7, 10, 5, 5, 5, 5, 5, 6, 6 };
                dataTable.SetWidths(headerwidths);
                dataTable.WidthPercentage = 100;

                dataTable.DefaultCell.BorderWidth = 0;
                dataTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                //Set cell text to left align

                for (int i = 0; i < headers.Length; i++)
                {

                    iTextSharp.text.Chunk myData = new iTextSharp.text.Chunk(headers[i],
                                                                             iTextSharp.text.FontFactory.GetFont(
                                                                                 iTextSharp.text.FontFactory.
                                                                                     HELVETICA_BOLD, 7,
                                                                                 new iTextSharp.text.BaseColor(46, 84,
                                                                                                               141)));
                    iTextSharp.text.Phrase myPhrase = new iTextSharp.text.Phrase(myData);
                    iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(myPhrase);
                    cell.BorderColor = new iTextSharp.text.BaseColor(99, 184, 255);
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(221, 221, 221);
                    dataTable.AddCell(cell);
                }
                dataTable.HeaderRows = 1;
                dataTable.DefaultCell.PaddingBottom = 3;

                //While there are records in the dataset
                while (myReader.Read())
                {
                    string name = myReader["RequesterName"].ToString() + ", " + myReader["RequesterName"].ToString();
                    //Add each record into an array
                    rowData[0] = myReader["RequesterName"].ToString();
                    rowData[1] = myReader["SiteNumber"].ToString();
                    rowData[2] = myReader["SiteName"].ToString();
                    rowData[3] = !String.IsNullOrEmpty(myReader["RequestDate"].ToString())
                                     ? Convert.ToDateTime(myReader["RequestDate"]).ToString("d.M.y")
                                     : myReader["RequestDate"].ToString();
                    rowData[4] = myReader["FoodTechnicianStatus"].ToString();
                    rowData[5] = myReader["FoodTechnicianComments"].ToString();
                    rowData[6] = myReader["MasterDataStatus"].ToString();
                    rowData[7] = !String.IsNullOrEmpty(myReader["CompletionDate"].ToString())
                                     ? Convert.ToDateTime(myReader["CompletionDate"]).ToString("d.M.y")
                                     : myReader["CompletionDate"].ToString();
                    rowData[8] = myReader["MasterDataComments"].ToString();
                    rowData[9] = myReader["PreparedItemName"].ToString();
                    rowData[10] = myReader["PreparedItemBarcode"].ToString();
                    rowData[11] = myReader["ISISRecipeName"].ToString();
                    rowData[12] = myReader["IngredientName"].ToString();
                    rowData[13] = myReader["BaseUOMQty"].ToString();
                    rowData[14] = myReader["Quantity"].ToString();
                    rowData[15] = myReader["ReportedInUOMQty"].ToString();
                    rowData[16] = myReader["Cost"].ToString();

                    for (int j = 0; j < headers.Length; j++)
                    {
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(rowData[j],
                                               iTextSharp.text.FontFactory.GetFont(
                                                   iTextSharp.text.FontFactory.HELVETICA, 7)));
                        cell.BorderColor = new iTextSharp.text.BaseColor(99, 184, 255);
                        dataTable.AddCell(cell);
                    }

                    count++;
                }
                dataTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                dataTable.DefaultCell.PaddingTop = 10;
                dataTable.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);

                pdfDoc.Add(new iTextSharp.text.Paragraph(" "));
                pdfDoc.Add(dataTable);

                var path = Path.Combine(
                    Path.GetTempPath(),
                    Path.GetFileName(
                        filename != null && !filename.EndsWith(".pdf")
                            ? String.Format("{0}.pdf", filename)
                            : filename)
                    ??
                    String.Format("{0}_{1}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"), Guid.NewGuid().ToString("N")));

                pdfDoc.Close();
                System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition",
                                                                  "attachment; filename=" + Path.GetFileName(path));
                System.Web.HttpContext.Current.Response.Write(pdfDoc);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SafeString(this SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
                return reader.GetString(index);
            return string.Empty;
        }

        public static void GeneratePDFReport(DataSet dataSet, string filename = null)
        {
            var doc = new Document { Info = { Title = "", Subject = "", Author = "DVT" } };

            Style style = doc.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = doc.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = doc.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            // style.Font.Name = "Times New Roman";
            style.Font.Size = 7;

            // Create a new style called Reference based on style Normal
            style = doc.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);

            var path =
                Path.Combine(
                    Path.GetTempPath(),
                    Path.GetFileName(
                        filename != null && !filename.EndsWith(".pdf")
                            ? String.Format("{0}.pdf", filename)
                            : filename)
                    ??
                    String.Format("{0}_{1}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"), Guid.NewGuid().ToString("N")));

            var section = doc.AddSection();
            section.PageSetup.Orientation = Orientation.Landscape;

            if (dataSet != null)
            {
                var table = new MigraDoc.DocumentObjectModel.Tables.Table
                    {
                        Style = "Table",
                        Borders = { Color = TableBorder, Width = 0.15, Left = { Width = 0.2 }, Right = { Width = 0.2 } },
                        Rows = { LeftIndent = 0 }
                    };

                for (int column = 0; column < dataSet.Tables[0].Columns.Count; column++)
                {
                    var col = table.AddColumn(GetColumnWidth(dataSet.Tables[0], column));
                    col.Format.Alignment = ParagraphAlignment.Center;
                }

                //Header row
                var row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = TableBlue;
                for (int column = 0; column < dataSet.Tables[0].Columns.Count; column++)
                {
                    row.Cells[column].AddParagraph(dataSet.Tables[0].Columns[column].ColumnName);
                    row.Cells[column].Format.Font.Bold = false;
                    row.Cells[column].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[column].VerticalAlignment = VerticalAlignment.Bottom;
                }

                table.SetEdge(0, 0, dataSet.Tables[0].Columns.Count, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);

                for (int rows = 0; rows < dataSet.Tables[0].Rows.Count; rows++)
                {
                    row = table.AddRow();
                    row.TopPadding = 0.2;
                    for (int column = 0; column < dataSet.Tables[0].Columns.Count; column++)
                    {
                        row.Cells[column].Shading.Color = TableGray;
                        row.Cells[column].VerticalAlignment = VerticalAlignment.Center;
                        row.Cells[column].Format.Alignment = ParagraphAlignment.Left;
                        row.Cells[column].Format.FirstLineIndent = 1;

                        row.Cells[column].AddParagraph(dataSet.Tables[0].Rows[rows][column].ToString());
                        table.SetEdge(0, table.Rows.Count - 2, dataSet.Tables[0].Columns.Count, 1, Edge.Box,
                                      BorderStyle.Single, 0.75);
                    }
                }

                doc.LastSection.Add(table);
            }

            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always) { Document = doc };
            renderer.RenderDocument();

            var m = new MemoryStream();
            renderer.PdfDocument.Save(m, false);
            m.Seek(0, SeekOrigin.Begin);

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition",
                                                              "attachment; filename=" + Path.GetFileName(path));
            System.Web.HttpContext.Current.Response.AddHeader("content-length",
                                                              m.Length.ToString(CultureInfo.InvariantCulture));
            System.Web.HttpContext.Current.Response.BinaryWrite(m.ToArray());
            System.Web.HttpContext.Current.Response.Flush();
            m.Close();
            System.Web.HttpContext.Current.Response.End();
        }

        private static double GetTextWidth(string s)
        {
            var xf = new XFont("Verdana", 9);

            return GetTextWidth(s, xf);
        }

        private static double GetTextWidth(string s, XFont xf)
        {
            var pdfDoc = new PdfDocument();
            var pdfPage = pdfDoc.AddPage();
            var pdfGfx = XGraphics.FromPdfPage(pdfPage);

            XSize ss = pdfGfx.MeasureString(s, xf);

            return ss.Width + 16;
        }

        private static double GetColumnWidth(DataTable dt, int n)
        {
            var xf = new XFont("Verdana", 9);
            return GetColumnWidth(dt, n, xf);
        }

        private static double GetColumnWidth(DataTable dt, int n, XFont xf)
        {
            var pdfDoc = new PdfDocument();
            var pdfPage = pdfDoc.AddPage();
            var pdfGfx = XGraphics.FromPdfPage(pdfPage);

            double width = 0;
            XSize ss;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ss = pdfGfx.MeasureString(dt.Rows[i][n].ToString(), xf);

                if (ss.Width > width)
                    width = ss.Width;
            }

            ss = pdfGfx.MeasureString(dt.Columns[n].ColumnName, xf);
            if (ss.Width > (width))
                width = ss.Width;

            return width + 16;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DataSet ToDataSet<T>(this IEnumerable<T> list)
        {
            Type type = typeof(T);
            var ds = new DataSet();
            var dt = new DataTable(type.Name);
            ds.Tables.Add(dt);
            var propertyInfos = type.GetProperties().ToList();
            propertyInfos.ForEach(propertyInfo =>
                {
                    Type columnType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                    dt.Columns.Add(propertyInfo.Name, columnType);
                });
            list.ToList().ForEach(item =>
                {
                    DataRow row = dt.NewRow();
                    propertyInfos.ForEach(
                        propertyInfo =>
                        row[propertyInfo.Name] = propertyInfo.GetValue(item, null) ?? DBNull.Value
                        );
                    dt.Rows.Add(row);
                });
            return ds;

        }

        // Some pre-defined colors
#if true
        // RGB colors
        private static readonly Color TableBorder = new Color(81, 125, 192);
        private static readonly Color TableBlue = new Color(235, 240, 249);
        private static readonly Color TableGray = new Color(242, 242, 242);
#else
    // CMYK colors
    readonly static Color tableBorder = Color.FromCmyk(100, 50, 0, 30);
    readonly static Color tableBlue = Color.FromCmyk(0, 80, 50, 30);
    readonly static Color tableGray = Color.FromCmyk(30, 0, 0, 0, 100);
#endif

        public static void GenerateGeneralChangesRequestPDF(GeneralChangesRequest request)
        {
            var doc = new Document { Info = { Title = "", Subject = "", Author = "DVT" } };

            Style style = doc.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = doc.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = doc.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            // style.Font.Name = "Times New Roman";
            style.Font.Size = 8;

            // Create a new style called Reference based on style Normal
            style = doc.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);

            var path = String.Format("{0}_{1}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"),
                                     Guid.NewGuid().ToString("N"));

            var section = doc.AddSection();
            section.PageSetup.Orientation = Orientation.Portrait;
            section.PageSetup.LeftMargin = Unit.FromMillimeter(10);
            section.PageSetup.RightMargin = Unit.FromMillimeter(10);
            section.PageSetup.TopMargin = Unit.FromMillimeter(10);
            section.PageSetup.BottomMargin = Unit.FromMillimeter(10);

            var para = doc.LastSection.AddParagraph("Requester Details");
            para.Format.Font.Size = 14;
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            var table = new MigraDoc.DocumentObjectModel.Tables.Table
                {
                    Style = "Table",
                    Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                    Rows = { LeftIndent = 0 }
                };

            // Columns
            var col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(110));
            col.Format.Alignment = ParagraphAlignment.Center;

            //Requester Name
            var row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.RequesterName);

            //Site Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("S-Number");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.SiteNumber);

            //Site Name
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Site Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.SiteName);

            //E-Mail Address
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("E-Mail Address");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.EmailAddress);

            //Contact Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Contact Number");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.ContactNo);

            //Date
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Date");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.RequestDate.ToString("d.M.y"));

            table.SetEdge(0, 0, 2, 6, Edge.Box, BorderStyle.Single, 0.75);

            doc.LastSection.Add(table);

            para = doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(110));
            col.Format.Alignment = ParagraphAlignment.Center;

            //Motivation
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Motivation");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.Motivation);

            table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.5);

            doc.LastSection.Add(table);

            para = doc.LastSection.AddParagraph("Selected Items");
            para.Format.Font.Size = 12;
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            foreach (var group in request.GeneralChangesItems.Select(x => x.GeneralChangesItem.GeneralChangesItemGroup).Distinct())
            {
                table = new MigraDoc.DocumentObjectModel.Tables.Table
                    {
                        Style = "Table",
                        Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                        Rows = { LeftIndent = 0 }
                    };

                // Columns
                col = table.AddColumn(Unit.FromMillimeter(100));
                col.Format.Alignment = ParagraphAlignment.Center;
                col = table.AddColumn(Unit.FromMillimeter(25));
                col.Format.Alignment = ParagraphAlignment.Center;
                if (group.Active)
                {
                    col = table.AddColumn(Unit.FromMillimeter(30));
                    col.Format.Alignment = ParagraphAlignment.Center;

                    col = table.AddColumn(Unit.FromMillimeter(30));
                    col.Format.Alignment = ParagraphAlignment.Center;
                }

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = TableBlue;

                row.Cells[0].AddParagraph(group.GroupName);
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

                row.Cells[2].AddParagraph("Specialist");
                row.Cells[2].Format.Font.Bold = true;
                row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;

                row.Cells[3].AddParagraph("Masterdata");
                row.Cells[3].Format.Font.Bold = true;
                row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

                int groupId = group.Id;
                foreach (var link in request.GeneralChangesItems.Where(x => x.GeneralChangesItem.GeneralChangesItemGroup.Id == groupId))
                {
                    row = table.AddRow();
                    row.TopPadding = 1.5;
                    row.HeadingFormat = true;
                    row.Format.Alignment = ParagraphAlignment.Center;
                    row.Format.Font.Bold = false;
                    //row.Shading.Color = TableBlue;

                    row.Cells[0].AddParagraph(link.GeneralChangesItem.ItemName);
                    row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

                    //row.Cells[1].Shading.Color = TableGray;
                    row.Cells[1].Format.Font.Bold = false;
                    row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                    row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    row.Cells[1].Format.FirstLineIndent = 1;
                    para = row.Cells[1].AddParagraph(link.IsSelected ? "þ" : "¨");
                    para.Format.Font.Name = "Wingdings";

                    if (group.Active)
                    {
                        row.Cells[2].Format.Font.Bold = false;
                        row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                        row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        row.Cells[2].Format.FirstLineIndent = 1;
                        row.Cells[2].AddParagraph(link.SpecialistVerificationApproved.HasValue ? link.SpecialistVerificationApproved.Value ? "Approved" : "Rejected" : "");

                        row.Cells[3].Format.Font.Bold = false;
                        row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                        row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        row.Cells[3].Format.FirstLineIndent = 1;
                        row.Cells[3].AddParagraph(link.MasterDataApproved.HasValue ? link.MasterDataApproved.Value ? "Approved" : "Rejected" : "");

                    }
                }

                table.SetEdge(0, 0, group.Approvable ? 3 : 2, group.GeneralChangesItems.Count() + 1, Edge.Box, BorderStyle.Single, 0.5);

                doc.LastSection.Add(table);

                para = doc.LastSection.AddParagraph();
                para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);
            }

            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always) { Document = doc };
            renderer.RenderDocument();

            var m = new MemoryStream();
            renderer.PdfDocument.Save(m, false);
            //renderer.PdfDocument.Save(@"c:\temp\test.pdf");
            m.Seek(0, SeekOrigin.Begin);

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition",
                                                              "attachment; filename=" + Path.GetFileName(path));
            System.Web.HttpContext.Current.Response.AddHeader("content-length",
                                                              m.Length.ToString(CultureInfo.InvariantCulture));
            System.Web.HttpContext.Current.Response.BinaryWrite(m.ToArray());
            System.Web.HttpContext.Current.Response.Flush();
            m.Close();
            System.Web.HttpContext.Current.Response.End();
        }

        public static void GenerateRecipesRequestPDF(RecipesRequest request)
        {
            var doc = new Document { Info = { Title = "", Subject = "", Author = "DVT" } };

            Style style = doc.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = doc.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = doc.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            // style.Font.Name = "Times New Roman";
            style.Font.Size = 8;

            // Create a new style called Reference based on style Normal
            style = doc.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);

            var path = String.Format("{0}_{1}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"),
                                     Guid.NewGuid().ToString("N"));

            var section = doc.AddSection();
            section.PageSetup.Orientation = Orientation.Landscape;
            section.PageSetup.LeftMargin = Unit.FromMillimeter(10);
            section.PageSetup.RightMargin = Unit.FromMillimeter(10);
            section.PageSetup.TopMargin = Unit.FromMillimeter(10);
            section.PageSetup.BottomMargin = Unit.FromMillimeter(10);

            var para = doc.LastSection.AddParagraph("Requester Details");
            para.Format.Font.Size = 14;
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            var table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            var col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(200));
            col.Format.Alignment = ParagraphAlignment.Center;

            //Requester Name
            var row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.RequesterName);

            //Site Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("S-Number");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.SiteNumber);

            //Site Name
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Site Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.SiteName);

            //E-Mail Address
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("E-Mail Address");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.EmailAddress);

            //Contact Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Contact Number");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.ContactNo);

            //Date
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Date");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.RequestDate.ToString("d.M.y"));

            table.SetEdge(0, 0, 2, 6, Edge.Box, BorderStyle.Single, 0.75);

            doc.LastSection.Add(table);

            para = doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(200));
            col.Format.Alignment = ParagraphAlignment.Center;

            //Motivation
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Motivation");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.Motivation);

            table.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.5);

            doc.LastSection.Add(table);

            para = doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;

            //Recipe Name
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Recipe Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[1].AddParagraph("Description");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[2].AddParagraph("Prepared Item Name");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[3].AddParagraph("Prepared Item Barcode");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[4].AddParagraph("Recipe Name in ISIS");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Bottom;

            //Site Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].Format.Font.Bold = false;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].Format.FirstLineIndent = 1;
            row.Cells[0].AddParagraph(request.RecipeCode);

            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.RecipeDescription);

            row.Cells[2].Format.Font.Bold = false;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].Format.FirstLineIndent = 1;
            row.Cells[2].AddParagraph(request.PreparedItemName);

            row.Cells[3].Format.Font.Bold = false;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].Format.FirstLineIndent = 1;
            row.Cells[3].AddParagraph(request.PreparedItemBarcode);

            row.Cells[4].Format.Font.Bold = false;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].Format.FirstLineIndent = 1;
            row.Cells[4].AddParagraph(request.ISISRecipeName);

            table.SetEdge(0, 0, 5, 2, Edge.Box, BorderStyle.Single, 0.75);

            doc.LastSection.Add(table);

            doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            col = table.AddColumn(Unit.FromMillimeter(60));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(25));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(20));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(40));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(20));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(40));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(25));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(25));
            col.Format.Alignment = ParagraphAlignment.Center;

            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Ingredient Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[1].AddParagraph("Base UOM Qty");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[2].AddParagraph("Quantity");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[3].AddParagraph("Reported in UOM Qty");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[4].AddParagraph("Cost");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[5].AddParagraph("Supplier");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[6].AddParagraph("Product Code");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[6].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[7].AddParagraph("Supplier UOM");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[7].VerticalAlignment = VerticalAlignment.Bottom;

            foreach (var item in request.RecipesItems)
            {
                row = table.AddRow();
                row.TopPadding = 1.5;
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                //row.Shading.Color = TableBlue;

                row.Cells[0].Format.Font.Bold = false;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.FirstLineIndent = 1;
                row.Cells[0].AddParagraph(item.IngredientName);

                row.Cells[1].Format.Font.Bold = false;
                row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].Format.FirstLineIndent = 1;
                row.Cells[1].AddParagraph(item.BaseUOMQty);

                row.Cells[2].Format.Font.Bold = false;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].Format.FirstLineIndent = 1;
                row.Cells[2].AddParagraph(item.Quantity.ToString(CultureInfo.InvariantCulture));

                row.Cells[3].Format.Font.Bold = false;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[3].Format.FirstLineIndent = 1;
                row.Cells[3].AddParagraph(item.ReportedInUOMQty);

                row.Cells[4].Format.Font.Bold = false;
                row.Cells[4].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.FirstLineIndent = 1;
                row.Cells[4].AddParagraph(item.Cost.ToString(CultureInfo.InvariantCulture));

                row.Cells[5].Format.Font.Bold = false;
                row.Cells[5].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[5].Format.FirstLineIndent = 1;
                row.Cells[5].AddParagraph(item.Supplier);

                row.Cells[6].Format.Font.Bold = false;
                row.Cells[6].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[6].Format.FirstLineIndent = 1;
                row.Cells[6].AddParagraph(item.ProductCode);

                row.Cells[7].Format.Font.Bold = false;
                row.Cells[7].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[7].Format.FirstLineIndent = 1;
                row.Cells[7].AddParagraph(item.SupplierUOM);
            }

            table.SetEdge(0, 0, 8, request.RecipesItems.Count() + 1, Edge.Box, BorderStyle.Single, 0.5);

            doc.LastSection.Add(table);

            para = doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);


            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always) { Document = doc };
            renderer.RenderDocument();

            var m = new MemoryStream();
            renderer.PdfDocument.Save(m, false);
            //renderer.PdfDocument.Save(@"c:\temp\test.pdf");
            m.Seek(0, SeekOrigin.Begin);

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition",
                                                              "attachment; filename=" + Path.GetFileName(path));
            System.Web.HttpContext.Current.Response.AddHeader("content-length",
                                                              m.Length.ToString(CultureInfo.InvariantCulture));
            System.Web.HttpContext.Current.Response.BinaryWrite(m.ToArray());
            System.Web.HttpContext.Current.Response.Flush();
            m.Close();
            System.Web.HttpContext.Current.Response.End();
        }

        public static void GenerateSupplierRequestPDF(SupplierRequest request)
        {
            var doc = new Document { Info = { Title = "", Subject = "", Author = "DVT" } };

            Style style = doc.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = doc.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = doc.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            // style.Font.Name = "Times New Roman";
            style.Font.Size = 8;

            // Create a new style called Reference based on style Normal
            style = doc.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);

            var path = String.Format("{0}_{1}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"),
                                     Guid.NewGuid().ToString("N"));

            var section = doc.AddSection();
            section.PageSetup.Orientation = Orientation.Landscape;
            section.PageSetup.LeftMargin = Unit.FromMillimeter(10);
            section.PageSetup.RightMargin = Unit.FromMillimeter(10);
            section.PageSetup.TopMargin = Unit.FromMillimeter(10);
            section.PageSetup.BottomMargin = Unit.FromMillimeter(10);

            var para = doc.LastSection.AddParagraph("Requester Details");
            para.Format.Font.Size = 14;
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            var table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            var col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(200));
            col.Format.Alignment = ParagraphAlignment.Center;

            //Requester Name
            var row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.RequesterName);

            //Site Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("S-Number");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.SiteNumber);

            //Site Name
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Site Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.SiteName);

            //E-Mail Address
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("E-Mail Address");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.EmailAddress);

            //Contact Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Contact Number");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.ContactNo);

            //Date
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Date");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //row.Cells[1].Shading.Color = TableGray;
            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Requester.RequestDate.ToString("d.M.y"));

            table.SetEdge(0, 0, 2, 6, Edge.Box, BorderStyle.Single, 0.75);

            doc.LastSection.Add(table);

            para = doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            col = table.AddColumn(Unit.FromMillimeter(50));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(200));
            col.Format.Alignment = ParagraphAlignment.Center;

            //Recipe Name
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Supplier Name");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[1].AddParagraph("Address1");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[2].AddParagraph("Address2");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[3].AddParagraph("City");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[4].AddParagraph("Province");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Bottom;


            row.Cells[5].AddParagraph("Postal Code");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;


            row.Cells[6].AddParagraph("Phone");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[6].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[7].AddParagraph("Contact Name");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[7].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[8].AddParagraph("Cellphone");
            row.Cells[8].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[8].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[9].AddParagraph("VAT No.");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[9].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[10].AddParagraph("Fax");
            row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[10].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[11].AddParagraph("EMail");
            row.Cells[11].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[11].VerticalAlignment = VerticalAlignment.Bottom;

            //Site Number
            row = table.AddRow();
            row.TopPadding = 1.5;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            //row.Shading.Color = TableBlue;

            row.Cells[0].Format.Font.Bold = false;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].Format.FirstLineIndent = 1;
            row.Cells[0].AddParagraph(request.Supplier.SupplierName);

            row.Cells[1].Format.Font.Bold = false;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].Format.FirstLineIndent = 1;
            row.Cells[1].AddParagraph(request.Supplier.Address1);

            row.Cells[2].Format.Font.Bold = false;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].Format.FirstLineIndent = 1;
            row.Cells[2].AddParagraph(request.Supplier.Address2);

            row.Cells[3].Format.Font.Bold = false;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].Format.FirstLineIndent = 1;
            row.Cells[3].AddParagraph(request.Supplier.City);

            row.Cells[4].Format.Font.Bold = false;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].Format.FirstLineIndent = 1;
            row.Cells[4].AddParagraph(request.Supplier.Province);

            row.Cells[5].Format.Font.Bold = false;
            row.Cells[5].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[5].Format.FirstLineIndent = 1;
            row.Cells[5].AddParagraph(request.Supplier.PostalCode.ToString());

            row.Cells[6].Format.Font.Bold = false;
            row.Cells[6].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[6].Format.FirstLineIndent = 1;
            row.Cells[6].AddParagraph(request.Supplier.Phone);

            row.Cells[7].Format.Font.Bold = false;
            row.Cells[7].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[7].Format.FirstLineIndent = 1;
            row.Cells[7].AddParagraph(request.Supplier.ContactName);

            row.Cells[8].Format.Font.Bold = false;
            row.Cells[8].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[8].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[8].Format.FirstLineIndent = 1;
            row.Cells[8].AddParagraph(request.Supplier.Cellphone);


            row.Cells[9].Format.Font.Bold = false;
            row.Cells[9].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[9].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[9].Format.FirstLineIndent = 1;
            row.Cells[9].AddParagraph(request.Supplier.VATNo);

            row.Cells[10].Format.Font.Bold = false;
            row.Cells[10].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[10].Format.FirstLineIndent = 1;
            row.Cells[10].AddParagraph(request.Supplier.Fax);


            row.Cells[11].Format.Font.Bold = false;
            row.Cells[11].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[11].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[11].Format.FirstLineIndent = 1;
            row.Cells[11].AddParagraph(request.Supplier.EMail);

            table.SetEdge(0, 0, 5, 2, Edge.Box, BorderStyle.Single, 0.75);

            doc.LastSection.Add(table);

            doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);

            table = new MigraDoc.DocumentObjectModel.Tables.Table
            {
                Style = "Table",
                Borders = { Color = TableBorder, Width = 0.25, Left = { Width = 0.5 }, Right = { Width = 0.5 } },
                Rows = { LeftIndent = 0 }
            };

            // Columns
            col = table.AddColumn(Unit.FromMillimeter(60));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(25));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(20));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(40));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(20));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(40));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(25));
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn(Unit.FromMillimeter(25));
            col.Format.Alignment = ParagraphAlignment.Center;

            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableBlue;

            row.Cells[0].AddParagraph("Retail Barcode");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[1].AddParagraph("Retail pack Size");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[2].AddParagraph("Ranging");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[3].AddParagraph("Outer Case Code");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[4].AddParagraph("Pack Barcode");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[5].AddParagraph("Product Code");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[6].AddParagraph("Full Product Description");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[6].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[7].AddParagraph("ISIS Retail naming");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[7].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[8].AddParagraph("Category");
            row.Cells[8].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[8].VerticalAlignment = VerticalAlignment.Bottom;


            row.Cells[9].AddParagraph("Brand");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[9].VerticalAlignment = VerticalAlignment.Bottom;


            row.Cells[10].AddParagraph("Pack Size UOM");
            row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[10].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[11].AddParagraph("UOM Type");
            row.Cells[11].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[11].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[12].AddParagraph("Cost Excl.");
            row.Cells[12].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[12].VerticalAlignment = VerticalAlignment.Bottom;

            row.Cells[13].AddParagraph("Case Cost Excl.");
            row.Cells[13].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[13].VerticalAlignment = VerticalAlignment.Bottom;

            foreach (var item in request.SupplierProduct)
            {
                row = table.AddRow();
                row.TopPadding = 1.5;
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                //row.Shading.Color = TableBlue;

                row.Cells[0].Format.Font.Bold = false;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].Format.FirstLineIndent = 1;
                row.Cells[0].AddParagraph(item.RetailBarcode);

                row.Cells[1].Format.Font.Bold = false;
                row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].Format.FirstLineIndent = 1;
                row.Cells[1].AddParagraph(item.RetailPackSize);

                row.Cells[2].Format.Font.Bold = false;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].Format.FirstLineIndent = 1;
                row.Cells[2].AddParagraph(item.Ranging.ToString());

                row.Cells[3].Format.Font.Bold = false;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[3].Format.FirstLineIndent = 1;
                row.Cells[3].AddParagraph(item.OuterCaseCode);

                row.Cells[4].Format.Font.Bold = false;
                row.Cells[4].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].Format.FirstLineIndent = 1;
                row.Cells[4].AddParagraph(item.PackBarcode);

                row.Cells[5].Format.Font.Bold = false;
                row.Cells[5].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[5].Format.FirstLineIndent = 1;
                row.Cells[5].AddParagraph(item.ProductCode);

                row.Cells[6].Format.Font.Bold = false;
                row.Cells[6].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[6].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[6].Format.FirstLineIndent = 1;
                row.Cells[6].AddParagraph(item.ProductCode);

                row.Cells[7].Format.Font.Bold = false;
                row.Cells[7].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[7].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[7].Format.FirstLineIndent = 1;
                row.Cells[7].AddParagraph(item.ProductDescription);

                row.Cells[8].Format.Font.Bold = false;
                row.Cells[8].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[8].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[8].Format.FirstLineIndent = 1;
                row.Cells[8].AddParagraph(item.ISISRetailItemNaming);

                row.Cells[9].Format.Font.Bold = false;
                row.Cells[9].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[9].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[9].Format.FirstLineIndent = 1;
                row.Cells[9].AddParagraph(item.ProductDescription);

                row.Cells[10].Format.Font.Bold = false;
                row.Cells[10].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[10].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[10].Format.FirstLineIndent = 1;
                row.Cells[10].AddParagraph(item.Category);

                row.Cells[11].Format.Font.Bold = false;
                row.Cells[11].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[11].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[11].Format.FirstLineIndent = 1;
                row.Cells[11].AddParagraph(item.PackSizeCase.ToString(CultureInfo.InvariantCulture));

                row.Cells[12].Format.Font.Bold = false;
                row.Cells[12].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[12].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[12].Format.FirstLineIndent = 1;
                row.Cells[12].AddParagraph(item.Cost.ToString());

                row.Cells[13].Format.Font.Bold = false;
                row.Cells[13].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[13].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[13].Format.FirstLineIndent = 1;
                row.Cells[13].AddParagraph(item.CaseCost.ToString());

            }

            table.SetEdge(0, 0, 8, request.SupplierProduct.Count() + 1, Edge.Box, BorderStyle.Single, 0.5);

            doc.LastSection.Add(table);

            para = doc.LastSection.AddParagraph();
            para.Format.Borders.DistanceFromBottom = Unit.FromMillimeter(5);


            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always) { Document = doc };
            renderer.RenderDocument();

            var m = new MemoryStream();
            renderer.PdfDocument.Save(m, false);
            //renderer.PdfDocument.Save(@"c:\temp\test.pdf");
            m.Seek(0, SeekOrigin.Begin);

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition",
                                                              "attachment; filename=" + Path.GetFileName(path));
            System.Web.HttpContext.Current.Response.AddHeader("content-length",
                                                              m.Length.ToString(CultureInfo.InvariantCulture));
            System.Web.HttpContext.Current.Response.BinaryWrite(m.ToArray());
            System.Web.HttpContext.Current.Response.Flush();
            m.Close();
            System.Web.HttpContext.Current.Response.End();
        }

    }
}
