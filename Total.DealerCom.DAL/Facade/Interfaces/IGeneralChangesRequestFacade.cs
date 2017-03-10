using System.Collections.Generic;
using System.Data;
using Services.DTO;

namespace Services.Facade.Interfaces
{
    public interface IGeneralChangesRequestFacade
    {
        IEnumerable<GeneralChangesRequest> GetGeneralChangesRequests(GeneralChangesRequestSearch requestFilter);

        IEnumerable<string> GetGeneralChangesMasterDataStatusses();

        IEnumerable<string> GetGeneralChangesSpecialistVerificationStatusses();

        GeneralChangesRequest Create(GeneralChangesRequest request);

        GeneralChangesRequest Update(GeneralChangesRequest request);

        void GeneralChangesRequestToggleArchive(string list);

        GeneralChangesItem GeneralChangesItemGet(string itemname);

        GeneralChangesItemGroup GeneralChangesItemGroupGet(string groupname);

        DataSet GetGeneralChangesRequestsExport(GeneralChangesRequestSearch requestFilter);
    }
}
