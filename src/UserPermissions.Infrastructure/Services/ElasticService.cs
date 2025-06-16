using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Logging;
using UserPermissions.Domain.Entities;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Infrastructure.Services;

public class ElasticService : IElasticService
{
    private readonly ElasticsearchClient _client;
    private readonly ILogger<ElasticService> _logger;
    public ElasticService(ElasticsearchClient client, ILogger<ElasticService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task IndexPermissionAsync(Permission permission)
    {
        var response = await _client.IndexAsync(permission, idx => idx.Index("permissions"));

        if (!response.IsValidResponse)
        {
            _logger.LogError("Failed to index permission: {Reason}", response.DebugInformation);
        }
    }
}
