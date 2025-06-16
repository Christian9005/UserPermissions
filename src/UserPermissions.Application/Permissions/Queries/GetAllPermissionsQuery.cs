using MediatR;
using UserPermissions.Application.Permissions.DTOs;

namespace UserPermissions.Application.Permissions.Queries;

public record GetAllPermissionsQuery : IRequest<List<PermissionDto>>;
