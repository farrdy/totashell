using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Services.DTO;

namespace Services.Facade.Interfaces
{
    public interface IRecipesRequestFacade
    {
        IEnumerable<string> GetRecipesMasterDataStatusses();

        IEnumerable<string> GetRecipesFoodTechnicianStatusses();

        IEnumerable<RecipesRequest> GetRecipesRequests(RecipesRequestSearch requestFilter);

        RecipesRequest Create(RecipesRequest request);

        RecipesRequest Update(RecipesRequest request);

        void RecipesRequestToggleArchive(string list);

        DataSet GetRecipesRequestsExport(RecipesRequestSearch requestFilter);

        RecipesRequest RecipesRequestsPendingGet(RecipesRequestSearch requestFilter);

        IEnumerable<RecipesRequest> GetRecipesRequestsPending(
   RecipesRequestSearch requestFilter);

    }
}
