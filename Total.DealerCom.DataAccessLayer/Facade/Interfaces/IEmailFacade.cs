
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IEmailFacade
    {
        string SendEmail(Email email);

        void SendEmail(string requestStatus, IssueResult instance);

        void SendMerchandiseEmail(Email email);

        void SendDealerEmail(Dealer dealer);

        void SendFAQEmail();
    }
}