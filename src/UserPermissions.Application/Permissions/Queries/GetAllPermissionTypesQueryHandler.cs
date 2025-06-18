using MediatR;
using UserPermissions.Application.Permissions.DTOs;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Application.Permissions.Queries;

public class GetAllPermissionTypesQueryHandler : IRequestHandler<GetAllPermissionTypesQuery, List<PermissionTypeDto>>
{
    private readonly IPermissionTypeRepository _permissionTypeRepository;

    public GetAllPermissionTypesQueryHandler(IPermissionTypeRepository permissionTypeRepository)
    {
        _permissionTypeRepository = permissionTypeRepository;
    }

    public async Task<List<PermissionTypeDto>> Handle(GetAllPermissionTypesQuery request, CancellationToken cancellationToken)
    {
        var types = await _permissionTypeRepository.GetAllAsync();

        return types.Select(t => new PermissionTypeDto
        {
            Id = t.Id,
            Description = t.Description
        }).ToList();
    }
}
