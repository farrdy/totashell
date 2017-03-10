namespace Services.Infrastructure.Interfaces
{
    /// <summary>
    /// Example of caching interface
    /// </summary>
    public interface ICache
    {
        TResult Get<TResult>(string keyName) where TResult : class;
        object Get(string keyName);
        void Add<TItem>(string keyName, TItem item);
    }
}