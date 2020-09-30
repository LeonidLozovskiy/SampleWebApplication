using Microsoft.Extensions.DependencyInjection;
using Sample.Repository.Abstractions;
using Sample.Repository.Repositories;
using Sample.Services.Contract.Abstractions;
using SampleServices.Abstractions;

namespace Sample.Configuration
{
    public static class ConfigurationService
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            services.AddTransient<ISampleRepository, SampleRepository>();
            services.AddTransient<ISampleService, SampleService>();

            return services;
        }
    }
}
