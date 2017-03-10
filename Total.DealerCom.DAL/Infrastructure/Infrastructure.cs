using System;
using Services.Infrastructure.Interfaces;

namespace Services.Infrastructure
{
    public class Infrastructure : IInfrastructure
    {
        private readonly ICache _cache;
        private readonly IConfig _config;
        private readonly int _currentInstanceId;
        private readonly ILogger _logger;

        public Infrastructure(ICache cache, IConfig config, ILogger logger)
        {
            _cache = cache;
            _config = config;
            _logger = logger;
            _currentInstanceId = new Random().Next();
        }

        #region IInfrastructure Members

        public int CurrentInstanceId
        {
            get { return _currentInstanceId; }
        }

        public ICache Cache
        {
            get { return _cache; }
        }

        public ILogger Logger
        {
            get { return _logger; }
        }

        public IConfig Config
        {
            get { return _config; }
        }

        #endregion
    }
}