using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    /// <summary>
    /// ISupplierfacade  
    /// </summary>
    public interface ISupplierFacade
    {

        int Add(Supplier supplier);

        int Update(Supplier supplier);

        Supplier SupplierGet(int supplierid);

        List<Supplier> GetAll();

        IEnumerable<SupplierSearch> Search(SupplierSearch suppliersearch);

        void SupplierArchive(string suppliersid, bool archive);

        DataSet ExportToExcel(SupplierSearch suppliersearch);

        DataSet SupplierProductSearch(SupplierSearch suppliersearch);

        IEnumerable<SupplierRequest> GetSupplierRequests(SupplierRequest suppliersearch);
    }

}

