
using System.Collections.Generic;
using Total.DealerCom.Core;

namespace Total.DealerCom.DataAccessLayer.Facade.Interfaces
{
    public interface ILogFacade
    {
        IEnumerable<LogEntry> Search(LogEntry log);
        IEnumerable<LogEntry> LoginSearch(LogEntry log);
        
    }
}
