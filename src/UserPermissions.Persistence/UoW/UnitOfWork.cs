using UserPermissions.Domain.Interfaces;
using UserPermissions.Persistence.Context;
using UserPermissions.Persistence.Repositories;

namespace UserPermissions.Persistence.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IPermissionRepository? _permissions;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IPermissionRepository Permissions =>
        _permissions ??= new PermissionRepository(_context);

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    public void Dispose() =>
        _context.Dispose();
}