using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasLMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class LifeTimeBColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LifeTime",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 14);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LifeTime",
                table: "Bookings");
        }
    }
}
