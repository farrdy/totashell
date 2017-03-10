namespace Total.DealerCom.DataAccessLayer.Infrastructure.Interfaces
{
    public interface IInfrastructure
    {
        int CurrentInstanceId { get; }
        ICache Cache { get; }
        ILogger Logger { get; }
        IConfig Config { get; }
    }
}