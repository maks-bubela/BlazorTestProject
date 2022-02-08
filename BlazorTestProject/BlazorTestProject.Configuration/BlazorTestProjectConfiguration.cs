using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BlazorTestProject.Configuration
{
    public class BlazorTestProjectConfiguration
    {
        public const string SqlConnectionStringSectionName = "ConnectionStrings:BlazorTestProjectDB";


        public string SqlConnectionString { get; private set; }


        public BlazorTestProjectConfiguration(
            string sqlConnectionString)
        {
            if (string.IsNullOrWhiteSpace(nameof(sqlConnectionString)))
            {
                throw new ArgumentException(nameof(sqlConnectionString));
            }
            SqlConnectionString = sqlConnectionString;
        }

        public static BlazorTestProjectConfiguration CreateFromConfigurations()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            IConfigurationRoot root = configurationBuilder.Build();

            return new BlazorTestProjectConfiguration(
                sqlConnectionString: root.GetSection(SqlConnectionStringSectionName).Value);
        }
    }
}
