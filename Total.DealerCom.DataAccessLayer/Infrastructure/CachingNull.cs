using Total.DealerCom.DataAccessLayer.Infrastructure.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Infrastructure
{
    public class CachingNull : ICache
    {
        #region ICache Members

        public TResult Get<TResult>(string keyName) where TResult : class
        {
            return null;
        }

        public object Get(string keyName)
        {
            return null;
        }

        public void Add<TItem>(string keyName, TItem item)
        {
        }

        #endregion
    }
}