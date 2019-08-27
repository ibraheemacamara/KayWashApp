﻿// <auto-generated />
using System;
using KayWashApp.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KayWashApp.Migrations
{
    [DbContext(typeof(KayWashDbContext))]
    partial class KayWashDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KayWashApp.DataBase.Entities.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<long?>("CustomerId");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Brand = "Renault",
                            Model = "Clio IV"
                        },
                        new
                        {
                            Id = 2L,
                            Brand = "Peugeot",
                            Model = "406"
                        });
                });

            modelBuilder.Entity("KayWashApp.DataBase.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("Note");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte[]>("Profile_Pic");

                    b.Property<int>("Status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("KayWashApp.DataBase.Entities.Washer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("Note");

                    b.Property<int>("NumberOfWash");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte[]>("Profile_Pic");

                    b.Property<int>("Status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Washers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Ibrahima Camara",
                            Note = 0,
                            NumberOfWash = 0,
                            Password = "icamara",
                            Status = 0,
                            Username = "icamara"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Ibou Cmr",
                            Note = 0,
                            NumberOfWash = 0,
                            Password = "ikacmr",
                            Status = 0,
                            Username = "ikacmr"
                        });
                });

            modelBuilder.Entity("KayWashApp.DataBase.Entities.Car", b =>
                {
                    b.HasOne("KayWashApp.DataBase.Entities.Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
