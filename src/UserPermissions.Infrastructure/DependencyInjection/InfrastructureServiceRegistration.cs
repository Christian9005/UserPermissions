using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserPermissions.Domain.Interfaces;
using UserPermissions.Infrastructure.Services;

namespace UserPermissions.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new ElasticsearchClientSettings(new Uri(configuration["Elasticsearch:Uri"]!))
                            .DefaultIndex("permissions");

        var client = new ElasticsearchClient(settings);

        services.AddSingleton(client);
        services.AddScoped<IElasticService, ElasticService>();

        return services;
    }
}
