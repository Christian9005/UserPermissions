using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserPermissions.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionTypes_PermissionTypes_PermissionTypeId",
                table: "PermissionTypes");

            migrationBuilder.DropIndex(
                name: "IX_PermissionTypes_PermissionTypeId",
                table: "PermissionTypes");

            migrationBuilder.DropColumn(
                name: "PermissionTypeId",
                table: "PermissionTypes");

            migrationBuilder.AddColumn<int>(
                name: "PermissionTypeId1",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionTypeId1",
                table: "Permissions",
                column: "PermissionTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionTypes_PermissionTypeId1",
                table: "Permissions",
                column: "PermissionTypeId1",
                principalTable: "PermissionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionTypes_PermissionTypeId1",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionTypeId1",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionTypeId1",
                table: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "PermissionTypeId",
                table: "PermissionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTypes_PermissionTypeId",
                table: "PermissionTypes",
                column: "PermissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionTypes_PermissionTypes_PermissionTypeId",
                table: "PermissionTypes",
                column: "PermissionTypeId",
                principalTable: "PermissionTypes",
                principalColumn: "Id");
        }
    }
}
