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
    /// SupplierStagingfacade  
    /// </summary>
    public class SupplierStagingFacade : ISupplierStagingFacade
    {

        public int Add(SupplierStaging supplierstaging)
        {

            return SupplierStagingDao.Add(supplierstaging);
        }

        public int Update(SupplierStaging supplierstaging)
        {

            return SupplierStagingDao.Update(supplierstaging);
        }

        public SupplierStaging SupplierStagingGet(int supplierid)
        {
            return SupplierStagingDao.SupplierStagingGet(supplierid);
        }

        public List<SupplierStaging> SupplierRequesterStagingGet(int requesterid)
        {
            return SupplierStagingDao.SupplierRequesterStagingGet(requesterid);
        }

        public List<SupplierStaging> CheckSuppliers(int requesterid)
        {
            return SupplierStagingDao.CheckSuppliers(requesterid);
        }

        public List<SupplierStaging> GetAll()
        {
            return SupplierStagingDao.GetAll();
        }

        public int SaveToFinal(int requesterid, int supplierid)
        {
            return SupplierStagingDao.SaveToFinal(requesterid, supplierid);
        }
    }

}







