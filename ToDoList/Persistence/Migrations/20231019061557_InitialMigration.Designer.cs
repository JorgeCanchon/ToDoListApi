﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231019061557_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Activo");

                    b.Property<DateTime>("Created")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<DateTime?>("LastModified")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2")
                        .HasColumnName("UltimaFechaModificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Activo");

                    b.Property<int>("CategoriaId")
                        .HasMaxLength(30)
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    b.Property<DateTime>("Created")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Estado");

                    b.Property<DateTime>("FechaLimite")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaLimite");

                    b.Property<DateTime?>("LastModified")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2")
                        .HasColumnName("UltimaFechaModificacion");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tareas", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tarea", b =>
                {
                    b.HasOne("Domain.Entities.Categoria", "Categoria")
                        .WithOne("Tarea")
                        .HasForeignKey("Domain.Entities.Tarea", "CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Tarea")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
