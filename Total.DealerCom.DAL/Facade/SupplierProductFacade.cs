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
    /// SupplierProductfacade  
    /// </summary>
    public class SupplierProductFacade : ISupplierProductFacade
    {

        public int Add(SupplierProduct supplierproduct)
        {

            return SupplierProductDao.Add(supplierproduct);
        }

        public int Update(SupplierProduct supplierproduct)
        {

            return SupplierProductDao.Update(supplierproduct);
        }

        public SupplierProduct SupplierProductGet(int supplierproductid)
        {
            return SupplierProductDao.SupplierProductGet(supplierproductid);
        }


        public List<SupplierProduct> GetAll()
        {
            return SupplierProductDao.GetAll();
        }

        public  List<SupplierProduct> GetSupplierProducts(int supplierid)
        {
            return SupplierProductDao.GetSupplierProducts(supplierid);
        }
    }

}







