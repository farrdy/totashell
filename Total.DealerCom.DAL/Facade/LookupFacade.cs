using System.Collections.Generic;
using System.Web.UI.WebControls;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    public class LookupFacade : ILookupFacade
    {
        #region IFacadeFactory Members

        public IEnumerable<Lookup> GetLookup(LookupSearch lookup)
        {
            return LookupDao.ReturnLookup(lookup);
        }

       
        public DropDownList Populate(ref DropDownList dropDownList, LookupSearch lookup, bool insertEmptyRow)
        {
            //Clearing the dropdownList
            dropDownList.Items.Clear();

            //Finding the dropdown items
            IEnumerable<Lookup> list = GetLookup(lookup);

            if(insertEmptyRow)dropDownList.Items.Add(new ListItem(string.Empty, string.Empty));

            //Populating the dropdown items
            foreach(Lookup item in list)
            {
                dropDownList.Items.Add(new ListItem(item.Value, item.Id));
            }

            return dropDownList;
        }

        public void Edit(Lookup lookup)
        {
            LookupDao.Edit(lookup);
        }

        public List<string> PopulateUOMType(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var UOMTypeList = LookupDao.GetUOMType();
            var returnList = new List<string>();
            returnList.Add("");
            dropDownList.Items.Add(new ListItem(""));
            foreach (var uomtype in UOMTypeList)
            {
                returnList.Add(uomtype.UOMType);
                dropDownList.Items.Add(new ListItem(uomtype.UOMType));
            }
            dropDownList.SelectedIndex = 0;
            return returnList;
        }

        public List<string> PopulateUOM(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var UOMList = LookupDao.GetUOM();
            var returnList = new List<string>();
            returnList.Add("");
            dropDownList.Items.Add(new ListItem(""));
            foreach (var uom in UOMList)
            {
                returnList.Add(uom.UOM);
                dropDownList.Items.Add(new ListItem(uom.UOM));
            }
            dropDownList.SelectedIndex = 0;
            return returnList;
        }


        public List<string> PopulateRanging(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var List = LookupDao.GetRanging();
            var returnList = new List<string>();
            returnList.Add("");
            dropDownList.Items.Add(new ListItem(""));
            foreach (var r in List)
            {
                returnList.Add(r.Rang);
                dropDownList.Items.Add(new ListItem(r.Rang));
            }
            dropDownList.SelectedIndex = 0;
            return returnList;
        }
          #endregion
    }
}