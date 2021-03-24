using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTaskSoftwareSolutions.DAL.Context;

namespace TestTaskSoftwareSolutions.DAL.Boostrap
{
    public static class DbConfigurations
    {
        /// <summary>
        /// Подключение DbContext.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(RepositoryContext).Assembly.FullName))
            );
        }
    }
}
