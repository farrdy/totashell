using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using Total.DealerCom.DataAccessLayer;
using Total.DealerCom.Core;

namespace TotalDealer_2008.List
{
    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Title = "Search - Dealer Communication";

            if (!IsPostBack)
            {
                LookupSetup();
            }
        }

        private void LookupSetup()
        {
            TypesTable.Visible = false;
            TypePanel.Visible = false;
            TypesPanel.Visible = false;
            CatPanel.Visible = false;

            lblTypeStatus.Text = string.Empty;
            lblCatStatus.Text = string.Empty;
            lblError.Text = string.Empty;
            lblErrorTypes.Text = string.Empty;

            btnTypeAdd.Visible = false;
            btnCatAdd.Visible = false;
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            lblTypeStatus.Text = string.Empty;
            lblCatStatus.Text = string.Empty;
            lblError.Text = string.Empty;
            lblErrorTypes.Text = string.Empty;

            if (ListOptions.SelectedValue == "ArticleCat")
            {
                TypesTable.Visible = false;
                TypePanel.Visible = false;
                TypesPanel.Visible = false;

                CatPanel.Visible = true;
                btnCatAdd.Visible = true;
                btnTypeAdd.Visible = false;

                grdCatResults.PageIndex = 0;
                BindCategories();
            }

            if (ListOptions.SelectedValue == "ArticleType")
            {
                TypesTable.Visible = true;
                TypePanel.Visible = true;
                TypesPanel.Visible = true;
                btnTypeAdd.Visible = false;
                btnCatAdd.Visible = false;

                CatPanel.Visible = false;

                FacadeRepository.GetLookupFacade().Populate(ref dropdownTypes,
                new LookupSearch { IDParent = null, Lookup = Constants.ArticleCategory, ShowInactive = false }, false);
            }
        }

        private void BindCategories()
        {
            IEnumerable<Lookup> lookups =
                FacadeRepository.GetLookupFacade().GetLookup(new LookupSearch
                {
                    IDParent = null,
                    Lookup = Constants.ArticleCategory,
                    ShowInactive = true
                });

            BindData(lookups, ref grdCatResults);
        }

        protected void btnSelectType_Click(object sender, EventArgs e)
        {
            lblTypeStatus.Text = string.Empty;
            lblCatStatus.Text = string.Empty;
            lblError.Text = string.Empty;
            lblErrorTypes.Text = string.Empty;

            btnTypeAdd.Visible = true;
            btnCatAdd.Visible = false;

            //Finding parent Id of selected dropdown category
            var lookup =
                FacadeRepository.GetLookupFacade().GetLookup(
                new LookupSearch { IDParent = null, Lookup = Constants.ArticleCategory, ShowInactive = false })
                .Where(o => o.Id == dropdownTypes.SelectedValue).First();

            var parentId = "";
            if (lookup != null)
            {
                parentId = lookup.Id;
            }

            IEnumerable<Lookup> lookups =
                FacadeRepository.GetLookupFacade().GetLookup(new LookupSearch
                                                                 {
                                                                     IDParent = Convert.ToInt32(parentId),
                                                                     Lookup = Constants.ArticleType,
                                                                     ShowInactive = true
                                                                 });
            grdResults.PageIndex = 0;
            BindData(lookups, ref grdResults);
        }

        /// <summary>
        /// Performs search and binds search results to grid control
        /// </summary>
        private void BindData(IEnumerable<Lookup> dataList, ref GridView gridView)
        {
            gridView.DataSource = dataList;
            gridView.DataBind();

            if (gridView.DataSource != null) Session[gridView.ID] = gridView.DataSource;

            if (gridView.DataSource == null) Session[gridView.ID] = new List<Lookup>();

            //Need the datasource to persist accros postbacks so we can add new records to it if needed.
            
        }


        protected void grdResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblErrorTypes.Text = string.Empty;
            string currentCommand = e.CommandName;
            
            //Update button was clicked. Updating selected lookup on database.
            if (currentCommand == "Update")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                
                //Extracting data-keys for the updated row
                DataKey myData = grdResults.DataKeys[currentRowIndex];
                if (myData != null)
                {
                    string id = myData.Values["Id"].ToString();
                    string idParent = myData.Values["idParent"].ToString();
                    string lookupName = myData.Values["LookupName"].ToString();

                    IOrderedDictionary fieldValues = new OrderedDictionary();
                    GridViewRow editedRow = grdResults.Rows[currentRowIndex];

                    //Obtaining values of BoundField controls
                    foreach (TableCell cell in editedRow.Cells)
                    {
                        if (cell is DataControlFieldCell)
                        {
                            ((DataControlFieldCell) cell).ContainingField.ExtractValuesFromCell(fieldValues,
                                                                                                ((DataControlFieldCell) cell),
                                                                                                DataControlRowState.Normal,
                                                                                                true);
                        }
                    }

                    //New values given by user

                    object isActive = fieldValues["isActive"] ?? "false";
                    object sortOrder = fieldValues["SortOrder"] ?? "0";
                    object value = fieldValues["Value"] ?? string.Empty;

                    if(value.ToString() == string.Empty)
                    {
                        lblErrorTypes.Text = "Value is mandatory and cannot be empty";
                        return;
                    }

                    if (value.ToString().ToUpper() == "ENTER VALUE")
                    {
                        lblErrorTypes.Text = "Value is mandatory and cannot be empty";
                        return;
                    }

                    //Performing database update for lookup
                    FacadeRepository.GetLookupFacade().Edit(new Lookup
                                                                {Id = id, IDParent = idParent, IsActive = Convert.ToBoolean(isActive), LookupName = lookupName, SortOrder = sortOrder.ToString(), Value = value.ToString()});
                }

                //Disabling the gridview edit-mode
                grdResults.EditIndex = -1;
                btnSelectType_Click(this, new EventArgs());
            }
        }

        
        protected void grdResults_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = false;
            //Do nothing here. Event just needs to be handled for some mysterious reason.
        }

        protected void grdResults_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdResults.EditIndex = e.NewEditIndex;
       
            btnSelectType_Click(this, new EventArgs());
        }

        protected void grdResults_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdResults.EditIndex = -1;

            btnSelectType_Click(this, new EventArgs());
        }

        protected void grdResults_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            grdResults.EditIndex = -1;
            //Do nothing here. Event just needs to be handled for some mysterious reason.
        }

        protected void grdResults_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdResults.PageIndex = e.NewPageIndex;
            btnSelectType_Click(this, new EventArgs());
        }
       
        protected void grdCatResults_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdCatResults.PageIndex = e.NewPageIndex;
            BindCategories();
        }

        protected void grdCatResults_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCatResults.EditIndex = -1;
            BindCategories();
        }

        protected void grdCatResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblError.Text = string.Empty;
            string currentCommand = e.CommandName;

            //Update button was clicked. Updating selected lookup on database.
            if (currentCommand == "Update")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());

                //Extracting data-keys for the updated row. Checking that datakeys is not null. i.e. No search results.
                DataKey myData = grdCatResults.DataKeys[currentRowIndex];
                if (myData != null)
                {
                    string id = myData.Values["Id"].ToString();

                    string lookupName = myData.Values["LookupName"].ToString();

                    IOrderedDictionary fieldValues = new OrderedDictionary();
                    GridViewRow editedRow = grdCatResults.Rows[currentRowIndex];

                    //Obtaining values of BoundField controls
                    foreach (TableCell cell in editedRow.Cells)
                    {
                        if (cell is DataControlFieldCell)
                        {
                            ((DataControlFieldCell)cell).ContainingField.ExtractValuesFromCell(fieldValues,
                                                                                               ((DataControlFieldCell)cell),
                                                                                               DataControlRowState.Normal,
                                                                                               true);
                        }
                    }

                    //New values given by user
                    object isActive = fieldValues["isActive"] ?? "false" ;
                    object sortOrder = fieldValues["SortOrder"] ?? "0";
                    object value = fieldValues["Value"] ?? string.Empty;

                    if (value.ToString() == string.Empty)
                    {
                        lblError.Text = "Value is mandatory and cannot be empty";
                        return;
                    }

                    if (value.ToString().ToUpper() == "ENTER VALUE")
                    {
                        lblError.Text = "Value is mandatory and cannot be empty";

                        //Disabling the gridview edit-mode
                        grdCatResults.EditIndex = -1;
                        BindCategories();
                        return;
                    }


                    //Performing database update for lookup
                    FacadeRepository.GetLookupFacade().Edit(new Lookup { Id = id, IDParent = null, IsActive = Convert.ToBoolean(isActive), LookupName = lookupName, SortOrder = sortOrder.ToString(), Value = value.ToString() });
                }

                //Disabling the gridview edit-mode
                grdCatResults.EditIndex = -1;
                BindCategories();
            }
        }

        protected void grdCatResults_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCatResults.EditIndex = e.NewEditIndex;
            BindCategories();
        }

        protected void grdCatResults_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = false;
        }

        protected void grdCatResults_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            grdCatResults.EditIndex = -1;
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            var dt = (List<Lookup>)Session[grdCatResults.ID];
            
            //Inserting the new item at the start of the list
            dt.Insert(0, new Lookup{Value = "Enter value", Id = "0", IDParent = "", IsActive = true, LookupName = "ArticleCat", SortOrder = "0"});
            
            //Setting the result page-index to the first page
            grdCatResults.DataSource = dt;
            grdCatResults.PageIndex = 0;
            grdCatResults.DataBind();

            //Setting the first item (now the newly added item) to edit-mode
            grdCatResults.EditIndex = 0;
            grdCatResults.DataBind();
        }

        protected void btnAddType_Click(object sender, EventArgs e)
        {
            List<Lookup> dt = (List<Lookup>)Session[grdResults.ID];

            dt.Insert(0, new Lookup{ Value = "Enter value", Id = "0", IDParent = dropdownTypes.SelectedValue, IsActive = true, LookupName = "ArticleType", SortOrder = "0" });
            
            grdResults.DataSource = dt;
            grdResults.PageIndex = 0;
            grdResults.DataBind();

            grdResults.EditIndex = 0;
            grdResults.DataBind();
        }

        protected void grdCatResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Edit) || 
       (e.Row.RowState == (DataControlRowState.Edit|DataControlRowState.Alternate)))
        {
            e.Row.Cells[0].Width = Unit.Pixel(35);

            e.Row.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) {__doPostBack('" + grdCatResults.UniqueID + "', 'Update$" + 
               e.Row.RowIndex + "'); return false; }");
        } 

        }

        protected void grdResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Edit) ||
      (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)))
            {
                e.Row.Cells[0].Width = Unit.Pixel(35);
                e.Row.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) {__doPostBack('" + grdResults.UniqueID + "', 'Update$" +
                   e.Row.RowIndex + "'); return false; }");
            } 
        }
    }
}
