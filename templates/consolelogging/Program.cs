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
            Console.WriteLine("Console with Logging and App Settings!");

            var appConfig = LoadAppSettings();

            if (appConfig == null)
            {
                Console.WriteLine("Missing or invalid appsettings.json...exiting");
                return;
            }

            var svcProvider = new ServiceCollection()
                .AddLogging(b => b.AddConsole())
                .AddSingleton<IConfiguration>(appConfig)
                //.AddSingleton<IFooService, FooService>()  // Add in your svcs here
                .BuildServiceProvider();

            var logger = svcProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogInformation("Config and logging setup");

            // var fooSvc = sp.GetService<IFooService>();   // get your svc and do something with it
            // await fooSvc.DoSomethingAsync();

            var configValue = appConfig["configValue"];
			Console.WriteLine("Got config value: [{0}]",configValue);
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
