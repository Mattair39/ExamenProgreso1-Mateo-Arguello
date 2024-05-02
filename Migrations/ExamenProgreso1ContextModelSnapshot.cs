﻿// <auto-generated />
using System;
using ExamenProgreso1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamenProgreso1.Migrations
{
    [DbContext(typeof(ExamenProgreso1Context))]
    partial class ExamenProgreso1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamenProgreso1.Models.Carrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("campus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre_Carrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numero_semestres")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("ExamenProgreso1.Models.MArguello", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<bool>("esEcuatoriano")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<double>("peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.ToTable("MArguello");
                });

            modelBuilder.Entity("ExamenProgreso1.Models.MArguello", b =>
                {
                    b.HasOne("ExamenProgreso1.Models.Carrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");
                });
#pragma warning restore 612, 618
        }
    }
}