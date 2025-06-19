using Moq;
using UserPermissions.Application.Permissions.Queries;
using UserPermissions.Domain.Entities;
using UserPermissions.Domain.Interfaces;

namespace UserPermissions.Tests.Permissions;

public class GetAllPermissionsQueryHandlerTests
{
    private readonly Mock<IPermissionRepository> _mockRepository = new();

    [Fact]
    public async Task Handle_ReturnsMappedPermissionDtoList()
    {
        // Arrange
        var fakePermissions = new List<Permission>
            {
                new Permission { Id = 1, Name = "Ana", LastName = "Lopez", PermissionTypeId = 1, PermissionDate = DateTime.UtcNow },
                new Permission { Id = 2, Name = "Luis", LastName = "Martinez", PermissionTypeId = 2, PermissionDate = DateTime.UtcNow }
            };

        _mockRepository
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(fakePermissions);

        var handler = new GetAllPermissionsQueryHandler(_mockRepository.Object);
        var query = new GetAllPermissionsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Ana", result[0].Name);
        Assert.Equal("Luis", result[1].Name);
    }
}
