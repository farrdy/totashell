using System.Collections.Generic;
using Services.DTO;
using Services.DataAccess;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    public class GeneralChangesFacade : IGeneralChangesFacade
    {
        #region IGeneralChangesFacade Members

        public IEnumerable<DTO.GeneralChangesItemGroup> GetGeneralChangesItemGroups()
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
