using Services.DTO;
using Services.DataAccess;
using Services.Facade.Interfaces;

namespace Services.Facade
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
