using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace consolelogging
{
    public static class Diagnostic
    {
        public static ILoggerFactory _logFactory;

        static Diagnostic()
        {

            _logFactory = LoggerFactory.Create(builder =>
                {
                    builder.ClearProviders();  // Clear Microsoft's default providers (like eventlogs and others)
                    builder
                        .AddConsole()
                        .AddSimpleConsole(options =>
                        {
                            options.TimestampFormat = "hh:mm:ss";
                            options.IncludeScopes = true;
                            options.UseUtcTimestamp = false;
                        })
                        .AddDebug();
                });

        }
        public static ILogger Logger => _logFactory.CreateLogger<Program>();
    }
}