using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Facade
{
    public class GeneralChangesLinkFacade : IGeneralChangesLinkFacade
    {
        public GeneralChangesLink Create(GeneralChangesLink link)
        {
            return GeneralChangesLinkDao.Create(link);
        }

        public GeneralChangesLink Update(GeneralChangesLink link)
        {
            return GeneralChangesLinkDao.Update(link);
        }
    }
}
