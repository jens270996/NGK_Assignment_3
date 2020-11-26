﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TemperatureAPI.Data;

namespace TemperatureAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201119102406_indexing")]
    partial class indexing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TemperatureAPI.Models.Location", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longtitude")
                        .HasColumnType("float");

                    b.HasKey("Name");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TemperatureAPI.Models.Measurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Pressure")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("MeasurementId");

                    b.HasIndex("LocationName");

                    b.HasIndex("Time");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("TemperatureAPI.Models.Measurement", b =>
                {
                    b.HasOne("TemperatureAPI.Models.Location", "Location")
                        .WithMany("Measurements")
                        .HasForeignKey("LocationName");
                });
#pragma warning restore 612, 618
        }
    }
}