using Moq;
using UserPermissions.Application.Permissions.Commands;
using UserPermissions.Domain.Entities;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Tests.Permissions;

public class UpdatePermissionCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();

    [Fact]
    public async Task Handle_ValidRequest_UpdatesPermissionAndReturnsTrue()
    {
        // Arrange
        var existingPermission = new Permission
        {
            Id = 1,
            Name = "Carlos",
            LastName = "Lopez",
            PermissionTypeId = 1,
            PermissionDate = DateTime.UtcNow.AddDays(-5)
        };

        _mockUnitOfWork
            .Setup(u => u.Permissions.GetByIdAsync(1))
            .ReturnsAsync(existingPermission);

        _mockUnitOfWork
            .Setup(u => u.Permissions.Update(It.IsAny<Permission>()));

        _mockUnitOfWork
            .Setup(u => u.SaveChangesAsync())
            .ReturnsAsync(1);

        var command = new UpdatePermissionCommand
        {
            Id = 1,
            Name = "Carlos Modificado",
            LastName = "Lopez Modificado",
            PermissionTypeId = 2,
            PermissionDate = DateTime.UtcNow
        };

        var handler = new UpdatePermissionCommandHandler(_mockUnitOfWork.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
        Assert.Equal(command.Name, existingPermission.Name);
        Assert.Equal(command.LastName, existingPermission.LastName);
        Assert.Equal(command.PermissionTypeId, existingPermission.PermissionTypeId);
    }

    [Fact]
    public async Task Handle_NonExistingPermission_ReturnsFalse()
    {
        // Arrange
        _mockUnitOfWork
            .Setup(u => u.Permissions.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Permission)null);

        var command = new UpdatePermissionCommand
        {
            Id = 99,
            Name = "Inexistente",
            LastName = "Error",
            PermissionTypeId = 1,
            PermissionDate = DateTime.UtcNow
        };

        var handler = new UpdatePermissionCommandHandler(_mockUnitOfWork.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result);
    }
}
