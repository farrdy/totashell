using System.Collections.Generic;
using Services.DTO;

namespace Services.Facade.Interfaces
{
    public interface IRecipesItemFacade
    {
        RecipesItem RecipesItemGet(int itemId);

        IEnumerable<RecipesItem> RecipesItemsGet(RecipesRequest request);

        RecipesItem Create(RecipesItem recipesItem);

        RecipesItem Update(RecipesItem recipesItem);

        void Delete(int id);
    }
}
