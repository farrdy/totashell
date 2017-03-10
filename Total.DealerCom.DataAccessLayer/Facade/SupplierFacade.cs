using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using System.Data;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;


namespace Total.DealerCom.DataAccessLayer.Facade
{
    /// <summary>
    /// Supplierfacade  
    /// </summary>
    public class SupplierFacade : ISupplierFacade
    {

        public int Add(Supplier supplier)
        {

            return SupplierDao.Add(supplier);
        }

        public int Update(Supplier supplier)
        {

            return SupplierDao.Update(supplier);
        }

        public Supplier SupplierGet(int supplierid)
        {
            return SupplierDao.SupplierGet(supplierid);
        }


        public List<Supplier> GetAll()
        {
            return SupplierDao.GetAll();
        }

        public  IEnumerable<SupplierSearch> Search(SupplierSearch suppliersearch)
        {
            return SupplierDao.Search(suppliersearch);
        }

        public void SupplierArchive(string suppliersid, bool archive)
        {
             SupplierDao.SupplierArchive(suppliersid, archive);
        }

        public DataSet ExportToExcel(SupplierSearch suppliersearch)
        {
            return SupplierDao.ExportToExcel(suppliersearch);
        }

        public DataSet SupplierProductSearch(SupplierSearch suppliersearch)
        {
            return SupplierDao.SupplierProductSearch(suppliersearch);
        }

        public IEnumerable<SupplierRequest> GetSupplierRequests(SupplierRequest suppliersearch)
        {
            return SupplierDao.GetSupplierRequests(suppliersearch);
        }
    }

}







