using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    LocalIp = table.Column<int>(nullable: false),
                    Date = table.Column<int>(nullable: false),
                    IsSuccess = table.Column<int>(nullable: false),
                    IsOpen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    DiseaseType = table.Column<string>(nullable: true),
                    IsChronic = table.Column<bool>(nullable: false),
                    IsHereditany = table.Column<bool>(nullable: false),
                    IsInfection = table.Column<bool>(nullable: false),
                    EnteranceDate = table.Column<DateTime>(nullable: false),
                    LeaveDate = table.Column<DateTime>(nullable: false),
                    Diagnose = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientTypes",
                columns: table => new
                {
                    PatientTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTypes", x => x.PatientTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    PatientTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => new { x.EmployeeId, x.PatientTypeId });
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_PatientTypes_PatientTypeId",
                        column: x => x.PatientTypeId,
                        principalTable: "PatientTypes",
                        principalColumn: "PatientTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientReservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FildeId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    NationalId = table.Column<byte[]>(nullable: true),
                    PatientTypeId = table.Column<int>(nullable: false),
                    HomeNumber = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PatientHistoryId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientReservations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientReservations_PatientHistories_PatientHistoryId",
                        column: x => x.PatientHistoryId,
                        principalTable: "PatientHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientReservations_PatientTypes_PatientTypeId",
                        column: x => x.PatientTypeId,
                        principalTable: "PatientTypes",
                        principalColumn: "PatientTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_PatientTypeId",
                table: "EmployeeRoles",
                column: "PatientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReservations_EmployeeId",
                table: "PatientReservations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReservations_PatientHistoryId",
                table: "PatientReservations",
                column: "PatientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReservations_PatientTypeId",
                table: "PatientReservations",
                column: "PatientTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "EmployeeTransactions");

            migrationBuilder.DropTable(
                name: "PatientReservations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PatientHistories");

            migrationBuilder.DropTable(
                name: "PatientTypes");
        }
    }
}
