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
    public class FAQFacade : IFAQFacade
    {

        #region IFAQFacade Members


        public string Add(FAQ faq)
        {
            return FAQDao.Add(faq);
        }

        public string FAQUpdate(FAQ faq)
        {
            //using (var scope = new TransactionScope())
            //{
            //FAQDao.Add(faq);
            //FAQDao.Update(faq);
            //    scope.Complete();
            //}
            return FAQDao.FAQUpdate(faq);
        }

        public FAQ GetFAQ(int questionId)
        {
            return FAQDao.GetFAQ(questionId);
        }

        public IEnumerable<FAQ> GetDetails()
        {
            return FAQDao.GetDetails();
        }

        public IEnumerable<FAQ> GetAllDetails()
        {
            return FAQDao.GetAllDetails();
        }


   
        #endregion
    }
}
