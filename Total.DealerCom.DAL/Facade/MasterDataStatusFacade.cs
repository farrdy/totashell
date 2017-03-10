using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Web.UI.WebControls;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;


namespace Services.Facade
{
    /// <summary>
    /// MasterDataStatusfacade  
    /// </summary>
    public class MasterDataStatusFacade : IMasterDataStatusFacade
    {

        public MasterDataStatus MasterDataStatusGet(string status)
        {
            return MasterDataStatusDao.MasterDataStatusGet(status);
        }
        
        public List<MasterDataStatus> GetAll()
        {
            return MasterDataStatusDao.GetAll();
        }

        public List<string> PopulateStatusList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var StatusList = MasterDataStatusDao.GetAll();
            var returnList = new List<string>();
            returnList.Add("");
            dropDownList.Items.Add(new ListItem(""));
            foreach (var s in StatusList)
            {
                returnList.Add(s.Status);
                dropDownList.Items.Add(new ListItem(s.Status));
            }

            dropDownList.SelectedIndex = 0;

            return returnList;
        }
    }

}







