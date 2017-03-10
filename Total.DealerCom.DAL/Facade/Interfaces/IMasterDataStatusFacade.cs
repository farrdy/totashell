using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Services.DTO;


namespace Services.Facade.Interfaces
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

