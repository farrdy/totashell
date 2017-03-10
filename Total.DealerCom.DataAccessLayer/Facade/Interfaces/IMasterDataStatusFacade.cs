using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// IMasterDataStatusfacade  
    /// </summary>
    public interface IMasterDataStatusFacade
    {


        MasterDataStatus MasterDataStatusGet(string status);

        List<MasterDataStatus> GetAll();

        List<string> PopulateStatusList(ref DropDownList dropDownList);

    }

}

