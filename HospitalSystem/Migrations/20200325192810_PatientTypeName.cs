using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalSystem.Migrations
{
    public partial class PatientTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "PatientTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                table: "PatientReservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicName",
                table: "PatientReservations");

            migrationBuilder.AlterColumn<int>(
                name: "name",
                table: "PatientTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
