

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace QuickProFixer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ensure the Logs folder exists
            var logsPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(logsPath))
            {
                Directory.CreateDirectory(logsPath);
            }

            // Build the host
            var host = CreateHostBuilder(args).Build();

            // Access the configuration to read the connection string
            var config = host.Services.GetService(typeof(IConfiguration)) as IConfiguration;
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Access the logger
            var logger = host.Services.GetService(typeof(ILogger<Program>)) as ILogger<Program>;
            if (logger != null)
            {
                logger.LogInformation("Application has started! Logging to file is enabled.");
                logger.LogInformation($"Current Environment: {(host.Services.GetService(typeof(IHostEnvironment)) is IHostEnvironment env ? env.EnvironmentName : "Unknown")}");
                logger.LogInformation($"Connection String: {connectionString ?? "Connection string is not set or cannot be found."}");
            }

            // Run the application
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;

                    // Log environment for testing
                    Console.WriteLine($"Environment: {env.EnvironmentName}");

                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureLogging(logging =>
                {
                    // Clear default logging providers
                    logging.ClearProviders();

                    // Add console logging
                    logging.AddConsole();

                    // Add file logging
                    logging.AddFile("Logs/app_log.txt");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
