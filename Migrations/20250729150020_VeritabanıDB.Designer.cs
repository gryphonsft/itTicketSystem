﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using itTicketSystem.Models;

#nullable disable

namespace itTicketSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250729150020_VeritabanıDB")]
    partial class VeritabanıDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("itTicketSystem.Models.BrandModelSelectDB", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("BrandModelSelectDB");
                });

            modelBuilder.Entity("itTicketSystem.Models.Devices", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("itTicketSystem.Models.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("itTicketSystem.Models.Tickets", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("assigned_to_user_id")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("closed_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("assigned_to_user_id");

                    b.HasIndex("user_id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("itTicketSystem.Models.User_Devices", b =>
                {
                    b.Property<int>("UserDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserDeviceId"));

                    b.Property<DateTime>("AssignedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCurrentlyAssigned")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UnassignedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserDeviceId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UserId");

                    b.ToTable("User_Devices");
                });

            modelBuilder.Entity("itTicketSystem.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("itTicketSystem.Models.Tickets", b =>
                {
                    b.HasOne("itTicketSystem.Models.Users", "AssignedToUser")
                        .WithMany("AssignedTickets")
                        .HasForeignKey("assigned_to_user_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("itTicketSystem.Models.Users", "Users")
                        .WithMany("CreatedTickets")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AssignedToUser");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("itTicketSystem.Models.User_Devices", b =>
                {
                    b.HasOne("itTicketSystem.Models.Devices", "Devices")
                        .WithMany("User_Devices")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itTicketSystem.Models.Users", "Users")
                        .WithMany("User_Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Devices");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("itTicketSystem.Models.Users", b =>
                {
                    b.HasOne("itTicketSystem.Models.Roles", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("itTicketSystem.Models.Devices", b =>
                {
                    b.Navigation("User_Devices");
                });

            modelBuilder.Entity("itTicketSystem.Models.Roles", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("itTicketSystem.Models.Users", b =>
                {
                    b.Navigation("AssignedTickets");

                    b.Navigation("CreatedTickets");

                    b.Navigation("User_Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
