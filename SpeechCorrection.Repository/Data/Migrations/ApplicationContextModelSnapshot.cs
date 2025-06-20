﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeechCorrection.Repository.Data;

#nullable disable

namespace SpeechCorrection.Repository.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpeechCorrection.Core.Models.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly?>("AvailableFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly?>("AvailableTo")
                        .HasColumnType("time");

                    b.Property<string>("WorkingDays")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FamilyMembersCount")
                        .HasColumnType("int");

                    b.Property<double?>("LatestIqTestResult")
                        .HasColumnType("float");

                    b.Property<double?>("LatestLeftEarTestResult")
                        .HasColumnType("float");

                    b.Property<double?>("LatestRightEarTestResult")
                        .HasColumnType("float");

                    b.Property<int?>("SiblingRank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.TrainingModule.Letter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.TrainingModule.TrainingLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LetterId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LetterId");

                    b.ToTable("TrainingLevels");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.TrainingModule.TrainingRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordingUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingLevelId");

                    b.ToTable("TrainingRecords");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.TrainingModule.TrainingLevel", b =>
                {
                    b.HasOne("SpeechCorrection.Core.Models.TrainingModule.Letter", "Letter")
                        .WithMany("TrainingLevels")
                        .HasForeignKey("LetterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Letter");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.TrainingModule.TrainingRecord", b =>
                {
                    b.HasOne("SpeechCorrection.Core.Models.TrainingModule.TrainingLevel", "TrainingLevel")
                        .WithMany("TrainingRecords")
                        .HasForeignKey("TrainingLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingLevel");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.TrainingModule.Letter", b =>
                {
                    b.Navigation("TrainingLevels");
                });

            modelBuilder.Entity("SpeechCorrection.Core.Models.TrainingModule.TrainingLevel", b =>
                {
                    b.Navigation("TrainingRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
