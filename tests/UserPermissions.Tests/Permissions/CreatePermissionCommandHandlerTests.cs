using AutoMapper;
using Moq;
using UserPermissions.Application.Permissions.Commands;
using UserPermissions.Domain.Entities;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Tests.Permissions;

public class CreatePermissionCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
    private readonly Mock<IMapper> _mockMapper = new();

    [Fact]
    public async Task Handle_ValidCommand_ReturnsNewId()
    {
        // Arrange
        var command = new CreatePermissionCommand
        {
            Name = "Juan",
            LastName = "Pérez",
            PermissionTypeId = 1,
            PermissionDate = DateTime.UtcNow
        };

        var mappedPermission = new Permission
        {
            Id = 123,
            Name = "Juan",
            LastName = "Pérez",
            PermissionTypeId = 1,
            PermissionDate = command.PermissionDate
        };

        _mockMapper
            .Setup(m => m.Map<Permission>(It.IsAny<CreatePermissionCommand>()))
            .Returns(mappedPermission);

        _mockUnitOfWork
            .Setup(uow => uow.Permissions.AddAsync(It.IsAny<Permission>()))
            .Returns(Task.CompletedTask);

        _mockUnitOfWork
            .Setup(uow => uow.SaveChangesAsync())
            .ReturnsAsync(1);

        var handler = new CreatePermissionCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(123, result);
    }
}
