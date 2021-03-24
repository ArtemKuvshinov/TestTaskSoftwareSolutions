using Microsoft.Extensions.DependencyInjection;
using TestTaskSoftwareSolutions.DAL.Domain;
using TestTaskSoftwareSolutions.Model.DTO;
using TestTaskSoftwareSolutions.Services.Interfaces;
using TestTaskSoftwareSolutions.Services.Services;

namespace TestTaskSoftwareSolutions.Services.Boostrap
{
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Конфигурация сервисов.
        /// Это метод расширения из класса Startup
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}
