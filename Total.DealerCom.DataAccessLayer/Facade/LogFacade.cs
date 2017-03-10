
using System.Collections.Generic;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.Core;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;

namespace Total.DealerCom.DataAccessLayer.Facade
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
