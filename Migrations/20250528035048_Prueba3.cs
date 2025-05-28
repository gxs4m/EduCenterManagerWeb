using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCenterManagerWeb.Migrations
{
    /// <inheritdoc />
    public partial class Prueba3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Course",
                newName: "NombreCurso");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Course",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCurso",
                table: "Course",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Course",
                newName: "Description");
        }
    }
}
