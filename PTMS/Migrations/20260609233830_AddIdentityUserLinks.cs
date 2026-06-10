using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTMS.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUserLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Clients",
                newName: "IdentityUserId");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Clients",
                newName: "UserId");
        }
    }
}
