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
    /// Rangingfacade  
    /// </summary>
    public class RangingFacade : IRangingFacade
    {

        public Ranging RangingGet(string rang)
        {
            return RangingDao.RangingGet(rang);
        }


        public List<Ranging> GetAll()
        {
            return RangingDao.GetAll();
        }
    }

}







