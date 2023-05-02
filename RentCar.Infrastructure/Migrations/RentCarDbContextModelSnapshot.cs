﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCar.Infrastructure.Data;

#nullable disable

namespace RentCar.Infrastructure.Migrations
{
    [DbContext(typeof(RentCarDbContext))]
    partial class RentCarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("RentCar.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DropOffOfficeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DropOffTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("PickUpOfficeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PickUpTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalCost")
                        .HasColumnType("REAL");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserSurname")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DropOffOfficeId");

                    b.HasIndex("PickUpOfficeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("OfficeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TimeClose")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TimeOpen")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("DailyPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Year")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CargoCapacityInLitres")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelName")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INTEGER");

                    b.Property<double>("RangeInKilometers")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.Booking", b =>
                {
                    b.HasOne("RentCar.Domain.Entities.Office", "DropOffOffice")
                        .WithMany()
                        .HasForeignKey("DropOffOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentCar.Domain.Entities.Office", "PickUpOffice")
                        .WithMany()
                        .HasForeignKey("PickUpOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentCar.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany("Bookings")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DropOffOffice");

                    b.Navigation("PickUpOffice");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("RentCar.Domain.Entities.VehicleModel", "VehicleModel")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.VehicleModel", b =>
                {
                    b.HasOne("RentCar.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany("VehicleModels")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.Manufacturer", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("RentCar.Domain.Entities.VehicleModel", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
