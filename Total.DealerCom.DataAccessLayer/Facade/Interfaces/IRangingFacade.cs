using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// IRangingfacade  
    /// </summary>
    public interface IRangingFacade
    {

        Ranging RangingGet(string rang);

        List<Ranging> GetAll();

    }

}

