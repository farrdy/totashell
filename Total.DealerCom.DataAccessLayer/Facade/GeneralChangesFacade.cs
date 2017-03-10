using System.Collections.Generic;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Facade
{
    public class GeneralChangesFacade : IGeneralChangesFacade
    {
        #region IGeneralChangesFacade Members

        public IEnumerable<Total.DealerCom.Core.GeneralChangesItemGroup> GetGeneralChangesItemGroups()
        {
            return GeneralChangesDao.GetGeneralChangesGroups();
        }

        public GeneralChangesItemGroup SaveGeneralChangesItemGroup(GeneralChangesItemGroup group)
        {
            return GeneralChangesDao.SaveGeneralChangesItemGroup(group);
        }

        public GeneralChangesItem SaveGeneralChangesItem(GeneralChangesItem item)
        {
            return GeneralChangesDao.SaveGeneralChangesItem(item);
        }

        #endregion
    }
}
