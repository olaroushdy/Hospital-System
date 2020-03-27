using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalSystem.Migrations
{
    public partial class UpdateAttach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "PatientReservations",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "NationalId",
                table: "PatientReservations",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
