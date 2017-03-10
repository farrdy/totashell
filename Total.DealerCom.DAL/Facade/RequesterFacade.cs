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







