using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace TestTaskSoftwareSolutions.DAL.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", false, true)
                                .Build();

            var connectionString = configuration.GetConnectionString(nameof(RepositoryContext));

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                   .UseNpgsql(connectionString, __options =>
                   {
                       __options.MigrationsAssembly(typeof(RepositoryContext).Assembly.FullName);
                   });

            var context = new RepositoryContext(builder.Options);

            return context;
        }
    }
}
