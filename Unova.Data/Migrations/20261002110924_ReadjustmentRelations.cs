using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unova.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReadjustmentRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_Books_asp_Centers_CenterID",
                table: "asp_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Books_asp_Locations_LocationID",
                table: "asp_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_asp_Languages_LanguageID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_asp_Books_CenterID",
                table: "asp_Books");

            migrationBuilder.DropIndex(
                name: "IX_asp_Books_LocationID",
                table: "asp_Books");

            migrationBuilder.DropColumn(
                name: "CenterID",
                table: "asp_Books");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "asp_Books");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CenterID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CenterID",
                table: "asp_Copies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "asp_Copies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CenterID",
                table: "AspNetUsers",
                column: "CenterID");

            migrationBuilder.CreateIndex(
                name: "IX_asp_Copies_CenterID",
                table: "asp_Copies",
                column: "CenterID");

            migrationBuilder.CreateIndex(
                name: "IX_asp_Copies_LocationID",
                table: "asp_Copies",
                column: "LocationID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_asp_Centers_CenterID",
                table: "AspNetUsers",
                column: "CenterID",
                principalTable: "asp_Centers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_asp_Languages_LanguageID",
                table: "AspNetUsers",
                column: "LanguageID",
                principalTable: "asp_Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_asp_Copies_asp_Centers_CenterID",
                table: "asp_Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_asp_Copies_asp_Locations_LocationID",
                table: "asp_Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_asp_Centers_CenterID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_asp_Languages_LanguageID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CenterID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_asp_Copies_CenterID",
                table: "asp_Copies");

            migrationBuilder.DropIndex(
                name: "IX_asp_Copies_LocationID",
                table: "asp_Copies");

            migrationBuilder.DropColumn(
                name: "CenterID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CenterID",
                table: "asp_Copies");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "asp_Copies");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CenterID",
                table: "asp_Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "asp_Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 7, 18, 3, 987, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 7, 18, 3, 988, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 7, 18, 3, 988, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "asp_Languages",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 2, 7, 18, 3, 988, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.CreateIndex(
                name: "IX_asp_Books_CenterID",
                table: "asp_Books",
                column: "CenterID");

            migrationBuilder.CreateIndex(
                name: "IX_asp_Books_LocationID",
                table: "asp_Books",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Books_asp_Centers_CenterID",
                table: "asp_Books",
                column: "CenterID",
                principalTable: "asp_Centers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_asp_Books_asp_Locations_LocationID",
                table: "asp_Books",
                column: "LocationID",
                principalTable: "asp_Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_asp_Languages_LanguageID",
                table: "AspNetUsers",
                column: "LanguageID",
                principalTable: "asp_Languages",
                principalColumn: "ID");
        }
    }
}
