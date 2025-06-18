using MediatR;
using UserPermissions.Application.Permissions.DTOs;

namespace UserPermissions.Application.Permissions.Queries;

public record GetAllPermissionTypesQuery : IRequest<List<PermissionTypeDto>>;
