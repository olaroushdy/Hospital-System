using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalSystem.Migrations
{
    public partial class UpdateGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "PatientTypes",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "PatientReservations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PatientTypes",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "PatientReservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
