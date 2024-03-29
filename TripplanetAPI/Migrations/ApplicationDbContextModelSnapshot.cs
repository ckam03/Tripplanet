﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TripplanetAPI.Data;

#nullable disable

namespace TripplanetAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TripplanetAPI.Models.location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("positionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("positionId");

                    b.ToTable("location");
                });

            modelBuilder.Entity("TripplanetAPI.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocationId"));

                    b.Property<string>("id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("locationId")
                        .HasColumnType("integer");

                    b.Property<int?>("urlsId")
                        .HasColumnType("integer");

                    b.HasKey("LocationId");

                    b.HasIndex("locationId");

                    b.HasIndex("urlsId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("TripplanetAPI.Models.position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("latitude")
                        .HasColumnType("double precision");

                    b.Property<double?>("longitude")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("position");
                });

            modelBuilder.Entity("TripplanetAPI.Models.urls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("small")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("urls");
                });

            modelBuilder.Entity("TripplanetAPI.Models.location", b =>
                {
                    b.HasOne("TripplanetAPI.Models.position", "position")
                        .WithMany()
                        .HasForeignKey("positionId");

                    b.Navigation("position");
                });

            modelBuilder.Entity("TripplanetAPI.Models.Location", b =>
                {
                    b.HasOne("TripplanetAPI.Models.location", "location")
                        .WithMany()
                        .HasForeignKey("locationId");

                    b.HasOne("TripplanetAPI.Models.urls", "urls")
                        .WithMany()
                        .HasForeignKey("urlsId");

                    b.Navigation("location");

                    b.Navigation("urls");
                });
#pragma warning restore 612, 618
        }
    }
}
