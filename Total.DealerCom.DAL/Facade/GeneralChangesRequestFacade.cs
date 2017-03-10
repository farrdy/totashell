using System.Collections.Generic;
using System.Data;
using Services.DTO;
using Services.DataAccess;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    public class GeneralChangesRequestFacade : IGeneralChangesRequestFacade
    {
        public IEnumerable<GeneralChangesRequest> GetGeneralChangesRequests(GeneralChangesRequestSearch requestFilter)
        {
            return GeneralChangesRequestDao.GetGeneralChangesRequests(requestFilter);
        }
        public IEnumerable<string> GetGeneralChangesMasterDataStatusses()
        {
            return GeneralChangesRequestDao.GetGeneralChangesMasterDataStatusses();
        }

        public IEnumerable<string> GetGeneralChangesSpecialistVerificationStatusses()
        {
            return GeneralChangesRequestDao.GetGeneralChangesSpecialistVerificationStatusses();
        }

        public GeneralChangesItem GeneralChangesItemGet(string itemname)
        {
            return GeneralChangesRequestDao.GeneralChangesItemGet(itemname);
        }

        public GeneralChangesItemGroup GeneralChangesItemGroupGet(string groupname)
        {
            return GeneralChangesRequestDao.GeneralChangesItemGroupGet(groupname);
        }
        public GeneralChangesRequest Create(GeneralChangesRequest request)
        {
            return GeneralChangesRequestDao.Create(request);
        }

        public GeneralChangesRequest Update(GeneralChangesRequest request)
        {
            return GeneralChangesRequestDao.Update(request);
        }

        public void GeneralChangesRequestToggleArchive(string list)
        {
            GeneralChangesRequestDao.GeneralChangesRequestToggleArchive(list);
        }

        public DataSet GetGeneralChangesRequestsExport(GeneralChangesRequestSearch requestFilter)
        {
            return GeneralChangesRequestDao.GetGeneralChangesRequestsExport(requestFilter);
        }
    }
}
