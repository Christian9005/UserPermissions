using AutoMapper;
using UserPermissions.Application.Permissions.Commands;
using UserPermissions.Application.Permissions.DTOs;
using UserPermissions.Domain.Entities;

namespace UserPermissions.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Permission, PermissionDto>().ReverseMap();
        CreateMap<CreatePermissionCommand, Permission>();
        CreateMap<UpdatePermissionCommand, Permission>();
    }
}
