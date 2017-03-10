using Services.Infrastructure.Interfaces;

namespace Services.Infrastructure
{
    public class LoggerNull : ILogger
    {
        private readonly IConfig _config;

        public LoggerNull(IConfig config)
        {
            _config = config;
        }

        #region ILogger Members

        public void Log(string message)
        {
            string x = GetFileName();
        }

        public void Log(string message, int severity)
        {
            string x = GetFileName();
            ;
        }

        #endregion

        private string GetFileName()
        {
            string fileName = _config.LogFile;
            string filePath = _config.LogFilePath;
            return filePath + fileName;
        }
    }
}