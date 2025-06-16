using UserPermissions.Domain.Entities;

namespace UserPermissions.Domain.Interfaces;

public interface IPermissionRepository
{
    Task<Permission?> GetByIdAsync(int id);
    Task<List<Permission>> GetAllAsync();
    Task AddAsync(Permission permission);
    void Update(Permission permission);
}
