using MediatR;
using UserPermissions.Application.Permissions.DTOs;

namespace UserPermissions.Application.Permissions.Queries;

public class GetPermissionsQuery : IRequest<List<PermissionDto>>
{
}
