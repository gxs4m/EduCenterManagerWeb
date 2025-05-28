using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCenterManagerWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prueba2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Rating",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Rating");
        }
    }
}
