﻿// <auto-generated />
using System;
using ClayBackendCase.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClayBackendCase.API.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190915230350_Seed_Data")]
    partial class Seed_Data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2019, 9, 15, 23, 3, 50, 529, DateTimeKind.Utc).AddTicks(7349),
                            Name = "Clay Solutions"
                        });
                });

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("LockId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LockId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.Lock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Locks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Created = new DateTime(2019, 9, 15, 23, 3, 50, 530, DateTimeKind.Utc).AddTicks(177),
                            IsLocked = true,
                            Name = "Clay Tunnel Lock"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            Created = new DateTime(2019, 9, 15, 23, 3, 50, 530, DateTimeKind.Utc).AddTicks(774),
                            IsLocked = true,
                            Name = "Clay Office Lock"
                        });
                });

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2019, 9, 15, 23, 3, 50, 529, DateTimeKind.Utc).AddTicks(9372),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2019, 9, 15, 23, 3, 50, 529, DateTimeKind.Utc).AddTicks(9598),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.Event", b =>
                {
                    b.HasOne("ClayBackendCase.API.Core.Entities.Lock", "Lock")
                        .WithMany("Events")
                        .HasForeignKey("LockId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClayBackendCase.API.Core.Entities.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.Lock", b =>
                {
                    b.HasOne("ClayBackendCase.API.Core.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClayBackendCase.API.Core.Entities.User", b =>
                {
                    b.HasOne("ClayBackendCase.API.Core.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.HasOne("ClayBackendCase.API.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
