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
    /// Requesterfacade  
    /// </summary>
    public class RequesterFacade : IRequesterFacade
    {

        public int Add(Requester requester)
        {

            return RequesterDao.Add(requester);
        }

        public int Update(Requester requester)
        {

            return RequesterDao.Update(requester);
        }

        public Requester GetRequester(int requesterid)
        {
            return RequesterDao.RequesterGet(requesterid);
        }


        public List<Requester> GetAll()
        {
            return RequesterDao.GetAll();
        }
    }

}







