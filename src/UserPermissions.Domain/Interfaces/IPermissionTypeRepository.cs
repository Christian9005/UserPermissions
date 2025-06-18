using UserPermissions.Domain.Entities;

namespace UserPermissions.Domain.Interfaces;

public interface IPermissionTypeRepository : IGenericRepository<PermissionType>
{
    Task<List<PermissionType>> GetAllAsync();
}
