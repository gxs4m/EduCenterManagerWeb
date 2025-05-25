using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCenterManagerWeb.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_TeachersIdProfesor",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Course_CoursesId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Student_StudentsIdEstudiante",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Course_CoursesId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Rating_StudentsIdEstudiante",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Course_TeachersIdProfesor",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IdCurso",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IdCurso",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IdCurso",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "StudentsIdEstudiante",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "TeachersIdProfesor",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "IdEstudiante",
                table: "Rating",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Course",
                newName: "TeachersId");

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_StudentsId",
                table: "Rating",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeachersId",
                table: "Course",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_TeachersId",
                table: "Course",
                column: "TeachersId",
                principalTable: "Teacher",
                principalColumn: "IdProfesor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Course_CoursesId",
                table: "Rating",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Student_StudentsId",
                table: "Rating",
                column: "StudentsId",
                principalTable: "Student",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Course_CoursesId",
                table: "Schedule",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_TeachersId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Course_CoursesId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Student_StudentsId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Course_CoursesId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Rating_StudentsId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Course_TeachersId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "Rating",
                newName: "IdEstudiante");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "Course",
                newName: "TeacherId");

            migrationBuilder.AddColumn<int>(
                name: "IdCurso",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCurso",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "Rating",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCurso",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsIdEstudiante",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeachersIdProfesor",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_StudentsIdEstudiante",
                table: "Rating",
                column: "StudentsIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeachersIdProfesor",
                table: "Course",
                column: "TeachersIdProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_TeachersIdProfesor",
                table: "Course",
                column: "TeachersIdProfesor",
                principalTable: "Teacher",
                principalColumn: "IdProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Course_CoursesId",
                table: "Rating",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Student_IdEstudiante",
                table: "Rating",
                column: "StudentsIdEstudiante",
                principalTable: "Student",
                principalColumn: "IdEstudiante");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Course_CoursesId",
                table: "Schedule",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id");
        }
    }
}
