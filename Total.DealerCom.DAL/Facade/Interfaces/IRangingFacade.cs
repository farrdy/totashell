using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Services.DTO;


namespace Services.Facade.Interfaces
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

