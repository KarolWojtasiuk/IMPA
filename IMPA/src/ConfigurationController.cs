using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace IMPA
{
    public class DatabaseOptions
    {
        public string DatabaseType { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = "IMPA";
    }

    public static class ConfigurationController
    {
        private static Type GetDatabaseType(string databaseName)
        {
            var dictionary = new Dictionary<string, Type>
            {
                {"MongoDB", typeof(MongoContext)}
            };

            if (dictionary.ContainsKey(databaseName))
            {
                return dictionary[databaseName];
            }

            throw new ArgumentException($"Unsupported database type '{databaseName}'", nameof(databaseName));
        }

        public static IDatabaseContext GetDatabaseContext(IConfiguration configuration)
        {
            var options = new DatabaseOptions();
            configuration.Bind("Database", options);

            var databaseType = GetDatabaseType(options.DatabaseType);

            if (Activator.CreateInstance(databaseType, options.ConnectionString, options.DatabaseName) is not IDatabaseContext context)
            {
                throw new Exception($"Failed to create database context({options.DatabaseType})");
            }

            return context;
        }
    }
}
