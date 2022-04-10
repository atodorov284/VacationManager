﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacationManager.Repositories;

namespace VacationManager.Migrations
{
    [DbContext(typeof(VacationManagerDbContext))]
    partial class VacationManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTeam", b =>
                {
                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("int");

                    b.Property<int>("WorkingProjectsProjectId")
                        .HasColumnType("int");

                    b.HasKey("TeamsTeamId", "WorkingProjectsProjectId");

                    b.HasIndex("WorkingProjectsProjectId");

                    b.ToTable("ProjectTeam");
                });

            modelBuilder.Entity("VacationManager.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TeamNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamToAdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamToRemove")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("VacationManager.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Leader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Project")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("VacationManager.Models.TimeOff", b =>
                {
                    b.Property<int>("TimeOffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HalfDay")
                        .HasColumnType("bit");

                    b.Property<string>("RequestingUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeOffId");

                    b.ToTable("TimeOffs");
                });

            modelBuilder.Entity("VacationManager.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Project")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserId");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "Admin",
                            LastName = "Istrator",
                            Password = "CEOpass",
                            Role = 3,
                            Username = "CEO"
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "Manager",
                            LastName = "Manager",
                            Password = "Manager",
                            Role = 2,
                            Username = "Manager"
                        },
                        new
                        {
                            UserId = 3,
                            FirstName = "Aleksandar",
                            LastName = "Todorov",
                            Password = "atodorov",
                            Role = 1,
                            Username = "atodorov"
                        },
                        new
                        {
                            UserId = 4,
                            FirstName = "Gabriela",
                            LastName = "Dimitrova",
                            Password = "gdimitrova",
                            Role = 1,
                            Username = "gdimitrova"
                        },
                        new
                        {
                            UserId = 5,
                            FirstName = "Nadezhda",
                            LastName = "Savcheva",
                            Password = "nsavcheva",
                            Role = 1,
                            Username = "nsavcheva"
                        });
                });

            modelBuilder.Entity("ProjectTeam", b =>
                {
                    b.HasOne("VacationManager.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacationManager.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("WorkingProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VacationManager.Models.User", b =>
                {
                    b.HasOne("VacationManager.Models.Team", null)
                        .WithMany("Developers")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("VacationManager.Models.Team", b =>
                {
                    b.Navigation("Developers");
                });
#pragma warning restore 612, 618
        }
    }
}
