﻿// <auto-generated />
using System;
using Laroni_Travel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Laroni_Travel.Migrations
{
    [DbContext(typeof(Laronu_TravelContext))]
    [Migration("20230420105433_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Laroni_Travel.Models.Bestemming", b =>
                {
                    b.Property<int>("BestemmingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BestemmingId"));

                    b.Property<string>("Gemeente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Huisnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straatnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BestemmingId");

                    b.ToTable("Bestemmingen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Deelnemer", b =>
                {
                    b.Property<int>("DeelnemerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeelnemerId"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<int>("BestemmingId")
                        .HasColumnType("int");

                    b.Property<int?>("DeelnemerGroepsreisId")
                        .HasColumnType("int");

                    b.Property<string>("Familiennaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gemeente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Geslacht")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HoofdMonitor")
                        .HasColumnType("bit");

                    b.Property<string>("Huisnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Monitor")
                        .HasColumnType("bit");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straatnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ziekenfonds")
                        .HasColumnType("bit");

                    b.HasKey("DeelnemerId");

                    b.HasIndex("BestemmingId");

                    b.HasIndex("DeelnemerGroepsreisId");

                    b.ToTable("Deelnemers");
                });

            modelBuilder.Entity("Laroni_Travel.Models.DeelnemerGroepsreis", b =>
                {
                    b.Property<int>("DeelnemerGroepsreisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeelnemerGroepsreisId"));

                    b.Property<int>("DeelnemerId")
                        .HasColumnType("int");

                    b.Property<int>("GroepsreisId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("DeelnemerGroepsreisId");

                    b.HasIndex("GroepsreisId");

                    b.HasIndex("RolId");

                    b.ToTable("DeelnemerGroepsreisen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.DeelnemerOpleiding", b =>
                {
                    b.Property<int>("DeelnemerOpleidingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeelnemerOpleidingId"));

                    b.Property<int>("DeelnemerId")
                        .HasColumnType("int");

                    b.Property<int>("OpleidingId")
                        .HasColumnType("int");

                    b.HasKey("DeelnemerOpleidingId");

                    b.HasIndex("DeelnemerId");

                    b.HasIndex("OpleidingId");

                    b.ToTable("DeelnemerOpleidingen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Groepsreis", b =>
                {
                    b.Property<int>("GroepsreisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroepsreisId"));

                    b.Property<string>("BestemmingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BestemmingId1")
                        .HasColumnType("int");

                    b.Property<int>("LeeftijdsCategorieID")
                        .HasColumnType("int");

                    b.Property<string>("LeeftijdsCategorieId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("money");

                    b.Property<string>("ThemaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThemaId1")
                        .HasColumnType("int");

                    b.HasKey("GroepsreisId");

                    b.HasIndex("BestemmingId1");

                    b.HasIndex("LeeftijdsCategorieID");

                    b.HasIndex("ThemaId1");

                    b.ToTable("Groepsreisen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.LeeftijdsCategorie", b =>
                {
                    b.Property<int>("LeeftijdsCategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeeftijdsCategorieID"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeeftijdsCategorieID");

                    b.ToTable("LeeftijdsCategorieen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Medisch", b =>
                {
                    b.Property<int>("MedischId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedischId"));

                    b.Property<string>("Behandeling")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeelnemerId")
                        .HasColumnType("int");

                    b.Property<string>("Medicatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedischId");

                    b.HasIndex("DeelnemerId");

                    b.ToTable("Medische");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Opleiding", b =>
                {
                    b.Property<int>("OpleidingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OpleidingId"));

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BestemmingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeelnemerId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("OpleidingId");

                    b.HasIndex("BestemmingId");

                    b.HasIndex("DeelnemerId");

                    b.HasIndex("RolId");

                    b.ToTable("Opleidingen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.OpleidingBestemming", b =>
                {
                    b.Property<int>("OpleidingBestemmingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OpleidingBestemmingId"));

                    b.Property<int>("BestemmingId")
                        .HasColumnType("int");

                    b.Property<int>("OpleidingId")
                        .HasColumnType("int");

                    b.HasKey("OpleidingBestemmingId");

                    b.HasIndex("BestemmingId");

                    b.HasIndex("OpleidingId");

                    b.ToTable("OpleidingBestemmingen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Rolen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Thema", b =>
                {
                    b.Property<int>("ThemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThemaId"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThemaId");

                    b.ToTable("Themas");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Deelnemer", b =>
                {
                    b.HasOne("Laroni_Travel.Models.Bestemming", "Bestemming")
                        .WithMany("deelnemers")
                        .HasForeignKey("BestemmingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.DeelnemerGroepsreis", null)
                        .WithMany("Deelnemer")
                        .HasForeignKey("DeelnemerGroepsreisId");

                    b.Navigation("Bestemming");
                });

            modelBuilder.Entity("Laroni_Travel.Models.DeelnemerGroepsreis", b =>
                {
                    b.HasOne("Laroni_Travel.Models.Groepsreis", "Groepsreis")
                        .WithMany()
                        .HasForeignKey("GroepsreisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groepsreis");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Laroni_Travel.Models.DeelnemerOpleiding", b =>
                {
                    b.HasOne("Laroni_Travel.Models.Deelnemer", "deelnemer")
                        .WithMany("deelnemerOpleiding")
                        .HasForeignKey("DeelnemerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.Opleiding", "opleiding")
                        .WithMany("deelnemerOpleiding")
                        .HasForeignKey("OpleidingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("deelnemer");

                    b.Navigation("opleiding");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Groepsreis", b =>
                {
                    b.HasOne("Laroni_Travel.Models.Bestemming", "bestemming")
                        .WithMany()
                        .HasForeignKey("BestemmingId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.LeeftijdsCategorie", "leeftijdsCategorie")
                        .WithMany()
                        .HasForeignKey("LeeftijdsCategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.Thema", "thema")
                        .WithMany()
                        .HasForeignKey("ThemaId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bestemming");

                    b.Navigation("leeftijdsCategorie");

                    b.Navigation("thema");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Medisch", b =>
                {
                    b.HasOne("Laroni_Travel.Models.Deelnemer", "Deelnemer")
                        .WithMany()
                        .HasForeignKey("DeelnemerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deelnemer");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Opleiding", b =>
                {
                    b.HasOne("Laroni_Travel.Models.Bestemming", "Bestemming")
                        .WithMany("opleidingen")
                        .HasForeignKey("BestemmingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.Deelnemer", null)
                        .WithMany("opleidingen")
                        .HasForeignKey("DeelnemerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bestemming");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Laroni_Travel.Models.OpleidingBestemming", b =>
                {
                    b.HasOne("Laroni_Travel.Models.Bestemming", "Bestemming")
                        .WithMany("opleidingBestemming")
                        .HasForeignKey("BestemmingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laroni_Travel.Models.Opleiding", "Opleiding")
                        .WithMany()
                        .HasForeignKey("OpleidingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bestemming");

                    b.Navigation("Opleiding");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Bestemming", b =>
                {
                    b.Navigation("deelnemers");

                    b.Navigation("opleidingBestemming");

                    b.Navigation("opleidingen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Deelnemer", b =>
                {
                    b.Navigation("deelnemerOpleiding");

                    b.Navigation("opleidingen");
                });

            modelBuilder.Entity("Laroni_Travel.Models.DeelnemerGroepsreis", b =>
                {
                    b.Navigation("Deelnemer");
                });

            modelBuilder.Entity("Laroni_Travel.Models.Opleiding", b =>
                {
                    b.Navigation("deelnemerOpleiding");
                });
#pragma warning restore 612, 618
        }
    }
}