using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasLMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class LimitOfBooksPROP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LimitOfBooks",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitOfBooks",
                table: "Locations");
        }
    }
}
