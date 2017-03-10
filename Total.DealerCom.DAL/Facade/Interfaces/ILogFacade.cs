
using System.Collections.Generic;
using Services.DTO;

namespace Services.Facade.Interfaces
{
    public interface ILogFacade
    {
        IEnumerable<LogEntry> Search(LogEntry log);
        IEnumerable<LogEntry> LoginSearch(LogEntry log);
        
    }
}
