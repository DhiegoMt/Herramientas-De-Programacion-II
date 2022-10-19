﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_autores;

namespace api_autores.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221005193639_LibroV2")]
    partial class LibroV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api_autores.Entitys.Autor", b =>
                {
                    b.Property<int>("codigoautor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("codigoautor");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("api_autores.Entitys.Libro", b =>
                {
                    b.Property<int>("codigolibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("autorcodigoautor")
                        .HasColumnType("int");

                    b.Property<int>("codigoautor")
                        .HasColumnType("int");

                    b.Property<int>("titulo")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("codigolibro");

                    b.HasIndex("autorcodigoautor");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("api_autores.Entitys.Libro", b =>
                {
                    b.HasOne("api_autores.Entitys.Autor", "autor")
                        .WithMany("libro")
                        .HasForeignKey("autorcodigoautor");

                    b.Navigation("autor");
                });

            modelBuilder.Entity("api_autores.Entitys.Autor", b =>
                {
                    b.Navigation("libro");
                });
#pragma warning restore 612, 618
        }
    }
}
