using System;
using System.IO;
using Microsoft.Extensions.Configuration;

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
