﻿// <auto-generated />
using System;
using HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalDatabase.Data.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalDatabase.Data.Models.Diagnose", b =>
                {
                    b.Property<int>("DiagnoseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<string>("Name");

                    b.Property<int>("PatientId");

                    b.HasKey("DiagnoseId");

                    b.HasIndex("PatientId");

                    b.ToTable("Diagnose");
                });

            modelBuilder.Entity("HospitalDatabase.Data.Models.Medicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("MedicamentId");

                    b.ToTable("Medicament");
                });

            modelBuilder.Entity("HospitalDatabase.Data.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<bool>("HasInsurance");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalDatabase.Data.Models.PatientMedicament", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicamentId");

                    b.Property<int?>("PatientId1");

                    b.HasKey("PatientId");

                    b.HasIndex("MedicamentId");

                    b.HasIndex("PatientId1");

                    b.ToTable("PatientMedicament");
                });

            modelBuilder.Entity("HospitalDatabase.Data.Models.Visitation", b =>
                {
                    b.Property<int>("VisitationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<DateTime>("Date");

                    b.Property<int>("PatientId");

                    b.HasKey("VisitationId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visitations");
                });

            modelBuilder.Entity("HospitalDatabase.Data.Models.Diagnose", b =>
                {
                    b.HasOne("HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Diagnoses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HospitalDatabase.Data.Models.PatientMedicament", b =>
                {
                    b.HasOne("HospitalDatabase.Data.Models.Medicament", "Medicament")
                        .WithMany("Prescriptions")
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientId1");
                });

            modelBuilder.Entity("HospitalDatabase.Data.Models.Visitation", b =>
                {
                    b.HasOne("HospitalDatabase.Data.Models.Patient", "Patient")
                        .WithMany("Visitations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
