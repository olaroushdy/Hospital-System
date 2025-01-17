﻿// <auto-generated />
using System;
using HospitalSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalSystem.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20200325174049_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalSystem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HospitalSystem.Models.EmployeeRole", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PatientTypeId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "PatientTypeId");

                    b.HasIndex("PatientTypeId");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("HospitalSystem.Models.EmployeeTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("IsOpen")
                        .HasColumnType("int");

                    b.Property<int>("IsSuccess")
                        .HasColumnType("int");

                    b.Property<int>("LocalIp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTransactions");
                });

            modelBuilder.Entity("HospitalSystem.Models.PatientHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiseaseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnteranceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsChronic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHereditany")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInfection")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PatientHistories");
                });

            modelBuilder.Entity("HospitalSystem.Models.PatientReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FildeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HomeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("NationalId")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("PatientTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PatientHistoryId");

                    b.HasIndex("PatientTypeId");

                    b.ToTable("PatientReservations");
                });

            modelBuilder.Entity("HospitalSystem.Models.PatientType", b =>
                {
                    b.Property<int>("PatientTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("name")
                        .HasColumnType("int");

                    b.HasKey("PatientTypeId");

                    b.ToTable("PatientTypes");
                });

            modelBuilder.Entity("HospitalSystem.Models.EmployeeRole", b =>
                {
                    b.HasOne("HospitalSystem.Models.Employee", "Employee")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalSystem.Models.PatientType", "PatientType")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("PatientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalSystem.Models.PatientReservation", b =>
                {
                    b.HasOne("HospitalSystem.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalSystem.Models.PatientHistory", "PatientHistory")
                        .WithMany()
                        .HasForeignKey("PatientHistoryId");

                    b.HasOne("HospitalSystem.Models.PatientType", "PatientType")
                        .WithMany()
                        .HasForeignKey("PatientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
