using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Web.UI.WebControls;
using Infrastructure.Server.DataAccess;
using Infrastructure.Shared.Security;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

	
namespace Total.DealerCom.DataAccessLayer.Facade
{
	/// <summary>
    /// Provincefacade  
    /// </summary>
	public  class ProvinceFacade : IProvinceFacade
    {

		public  Province ProvinceGet(string prov)
			{
				return ProvinceDao.ProvinceGet(prov);
			}
	

		public  List<Province> GetAll()
			{
				return ProvinceDao.GetAll();
			}

        public void Edit(Province province)
        {
             ProvinceDao.Edit(province);
        }
        public List<string> PopulateProvinceList(ref DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var provinceList = ProvinceDao.GetAll();
            var returnList = new List<string>();
            returnList.Add("");
            dropDownList.Items.Add(new ListItem(""));
            foreach (var p in provinceList)
            {
                returnList.Add(p.Prov);
                dropDownList.Items.Add(new ListItem( p.Prov));
            }
            dropDownList.SelectedIndex = 0;
            return returnList;
        }

	}  

}







