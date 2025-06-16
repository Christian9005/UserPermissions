using MediatR;
using UserPermissions.Application.Permissions.DTOs;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Application.Permissions.Queries;

public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, PermissionDto>
{
    private readonly IPermissionRepository _permissionRepository;

    public GetPermissionByIdQueryHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<PermissionDto> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository.GetByIdAsync(request.Id);

        if (permission == null)
            throw new KeyNotFoundException($"Permission with ID {request.Id} not found.");

        return new PermissionDto
        {
            Id = permission.Id,
            Name = permission.Name,
            LastName = permission.LastName,
            PermissionTypeId = permission.PermissionTypeId,
            PermissionDate = permission.PermissionDate
        };
    }
}
