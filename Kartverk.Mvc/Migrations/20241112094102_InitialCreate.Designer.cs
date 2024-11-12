﻿// <auto-generated />
using System;
using Kartverk.Mvc.Models.Feilmelding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kartverk.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241112094102_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Kartverk.Mvc.Models.Feilmelding.FeilmeldingViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Dato")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("GeoJson")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("KommuneInfo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("feilmeldinger");
                });
#pragma warning restore 612, 618
        }
    }
}