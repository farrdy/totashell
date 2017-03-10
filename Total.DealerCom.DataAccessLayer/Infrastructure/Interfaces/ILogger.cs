namespace Total.DealerCom.DataAccessLayer.Infrastructure.Interfaces
{
    /// <summary>
    /// Example of loggin interface
    /// </summary>
    public interface ILogger
    {
        void Log(string message);
        void Log(string message, int severity);
    }
}