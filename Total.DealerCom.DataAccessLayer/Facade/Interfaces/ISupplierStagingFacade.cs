using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// ISupplierStagingfacade  
    /// </summary>
    public interface ISupplierStagingFacade
    {

        int Add(SupplierStaging supplierstaging);

        int Update(SupplierStaging supplierstaging);

        SupplierStaging SupplierStagingGet(int supplierid);

        List<SupplierStaging> SupplierRequesterStagingGet(int requesterid);

        List<SupplierStaging> GetAll();

        List<SupplierStaging> CheckSuppliers(int requesterid);

        int SaveToFinal(int requesterid, int supplierid);

    }

}

