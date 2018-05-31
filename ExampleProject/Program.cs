using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExampleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

			/*
			    •	Sätta upp en projekt.
				•	Lägga in Kestrel. 
				•	Konfigurera loggning.
				•	Konfigurera DI.
				•	Skapa en DbContext med EF Core.
				•	DI med EF Core.
				•	Migreringar med EF Core.
				•	Lägga in HTML och lite ny Razor-syntax.
				•	Några andra tredjeparts-komponenter och hur de fungerar i .NET Core:
					o	Automapper
					o	NLog
				•	Var krävs på servern?	
			*/
		}

		public static IWebHost BuildWebHost(string[] args) =>
				new WebHostBuilder()
				//WebHost.CreateDefaultBuilder(args) // Sätter själv upp loggning.
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
	            .UseKestrel() // Behövs inte.
				.ConfigureLogging((hostingContext, logging) =>
	            {
					https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.0&tabs=aspnetcore2x
					logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
		            logging.AddConsole();
		            logging.AddDebug();
	            })

				.Build();
    }
}
