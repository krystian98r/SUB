﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SUB.Data;

namespace SUB.Migrations
{
    [DbContext(typeof(SUBContext))]
    [Migration("20211125120958_SUBMigration2")]
    partial class SUBMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SUB.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("PortfelId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PortfelId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SUB.Models.HistoriaPortfela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("PortfelId")
                        .HasColumnType("int");

                    b.Property<double>("Srodki")
                        .HasColumnType("float");

                    b.Property<double>("StanPortfela")
                        .HasColumnType("float");

                    b.Property<string>("Zdarzenie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PortfelId");

                    b.ToTable("HistoriaPortfela");
                });

            modelBuilder.Entity("SUB.Models.Kupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ObstawionyKurs")
                        .HasColumnType("int");

                    b.Property<double>("Srodki")
                        .HasColumnType("float");

                    b.Property<string>("UzytkownikId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WydarzenieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UzytkownikId");

                    b.HasIndex("WydarzenieId");

                    b.ToTable("Kupon");
                });

            modelBuilder.Entity("SUB.Models.Portfel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KodPortfela")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<double>("Srodki")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Portfel");
                });

            modelBuilder.Entity("SUB.Models.Wydarzenie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gosc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gospodarz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Remis")
                        .HasColumnType("float");

                    b.Property<int?>("WynikWydarzenia")
                        .HasColumnType("int");

                    b.Property<double?>("ZwyciestwoGosc")
                        .HasColumnType("float");

                    b.Property<double?>("ZwyciestwoGospodarz")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Wydarzenie");
                });

            modelBuilder.Entity("SUB.Models.Zgloszenie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UzytkownikId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("Zgloszenie");
                });

            modelBuilder.Entity("SUB.Models.AspNetUsers", b =>
                {
                    b.HasOne("SUB.Models.Portfel", "Portfel")
                        .WithMany()
                        .HasForeignKey("PortfelId");
                });

            modelBuilder.Entity("SUB.Models.HistoriaPortfela", b =>
                {
                    b.HasOne("SUB.Models.Portfel", "Portfel")
                        .WithMany()
                        .HasForeignKey("PortfelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SUB.Models.Kupon", b =>
                {
                    b.HasOne("SUB.Models.AspNetUsers", "Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UzytkownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SUB.Models.Wydarzenie", "Wydarzenie")
                        .WithMany()
                        .HasForeignKey("WydarzenieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SUB.Models.Zgloszenie", b =>
                {
                    b.HasOne("SUB.Models.AspNetUsers", "Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UzytkownikId");
                });
#pragma warning restore 612, 618
        }
    }
}
