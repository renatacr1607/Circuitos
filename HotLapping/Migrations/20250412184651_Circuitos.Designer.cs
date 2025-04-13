﻿// <auto-generated />
using System;
using Circuitos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Circuitos.Migrations
{
    [DbContext(typeof(CircuitosContext))]
    [Migration("20250412184651_Circuitos")]
    partial class Circuitos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Circuitos.Models.Carro", b =>
                {
                    b.Property<int>("CarroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarroID"));

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<int>("Potencia")
                        .HasColumnType("int");

                    b.Property<string>("Tracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarroID");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("Circuitos.Models.Circuito", b =>
                {
                    b.Property<int>("CircuitoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CircuitoID"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCurvas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recorde")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordeCarro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordePiloto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CircuitoID");

                    b.ToTable("Circuitos");
                });

            modelBuilder.Entity("Circuitos.Models.Volta", b =>
                {
                    b.Property<int>("VoltaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoltaID"));

                    b.Property<int>("CarroID")
                        .HasColumnType("int");

                    b.Property<int>("CircuitoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<double>("Tempo")
                        .HasColumnType("float");

                    b.HasKey("VoltaID");

                    b.HasIndex("CarroID");

                    b.HasIndex("CircuitoID");

                    b.ToTable("Voltas");
                });

            modelBuilder.Entity("Circuitos.Models.Volta", b =>
                {
                    b.HasOne("Circuitos.Models.Carro", "Carro")
                        .WithMany("Voltas")
                        .HasForeignKey("CarroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Circuitos.Models.Circuito", "Circuito")
                        .WithMany("Voltas")
                        .HasForeignKey("CircuitoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Circuito");
                });

            modelBuilder.Entity("Circuitos.Models.Carro", b =>
                {
                    b.Navigation("Voltas");
                });

            modelBuilder.Entity("Circuitos.Models.Circuito", b =>
                {
                    b.Navigation("Voltas");
                });
#pragma warning restore 612, 618
        }
    }
}
