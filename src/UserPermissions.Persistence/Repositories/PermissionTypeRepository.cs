using Microsoft.EntityFrameworkCore;
using UserPermissions.Domain.Entities;
using UserPermissions.Domain.Interfaces;
using UserPermissions.Persistence.Context;

namespace UserPermissions.Persistence.Repositories;

public class PermissionTypeRepository : GenericRepository<PermissionType>, IPermissionTypeRepository
{
    private readonly AppDbContext _context;

    public PermissionTypeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<PermissionType>> GetAllAsync()
    {
        return await _context.PermissionTypes.ToListAsync();
    }
}
