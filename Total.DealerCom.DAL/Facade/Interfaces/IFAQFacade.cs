using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.DTO;

namespace Services.Facade.Interfaces
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
