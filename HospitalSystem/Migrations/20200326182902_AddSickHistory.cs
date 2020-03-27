using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalSystem.Migrations
{
    public partial class AddSickHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSickHistory",
                table: "PatientReservations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSickHistory",
                table: "PatientReservations");
        }
    }
}
