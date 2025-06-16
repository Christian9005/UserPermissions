using Microsoft.EntityFrameworkCore;
using UserPermissions.Domain.Entities;
using UserPermissions.Domain.Interfaces;
using UserPermissions.Persistence.Context;

namespace UserPermissions.Persistence.Repositories;

public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    private readonly AppDbContext _context;

    public PermissionRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Permission>> GetAllAsync()
    {
        return await _context.Permissions
            .Include(p => p.PermissionType)
            .ToListAsync();
    }
}
