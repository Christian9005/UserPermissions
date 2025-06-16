using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Application.Permissions.Commands;

public class UpdatePermissionCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePermissionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var existing = await _unitOfWork.Permissions.GetByIdAsync(request.Id);
        if (existing is null)
            return false;

        existing.Name = request.Name;
        existing.LastName = request.LastName;
        existing.PermissionTypeId = request.PermissionTypeId;
        existing.PermissionDate = request.PermissionDate;

        _unitOfWork.Permissions.Update(existing);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
