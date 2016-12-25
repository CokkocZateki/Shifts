﻿using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using DbUp;

namespace Shifts.Drivers.Migrations
{
    public class Program
    {
        private static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? ConfigurationManager.ConnectionStrings["shiftDriversDb"].ConnectionString;
                //"Server=(local)\\SqlExpress; Database="+ConfigurationManager.AppSettings["db-name"]+"; Trusted_connection=true";

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}