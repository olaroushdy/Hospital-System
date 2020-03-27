using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalSystem.Migrations
{
    public partial class UpdatePatientHistoy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "PatientHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "PatientHistories");
        }
    }
}
