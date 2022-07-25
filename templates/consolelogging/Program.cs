using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;



namespace consolelogging
{
    class Program
    {
        static void Main(string[] args)
        {
            Diagnostic.Logger.LogInformation("Console with Logging and App Settings!");

            var appConfig = LoadAppSettings();

            if (appConfig == null)
            {
                Diagnostic.Logger.LogCritical("Missing or invalid appsettings.json...exiting");
                return;
            }

            Diagnostic.Logger.LogInformation("AppSettings loaded.");

            var configValue = appConfig["configValue"];
            Diagnostic.Logger.LogInformation("Retrieved config value: [{0}]", configValue);
        }

        static IConfigurationRoot LoadAppSettings()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var appConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            return appConfig;
        }
    }

}
