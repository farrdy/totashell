using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Services.DTO;


namespace Services.Facade.Interfaces
{
    /// <summary>
    /// ISupplierProductfacade  
    /// </summary>
    public interface ISupplierProductFacade
    {

        int Add(SupplierProduct supplierproduct);

        int Update(SupplierProduct supplierproduct);

        SupplierProduct SupplierProductGet(int supplierproductid);

        List<SupplierProduct> GetAll();

        List<SupplierProduct> GetSupplierProducts(int supplierid);

    }

}

