﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_autores;

namespace api_autores.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221007033254_V3")]
    partial class V3
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

                    b.Property<int>("autorcodigoautor")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("codigolibro");

                    b.HasIndex("autorcodigoautor");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("api_autores.Entitys.Libro", b =>
                {
                    b.HasOne("api_autores.Entitys.Autor", "autor")
                        .WithMany("libro")
                        .HasForeignKey("autorcodigoautor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
