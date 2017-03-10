
using System.Collections.Generic;
using Services.DataAccess;
using Services.DTO;
using Services.Facade.Interfaces;

namespace Services.Facade
{
    public class LogFacade : ILogFacade
    {
        public IEnumerable<LogEntry> Search(LogEntry log)
        {
            return LogDao.Search(log);
        }

        public IEnumerable<LogEntry> LoginSearch(LogEntry log)
        {
            return LogDao.LoginSearch(log);
        }
    }
}
