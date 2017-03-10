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
    /// RequesterStagingfacade  
    /// </summary>
    public class RequesterStagingFacade : IRequesterStagingFacade
    {

        public int Add(RequesterStaging requesterstaging)
        {

            return RequesterStagingDao.Add(requesterstaging);
        }

        public int Update(RequesterStaging requesterstaging)
        {

            return RequesterStagingDao.Update(requesterstaging);
        }

        public RequesterStaging RequesterStagingGet(string sitenumber)
        {
            return RequesterStagingDao.RequesterStagingGet(sitenumber);
        }

        public void Delete(int requesterid)
        {
            RequesterStagingDao.Delete(requesterid);
        }

        public List<RequesterStaging> GetAll()
        {
            return RequesterStagingDao.GetAll();
        }
    }

}







