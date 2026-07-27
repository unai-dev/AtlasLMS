using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlasLMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_ELoanStatusCOL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                 name: "Status",
                 table: "Loans",
                 type: "int",
                 nullable: false,
                 defaultValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LifeTime",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
