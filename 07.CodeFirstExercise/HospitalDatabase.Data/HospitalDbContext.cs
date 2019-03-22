namespace HospitalDatabase.Data
{
    using HospitalDatabase.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnose> Diagnose { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<PatientMedicament> PatientMedicament { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Hospital;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .HasKey(x => x.PatientId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(x => x.Visitations)
                .WithOne(x => x.Patient);

            modelBuilder
               .Entity<Patient>()
               .HasMany(x => x.Prescriptions)
               .WithOne(x => x.Patient);

            modelBuilder
              .Entity<Patient>()
              .HasMany(x => x.Diagnoses)
              .WithOne(x => x.Patient);

            modelBuilder
                .Entity<Patient>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(x => x.Email)
                .HasMaxLength(250);
        }
    }
}
