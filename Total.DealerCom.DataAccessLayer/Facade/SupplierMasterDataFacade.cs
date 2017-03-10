using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;


namespace Total.DealerCom.DataAccessLayer.Facade
{
    /// <summary>
    /// SupplierMasterDatafacade  
    /// </summary>
    public class SupplierMasterDataFacade : ISupplierMasterDataFacade
    {

        public int Add(SupplierMasterData suppliermasterdata)
        {

            return SupplierMasterDataDao.Add(suppliermasterdata);
        }

        public int Update(SupplierMasterData suppliermasterdata)
        {

            return SupplierMasterDataDao.Update(suppliermasterdata);
        }

        public SupplierMasterData GetSupplierMasterData(int suppliermasterdataid)
        {
            return SupplierMasterDataDao.SupplierMasterDataGet(suppliermasterdataid);
        }


        public List<SupplierMasterData> GetAll()
        {
            return SupplierMasterDataDao.GetAll();
        }

        public IEnumerable<SupplierSearch> Search(SupplierSearch suppliersearch)
        {
            return SupplierMasterDataDao.Search(suppliersearch);
        }

        public  void SupplierMasterDataArchive(string suppliersasterdata)
        {
            SupplierMasterDataDao.SupplierMasterDataArchive(suppliersasterdata);
        }
    }

}







