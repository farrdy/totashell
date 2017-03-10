using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// IProvincefacade  
    /// </summary>
    public interface IProvinceFacade
    {


        Province ProvinceGet(string prov);

        List<Province> GetAll();

        List<string> PopulateProvinceList(ref DropDownList dropDownList);

        void Edit(Province province);
    }

}

