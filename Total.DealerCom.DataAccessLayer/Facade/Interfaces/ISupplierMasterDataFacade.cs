using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;


namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// ISupplierMasterDatafacade  
    /// </summary>
    public interface ISupplierMasterDataFacade
    {

        int Add(SupplierMasterData suppliermasterdata);

        int Update(SupplierMasterData suppliermasterdata);

        SupplierMasterData GetSupplierMasterData(int suppliermasterdataid);

        List<SupplierMasterData> GetAll();

        IEnumerable<SupplierSearch> Search(SupplierSearch suppliersearch);

        void SupplierMasterDataArchive(string suppliersasterdata);


    }

}

