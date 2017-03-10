using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// IRequesterfacade  
    /// </summary>
    public interface IRequesterFacade
    {

        int Add(Requester requester);

        int Update(Requester requester);

        Requester GetRequester(int requesterid);

        List<Requester> GetAll();

    }

}

