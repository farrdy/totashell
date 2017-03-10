using System.Collections.Generic;
using Services.DTO;

namespace Services.Facade.Interfaces
{
    public interface IGeneralChangesFacade
    {
        //void CreateGeneralChangeRequest(GeneralChangeRequest)

        IEnumerable<GeneralChangesItemGroup> GetGeneralChangesItemGroups();

        GeneralChangesItemGroup SaveGeneralChangesItemGroup(GeneralChangesItemGroup group);

        GeneralChangesItem SaveGeneralChangesItem(GeneralChangesItem item);
    }
}
