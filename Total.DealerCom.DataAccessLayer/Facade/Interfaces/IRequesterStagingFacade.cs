using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// IRequesterStagingfacade  
    /// </summary>
    public interface IRequesterStagingFacade
    {

        int Add(RequesterStaging requesterstaging);

        int Update(RequesterStaging requesterstaging);

        RequesterStaging RequesterStagingGet(string sitenumber);

        void Delete(int requesterid);

        List<RequesterStaging> GetAll();

      
    }

}

