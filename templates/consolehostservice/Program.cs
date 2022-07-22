using System;
using System.IO;
using Microsoft.Extensions.Configuration;

/*******************************************************************************
** This sample utilises the LoggerMessage pattern for high performance logging
** See: https://docs.microsoft.com/en-us/dotnet/core/extensions/high-performance-logging
**
*******************************************************************************/
namespace consoleappsettings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console with App Settings Using LoggerMessage Pattern");

            Startup.Initialise();
        }
    }

}
