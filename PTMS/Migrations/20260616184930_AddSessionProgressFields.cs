using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTMS.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionProgressFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ActualValue",
                table: "Sessions",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TargetValue",
                table: "Sessions",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualValue",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TargetValue",
                table: "Sessions");
        }
    }
}
