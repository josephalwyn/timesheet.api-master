﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using timesheet.data;

namespace timesheet.data.Migrations
{
    [DbContext(typeof(TimesheetDb))]
    partial class TimesheetDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("timesheet.model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("WeeklyAverage");

                    b.Property<int>("WeeklyEffort");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("timesheet.model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("timesheet.model.Timesheeet", b =>
                {
                    b.Property<int?>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("EmployeeId");

                    b.Property<double?>("Friday");

                    b.Property<double?>("Monday");

                    b.Property<double?>("Saturday");

                    b.Property<double?>("Sunday");

                    b.Property<int?>("TaskId");

                    b.Property<string>("Taskname");

                    b.Property<double?>("Thursday");

                    b.Property<double?>("Tuesday");

                    b.Property<double?>("Wednesday");

                    b.HasKey("TimeSheetId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TaskId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("timesheet.model.Timesheeet", b =>
                {
                    b.HasOne("timesheet.model.Employee", "EmployeeDetails")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("timesheet.model.Task", "TaskDetails")
                        .WithMany()
                        .HasForeignKey("TaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
