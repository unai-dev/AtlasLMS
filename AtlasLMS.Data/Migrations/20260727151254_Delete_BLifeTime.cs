using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasLMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Delete_BLifeTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LifeTime",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 14);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LifeTime",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 14,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
