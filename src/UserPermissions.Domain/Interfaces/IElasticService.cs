using UserPermissions.Domain.Entities;

namespace UserPermissions.Domain.Interfaces;

public interface IElasticService
{
    Task IndexPermissionAsync(Permission permission);
}
