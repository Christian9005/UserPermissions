using MediatR;
using UserPermissions.Application.Permissions.DTOs;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Application.Permissions.Queries;

public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, List<PermissionDto>>
{
    private readonly IPermissionRepository _permissionRepository;

    public GetAllPermissionsQueryHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<List<PermissionDto>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _permissionRepository.GetAllAsync();

        return permissions.Select(p => new PermissionDto
        {
            Id = p.Id,
            Name = p.Name,
            LastName = p.LastName,
            PermissionTypeId = p.PermissionTypeId,
            PermissionDate = p.PermissionDate
        }).ToList();
    }
}
