using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;


namespace Services.Facade
{
    /// <summary>
    /// SupplierProductStagingfacade  
    /// </summary>
    public class SupplierProductStagingFacade : ISupplierProductStagingFacade
    {

        public int Add(SupplierProductStaging supplierproductstaging)
        {

            return SupplierProductStagingDao.Add(supplierproductstaging);
        }

        public int Update(SupplierProductStaging supplierproductstaging)
        {

            return SupplierProductStagingDao.Update(supplierproductstaging);
        }

        public SupplierProductStaging SupplierProductStagingGet(int supplierproductid)
        {
            return SupplierProductStagingDao.SupplierProductStagingGet(supplierproductid);
        }

        public  List<SupplierProductStaging> CheckProducts(int requesterid)
        {
            return SupplierProductStagingDao.CheckProducts(requesterid);
        }

        public void Delete(int supplierid)
        {
            SupplierProductStagingDao.Delete(supplierid);
        }

        public void DeleteProduct(int supplierproductid)
        {
            SupplierProductStagingDao.DeleteProduct(supplierproductid);
        }
        public int SaveToFinal(int stagingsupplierID, int supplierid)
        {
            return SupplierProductStagingDao.SaveToFinal(stagingsupplierID, supplierid);
        }

        public List<SupplierProductStaging> GetAll()
        {
            return SupplierProductStagingDao.GetAll();
        }

        public  List<SupplierProductStaging> GetSupplierProducts(int supplierid)
        {
            return SupplierProductStagingDao.GetSupplierProducts(supplierid);
        }
    }

}







