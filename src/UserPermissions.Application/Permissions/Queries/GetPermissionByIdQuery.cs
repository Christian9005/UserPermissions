using MediatR;
using UserPermissions.Application.Permissions.DTOs;

namespace UserPermissions.Application.Permissions.Queries;

public record GetPermissionByIdQuery(int Id) : IRequest<PermissionDto>;
