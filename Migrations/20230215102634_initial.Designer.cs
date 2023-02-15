﻿// <auto-generated />
using System;
using HRSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230215102634_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRSystem.Models.Declaratie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AanvraagDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Bedrag")
                        .HasColumnType("int");

                    b.Property<int>("Btw")
                        .HasColumnType("int");

                    b.Property<int>("Categorie")
                        .HasColumnType("int");

                    b.Property<string>("Documenten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GoedKeuring")
                        .HasColumnType("bit");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Declaratie");
                });

            modelBuilder.Entity("HRSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AchterNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeclaratieId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GebruikersNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<int>("Team")
                        .HasColumnType("int");

                    b.Property<int>("VakantieId")
                        .HasColumnType("int");

                    b.Property<string>("VoorNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeclaratieId");

                    b.HasIndex("VakantieId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HRSystem.Models.Vakantie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AanvraagDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BeginDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("GoedKeuring")
                        .HasColumnType("bit");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vakantie");
                });

            modelBuilder.Entity("HRSystem.Models.User", b =>
                {
                    b.HasOne("HRSystem.Models.Declaratie", "Declaratie")
                        .WithMany()
                        .HasForeignKey("DeclaratieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRSystem.Models.Vakantie", "Vakantie")
                        .WithMany()
                        .HasForeignKey("VakantieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Declaratie");

                    b.Navigation("Vakantie");
                });
#pragma warning restore 612, 618
        }
    }
}
