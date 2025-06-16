using MediatR;

namespace UserPermissions.Application.Permissions.Commands;

public class CreatePermissionCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int PermissionTypeId { get; set; }
    public DateTime PermissionDate { get; set; }
}
