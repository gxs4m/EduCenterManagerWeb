using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCenterManagerWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.IdProfesor);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    TeachersIdProfesor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_TeachersIdProfesor",
                        column: x => x.TeachersIdProfesor,
                        principalTable: "Teacher",
                        principalColumn: "IdProfesor");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: true),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_Schedule_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Student_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    IdCalificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    StudentsIdEstudiante = table.Column<int>(type: "int", nullable: true),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.IdCalificacion);
                    table.ForeignKey(
                        name: "FK_Rating_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Student_StudentsIdEstudiante",
                        column: x => x.StudentsIdEstudiante,
                        principalTable: "Student",
                        principalColumn: "IdEstudiante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeachersIdProfesor",
                table: "Course",
                column: "TeachersIdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CoursesId",
                table: "Rating",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_StudentsIdEstudiante",
                table: "Rating",
                column: "StudentsIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_CoursesId",
                table: "Schedule",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CoursesId",
                table: "Student",
                column: "CoursesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
