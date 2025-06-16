using AutoMapper;
using MediatR;
using UserPermissions.Domain.Entities;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Application.Permissions.Commands;

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = _mapper.Map<Permission>(request);

        await _unitOfWork.Permissions.AddAsync(permission);
        await _unitOfWork.SaveChangesAsync();

        return permission.Id;
    }
}
