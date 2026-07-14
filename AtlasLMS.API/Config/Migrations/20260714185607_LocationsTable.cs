using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtlasLMS.API.Migrations
{
    /// <inheritdoc />
    public partial class LocationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aisle = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Column = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_LocationID",
                table: "Books",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Locations_LocationID",
                table: "Books",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Locations_LocationID",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Books_LocationID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 14, 7, 22, 47, 535, DateTimeKind.Local).AddTicks(4352), "Ficción", null },
                    { 2, new DateTime(2026, 7, 14, 7, 22, 47, 536, DateTimeKind.Local).AddTicks(8421), "Ciencia y Tecnología", null },
                    { 3, new DateTime(2026, 7, 14, 7, 22, 47, 536, DateTimeKind.Local).AddTicks(8438), "Historia y Biografías", null },
                    { 4, new DateTime(2026, 7, 14, 7, 22, 47, 536, DateTimeKind.Local).AddTicks(8440), "Desarrollo Personal", null }
                });
        }
    }
}
