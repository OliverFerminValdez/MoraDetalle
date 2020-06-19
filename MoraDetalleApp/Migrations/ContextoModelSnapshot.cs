﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoraDetalleApp.DAL;

namespace MoraDetalleApp.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("MoraDetalleApp.Models.MoraDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoraId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("MoraId");

                    b.ToTable("MoraDetalle");
                });

            modelBuilder.Entity("MoraDetalleApp.Models.Moras", b =>
                {
                    b.Property<int>("MoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("MoraId");

                    b.ToTable("Moras");
                });

            modelBuilder.Entity("MoraDetalleApp.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<string>("Persona")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("MoraDetalleApp.Models.MoraDetalle", b =>
                {
                    b.HasOne("MoraDetalleApp.Models.Prestamos", null)
                        .WithMany("MoraDetalles")
                        .HasForeignKey("MoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
