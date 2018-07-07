using System;
using System.Threading.Tasks;
using NuGet.Common;
using NuKeeper.Inspection.Logging;
using LogLevel = NuGet.Common.LogLevel;

namespace NuKeeper.Inspection.NuGetApi
{
    public class NuGetLogger : LoggerBase
    {
        private readonly INuKeeperLogger _logger;

        public NuGetLogger(INuKeeperLogger logger)
        {
            _logger = logger;
        }

        public override void Log(ILogMessage message)
        {
            switch (message.Level)
            {
                case LogLevel.Verbose: _logger.Verbose(message.Message);
                    break;
                case LogLevel.Debug: _logger.Verbose(message.Message);
                    break;
                case LogLevel.Information: _logger.Verbose(message.Message);
                    break;
                case LogLevel.Minimal: _logger.Info(message.Message);
                    break;
                case LogLevel.Warning: _logger.Info(message.Message);
                    break;
                case LogLevel.Error:
                    _logger.Error(message.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override Task LogAsync(ILogMessage message)
        {
            Log(message);
            return Task.CompletedTask;
        }
    }
}