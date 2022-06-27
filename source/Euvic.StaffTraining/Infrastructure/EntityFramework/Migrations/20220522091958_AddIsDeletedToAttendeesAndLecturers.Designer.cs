﻿// <auto-generated />
using System;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Euvic.StaffTraining.Migrations
{
    [DbContext(typeof(StaffTrainingContext))]
    [Migration("20220522091958_AddIsDeletedToAttendeesAndLecturers")]
    partial class AddIsDeletedToAttendeesAndLecturers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Attendee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("AllowedHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Lecturer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("AllowedHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Technology", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<long>("LecturerId")
                        .HasColumnType("bigint");

                    b.Property<long>("TechnologyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("TrainingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.HasIndex("TechnologyId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.TrainingAttendee", b =>
                {
                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("AttendeeId")
                        .HasColumnType("bigint");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("TrainingId", "AttendeeId");

                    b.HasIndex("AttendeeId");

                    b.HasIndex("StatusId");

                    b.ToTable("TrainingAttendee");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.TrainingAttendeeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainingAttendeeStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Interested"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Confirmed"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Declined"
                        });
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Views.AttendeeSummary", b =>
                {
                    b.Property<long>("AttendeeId")
                        .HasColumnType("bigint");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.ToView("dbo.AttendeeSummary");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Training", b =>
                {
                    b.HasOne("Euvic.StaffTraining.Entities.Lecturer", "Lecturer")
                        .WithMany("Trainings")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euvic.StaffTraining.Entities.Technology", "Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.TrainingAttendee", b =>
                {
                    b.HasOne("Euvic.StaffTraining.Entities.Attendee", "Attendee")
                        .WithMany("Trainings")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euvic.StaffTraining.Entities.TrainingAttendeeStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euvic.StaffTraining.Entities.Training", "Training")
                        .WithMany("Attendees")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Status");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Attendee", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Lecturer", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("Euvic.StaffTraining.Entities.Training", b =>
                {
                    b.Navigation("Attendees");
                });
#pragma warning restore 612, 618
        }
    }
}
