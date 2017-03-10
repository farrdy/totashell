using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.DTO;

namespace Services.Facade.Interfaces
{
    public interface IDealerFacade
    {

        void Add(Dealer dealer);

        Dealer GetDealerDetails(string dealerId);

        IEnumerable<Dealer> SearchDealerUpdates(Dealer dealer);

        IEnumerable<Dealer> GetDealerMaster();
    }
}
