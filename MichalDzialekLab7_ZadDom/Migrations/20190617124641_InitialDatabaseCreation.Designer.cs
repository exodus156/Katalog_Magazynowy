﻿// <auto-generated />
using System;
using MichalDzialekLab7_ZadDom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MichalDzialekLab7_ZadDom.Migrations
{
    [DbContext(typeof(KatalogContext))]
    [Migration("20190617124641_InitialDatabaseCreation")]
    partial class InitialDatabaseCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MichalDzialekLab7_ZadDom.Models.Kategoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("MichalDzialekLab7_ZadDom.Models.Przedmiot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<int>("Ilosc");

                    b.Property<int>("KategoriaID");

                    b.Property<string>("Nazwa")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("RodzajID");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<int>("TypID");

                    b.HasKey("ID");

                    b.HasIndex("KategoriaID");

                    b.HasIndex("RodzajID");

                    b.HasIndex("TypID");

                    b.ToTable("Przedmioty");
                });

            modelBuilder.Entity("MichalDzialekLab7_ZadDom.Models.Rodzaj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Rodzaje");
                });

            modelBuilder.Entity("MichalDzialekLab7_ZadDom.Models.Typ", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Typy");
                });

            modelBuilder.Entity("MichalDzialekLab7_ZadDom.Models.Przedmiot", b =>
                {
                    b.HasOne("MichalDzialekLab7_ZadDom.Models.Kategoria", "Kategoria")
                        .WithMany()
                        .HasForeignKey("KategoriaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MichalDzialekLab7_ZadDom.Models.Rodzaj", "Rodzaj")
                        .WithMany()
                        .HasForeignKey("RodzajID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MichalDzialekLab7_ZadDom.Models.Typ", "Typ")
                        .WithMany()
                        .HasForeignKey("TypID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
