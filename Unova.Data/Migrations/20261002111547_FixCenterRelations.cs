using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unova.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCenterRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_Copies_asp_Centers_CenterID",
                table: "asp_Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Copies_asp_Locations_LocationID",
                table: "asp_Copies");

            migrationBuilder.DropIndex(
                name: "IX_asp_Copies_CenterID",
                table: "asp_Copies");

            migrationBuilder.DropColumn(
                name: "CenterID",
                table: "asp_Copies");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "asp_Copies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Copies_asp_Locations_LocationID",
                table: "asp_Copies",
                column: "LocationID",
                principalTable: "asp_Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_Copies_asp_Locations_LocationID",
                table: "asp_Copies");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "asp_Copies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CenterID",
                table: "asp_Copies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_asp_Copies_CenterID",
                table: "asp_Copies",
                column: "CenterID");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Copies_asp_Centers_CenterID",
                table: "asp_Copies",
                column: "CenterID",
                principalTable: "asp_Centers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Copies_asp_Locations_LocationID",
                table: "asp_Copies",
                column: "LocationID",
                principalTable: "asp_Locations",
                principalColumn: "ID");
        }
    }
}
