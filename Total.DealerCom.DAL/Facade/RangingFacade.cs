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







