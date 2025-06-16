namespace UserPermissions.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPermissionRepository Permissions { get; }
    Task<int> SaveChangesAsync();
}
