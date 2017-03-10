using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IDealerFacade
    {

        void Add(Dealer dealer);

        Dealer GetDealerDetails(string dealerId);

        IEnumerable<Dealer> SearchDealerUpdates(Dealer dealer);

        IEnumerable<Dealer> GetDealerMaster();
    }
}
