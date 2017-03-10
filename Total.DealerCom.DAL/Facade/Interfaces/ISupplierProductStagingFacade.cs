using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infrastructure.Shared.Security;
using Services.DTO;


namespace Services.Facade.Interfaces
{
    /// <summary>
    /// ISupplierProductStagingfacade  
    /// </summary>
    public interface ISupplierProductStagingFacade
    {

        int Add(SupplierProductStaging supplierproductstaging);

        int Update(SupplierProductStaging supplierproductstaging);

        SupplierProductStaging SupplierProductStagingGet(int supplierproductid);

        List<SupplierProductStaging> GetAll();

         List<SupplierProductStaging> GetSupplierProducts(int supplierid);
         
        List<SupplierProductStaging> CheckProducts(int requesterid);

       int SaveToFinal(int stagingsupplierID, int supplierid);

       void DeleteProduct(int supplierproductid);
  
       void Delete(int supplierid);


    }

}

