using System.Collections.Generic;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface IGeneralChangesFacade
    {
        //void CreateGeneralChangeRequest(GeneralChangeRequest)

        IEnumerable<GeneralChangesItemGroup> GetGeneralChangesItemGroups();

        GeneralChangesItemGroup SaveGeneralChangesItemGroup(GeneralChangesItemGroup group);

        GeneralChangesItem SaveGeneralChangesItem(GeneralChangesItem item);
    }
}
