using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IFAQFacade
    {
        
        string Add(FAQ faq);

        IEnumerable<FAQ> GetDetails();

        IEnumerable<FAQ> GetAllDetails();

        FAQ GetFAQ(int questionId);

        string FAQUpdate(FAQ faq);
    }
}
