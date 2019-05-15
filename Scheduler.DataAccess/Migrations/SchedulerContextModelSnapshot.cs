﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scheduler.DataAccess.Implementation;

namespace Scheduler.DataAccess.Migrations
{
    [DbContext(typeof(SchedulerContext))]
    partial class SchedulerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scheduler.DataAccess.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("NumberOfStudents");

                    b.HasKey("GroupId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Scheduler.DataAccess.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<int>("Capacity");

                    b.Property<int>("RoomNumberd");

                    b.Property<string>("Type");

                    b.HasKey("RoomId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Scheduler.DataAccess.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day");

                    b.Property<int>("GroupId");

                    b.Property<short?>("Lesson");

                    b.Property<int>("RoomId");

                    b.Property<int?>("TeacherId");

                    b.HasKey("ScheduleId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("Scheduler.DataAccess.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.HasKey("TeacherId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("Scheduler.DataAccess.Models.Schedule", b =>
                {
                    b.HasOne("Scheduler.DataAccess.Models.Group", "Group")
                        .WithMany("Schedule")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Scheduler.DataAccess.Models.Room", "Room")
                        .WithMany("Schedule")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Scheduler.DataAccess.Models.Teacher", "Teacher")
                        .WithMany("Schedule")
                        .HasForeignKey("TeacherId");
                });
#pragma warning restore 612, 618
        }
    }
}
