using HospitalSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem
{
    public class HospitalContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<EmployeeTransaction> EmployeeTransactions { get; set; }
        public DbSet<PatientReservation> PatientReservations { get; set; }
        public DbSet<PatientType> PatientTypes { get; set; }

        public DbSet<PatientHistory> PatientHistories { get; set; }
        public HospitalContext(DbContextOptions<HospitalContext> options)
       : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>()
                .HasKey(bc => new { bc.EmployeeId, bc.PatientTypeId });

            modelBuilder.Entity<EmployeeRole>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeRoles)
                .HasForeignKey(bc => bc.EmployeeId);

            modelBuilder.Entity<EmployeeRole>()
                .HasOne(bc => bc.PatientType)
                .WithMany(c => c.EmployeeRoles)
                .HasForeignKey(bc => bc.PatientTypeId);
            base.OnModelCreating(modelBuilder);
        }


    }
}
