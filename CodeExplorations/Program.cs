using NLog;

namespace CodeExplorations
{
  class Program
  {
    static void Main(string[] args){
      Logger logger = LogManager.GetCurrentClassLogger();

      int k = 42;
      int l = 100;

      logger.Trace($"Sample trace message, k={k}, l={l}");
      logger.Debug($"Sample debug message, k={k}, l={l}");
      logger.Info($"Sample informational message, k={k}, l={l}");
      logger.Warn($"Sample warning message, k={k}, l={l}");
      logger.Error($"Sample error message, k={k}, l={l}");
      logger.Fatal($"Sample fatal error message, k={k}, l={l}");
      logger.Log(LogLevel.Info, $"Sample informational message, k={k}, l={l}");
    }
  }
}