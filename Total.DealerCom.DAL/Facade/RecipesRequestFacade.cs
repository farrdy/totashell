using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Services.DTO;
using Services.DataAccess;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    public class RecipesRequestFacade : IRecipesRequestFacade
    {
        public IEnumerable<string> GetRecipesMasterDataStatusses()
        {
            return RecipesRequestDao.GetRecipesMasterDataStatusses();
        }

        public IEnumerable<string> GetRecipesFoodTechnicianStatusses()
        {
            return RecipesRequestDao.GetRecipesFoodTechnicianStatusses();
        }

        public IEnumerable<RecipesRequest> GetRecipesRequests(RecipesRequestSearch requestFilter)
        {
            return RecipesRequestDao.GetRecipesRequests(requestFilter);
        }

        public RecipesRequest Create(RecipesRequest request)
        {
            return RecipesRequestDao.Create(request);
        }

        public RecipesRequest Update(RecipesRequest request)
        {
            return RecipesRequestDao.Update(request);
        }

        public void RecipesRequestToggleArchive(string list)
        {
            RecipesRequestDao.RecipesRequestToggleArchive(list);
        }

        public DataSet GetRecipesRequestsExport(RecipesRequestSearch requestFilter)
        {
            return RecipesRequestDao.GetRecipesRequestsExport(requestFilter);
        }

        public RecipesRequest RecipesRequestsPendingGet(RecipesRequestSearch requestFilter)
        {
            return RecipesRequestDao.RecipesRequestsPendingGet(requestFilter);
        }

        public IEnumerable<RecipesRequest> GetRecipesRequestsPending(RecipesRequestSearch requestFilter)
        {
            return RecipesRequestDao.GetRecipesRequestsPending(requestFilter);
        }
    }
}
