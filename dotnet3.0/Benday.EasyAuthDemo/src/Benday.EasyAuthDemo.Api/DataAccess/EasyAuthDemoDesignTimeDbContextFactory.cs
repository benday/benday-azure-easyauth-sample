using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Benday.EasyAuthDemo.Api.DataAccess;

namespace Benday.Cocktails.Api.DataAccess
{
    public class EasyAuthDemoDesignTimeDbContextFactory :
      IDesignTimeDbContextFactory<EasyAuthDemoDbContext>
    {
        public EasyAuthDemoDbContext Create()
        {
            var environmentName =
               Environment.GetEnvironmentVariable(
                "ASPNETCORE_ENVIRONMENT");

            var basePath = AppContext.BaseDirectory;

            return Create(basePath, environmentName);
        }

        public EasyAuthDemoDbContext CreateDbContext(string[] args)
        {
            return Create(
                Directory.GetCurrentDirectory(),
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }

        private EasyAuthDemoDbContext Create(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString("default");

            if (String.IsNullOrWhiteSpace(connstr) == true)
            {
                throw new InvalidOperationException(
                    "Could not find a connection string named 'default'.");
            }
            else
            {
                return Create(connstr);
            }
        }

        private EasyAuthDemoDbContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                   $"{nameof(connectionString)} is null or empty.",
                   nameof(connectionString));

            var optionsBuilder =
              new DbContextOptionsBuilder<EasyAuthDemoDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new EasyAuthDemoDbContext(optionsBuilder.Options);
        }
    }
}
