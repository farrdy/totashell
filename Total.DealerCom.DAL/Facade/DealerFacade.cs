using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;

namespace Services.Facade
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
