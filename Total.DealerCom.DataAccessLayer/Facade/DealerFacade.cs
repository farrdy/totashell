using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Facade
{
    public class DealerFacade : IDealerFacade
    {

        #region IDealerFacade Members
        public void Add( Dealer dealer)
        {
            //using (var scope = new TransactionScope())
            //{
            DealerDao.Add(dealer);
            DealerDao.Update(dealer);
            //    scope.Complete();
            //}
        }

        public Dealer GetDealerDetails(string dealerId)
        {
            return DealerDao.GetDealerDetails(dealerId);
        }

        public IEnumerable<Dealer> SearchDealerUpdates(Dealer dealer)
        {
            return DealerDao.SearchDealerUpdates(dealer);
        }


        public IEnumerable<Dealer> GetDealerMaster()
        {
            return DealerDao.GetDealerMaster();
        }
        #endregion
    }
}
