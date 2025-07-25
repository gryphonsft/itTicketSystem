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
    [Migration("20250606123148_updatedmodel")]
    partial class updatedmodel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("itTicketSystem.Models.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("closed_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("assigned_to_user_id");

                    b.HasIndex("user_id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("itTicketSystem.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
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

            modelBuilder.Entity("itTicketSystem.Models.Users", b =>
                {
                    b.HasOne("itTicketSystem.Models.Roles", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("itTicketSystem.Models.Roles", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("itTicketSystem.Models.Users", b =>
                {
                    b.Navigation("AssignedTickets");

                    b.Navigation("CreatedTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
