using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Server.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Facade
{
    public class RecipesItemFacade : IRecipesItemFacade
    {
        public RecipesItem RecipesItemGet(int itemId)
        {
            return RecipesItemDao.RecipesItemGet(itemId);
        }

        public IEnumerable<RecipesItem> RecipesItemsGet(RecipesRequest request)
        {
            return RecipesItemDao.RecipesItemsGet(request);
        }

        public RecipesItem Create(RecipesItem recipesItem)
        {
            return RecipesItemDao.Create(recipesItem);
        }

        public RecipesItem Update(RecipesItem recipesItem)
        {
            return RecipesItemDao.Update(recipesItem);
        }

        public void Delete(int id)
        {
            RecipesItemDao.Delete(id);
        }
    }
}
