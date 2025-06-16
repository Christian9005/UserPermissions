using AutoMapper;
using MediatR;
using UserPermissions.Application.Permissions.DTOs;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Application.Permissions.Queries;

public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<PermissionDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _unitOfWork.Permissions.GetAllAsync();
        return _mapper.Map<List<PermissionDto>>(permissions);
    }
}
