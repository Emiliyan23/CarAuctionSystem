﻿// <auto-generated />
using System;
using CarAuctionSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarAuctionSystem.Infrastructure.Migrations
{
    [DbContext(typeof(CarAuctionDbContext))]
    [Migration("20230623221129_SeedAuction")]
    partial class SeedAuction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5af6e6e8-4756-42dd-9acf-c965842f0fc4"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "458c6fe1-fd20-4083-a786-fa525d20ab86",
                            Email = "emiliqn.slav@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMILIQN.SLAV@GMAIL.COM",
                            NormalizedUserName = "EMILIQN.SLAV@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFcdP04h/YqN4Cy/hWN8w1N3EDMTSioqFMzqo3ul0AEUuaVkTMbcY3ARZAFnMy7kfg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "emiliqn.slav@gmail.com"
                        });
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarBodyId")
                        .HasColumnType("int");

                    b.Property<int>("DrivetrainId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EngineDetails")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExteriorColor")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("FuelId")
                        .HasColumnType("int");

                    b.Property<string>("InteriorColor")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<Guid?>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransmissionId")
                        .HasColumnType("int");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.HasKey("Id");

                    b.HasIndex("CarBodyId");

                    b.HasIndex("DrivetrainId");

                    b.HasIndex("FuelId");

                    b.HasIndex("MakeId");

                    b.HasIndex("SellerId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("Auctions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarBodyId = 4,
                            DrivetrainId = 2,
                            EndDate = new DateTime(2023, 6, 26, 22, 11, 29, 146, DateTimeKind.Utc).AddTicks(3150),
                            EngineDetails = "2.7L Inline-5",
                            ExteriorColor = "Brilliant silver metallic",
                            FuelId = 2,
                            InteriorColor = "Black/Antracite",
                            MakeId = 32,
                            Mileage = 250000,
                            Model = "C270 CDI",
                            ModelYear = 2004,
                            StartDate = new DateTime(2023, 6, 23, 22, 11, 29, 146, DateTimeKind.Utc).AddTicks(3146),
                            TransmissionId = 2,
                            Vin = "WDB2030161A714562"
                        });
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.CarBody", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("CarBodies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Coupe"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Convertible"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Hatchback"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Sedan"
                        },
                        new
                        {
                            Id = 5,
                            Type = "SUV/Crossover"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Truck"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Van/Minivan"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Wagon"
                        },
                        new
                        {
                            Id = 9,
                            Type = "Other"
                        });
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Drivetrain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Drivetrains");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Front-wheel drive"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Rear-wheel drive"
                        },
                        new
                        {
                            Id = 3,
                            Type = "4WD/AWD"
                        });
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Fuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Fuels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Petrol"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Diesel"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Hybrid"
                        },
                        new
                        {
                            Id = 4,
                            Type = "EV"
                        });
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Makes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Acura"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alfa Romeo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aston Martin"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bentley"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Buick"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Cadillac"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Chrysler"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Dodge"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Ferrari"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Fiat"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Honda"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Hummer"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Hyundai"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Infiniti"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Jaguar"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Jeep"
                        },
                        new
                        {
                            Id = 21,
                            Name = "KIA"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Koenigsegg"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Lamborghini"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Land Rover"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Lexus"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Lincoln"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Lotus"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Maserati"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Maybach"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Mazda"
                        },
                        new
                        {
                            Id = 31,
                            Name = "McLaren"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Mini"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Mitsubishi"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Nissan"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Opel"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Porsche"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Range Rover"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Rolls Royce"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Saleen"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Smart"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Subaru"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Suzuki"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Tesla"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Volvo"
                        });
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Transmissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Manual"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Automatic"
                        },
                        new
                        {
                            Id = 3,
                            Type = "EV"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Auction", b =>
                {
                    b.HasOne("CarAuctionSystem.Infrastructure.Data.Models.CarBody", "CarBody")
                        .WithMany("Auctions")
                        .HasForeignKey("CarBodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAuctionSystem.Infrastructure.Data.Models.Drivetrain", "Drivetrain")
                        .WithMany("Auctions")
                        .HasForeignKey("DrivetrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAuctionSystem.Infrastructure.Data.Models.Fuel", "Fuel")
                        .WithMany("Auctions")
                        .HasForeignKey("FuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAuctionSystem.Infrastructure.Data.Models.Make", "Make")
                        .WithMany("Auctions")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAuctionSystem.Infrastructure.Data.ApplicationUser", "Seller")
                        .WithMany("Auctions")
                        .HasForeignKey("SellerId");

                    b.HasOne("CarAuctionSystem.Infrastructure.Data.Models.Transmission", "Transmission")
                        .WithMany("Auctions")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBody");

                    b.Navigation("Drivetrain");

                    b.Navigation("Fuel");

                    b.Navigation("Make");

                    b.Navigation("Seller");

                    b.Navigation("Transmission");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CarAuctionSystem.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CarAuctionSystem.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAuctionSystem.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CarAuctionSystem.Infrastructure.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.ApplicationUser", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.CarBody", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Drivetrain", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Fuel", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Make", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("CarAuctionSystem.Infrastructure.Data.Models.Transmission", b =>
                {
                    b.Navigation("Auctions");
                });
#pragma warning restore 612, 618
        }
    }
}
