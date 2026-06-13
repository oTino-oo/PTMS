using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTMS.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanTypeToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanType",
                table: "Bookings");
        }
    }
}
