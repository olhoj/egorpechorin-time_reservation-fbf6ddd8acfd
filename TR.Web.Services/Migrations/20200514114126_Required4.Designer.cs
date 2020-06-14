﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TR.Web.Services.Data;

namespace TR.Web.Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200514114126_Required4")]
    partial class Required4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TR.Web.Models.Models.AcceptedSlot", b =>
                {
                    b.Property<int>("AcceptedSlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientContactMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SlotID")
                        .HasColumnType("int");

                    b.HasKey("AcceptedSlotID");

                    b.HasIndex("SlotID");

                    b.ToTable("AcceptedSlot");
                });

            modelBuilder.Entity("TR.Web.Models.Models.Diapason", b =>
                {
                    b.Property<int>("DiapasonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFriday")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMonday")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSaturday")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSunday")
                        .HasColumnType("bit");

                    b.Property<bool>("IsThursday")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTuesday")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWednesday")
                        .HasColumnType("bit");

                    b.Property<int>("MeetingVariantID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiapasonID");

                    b.HasIndex("MeetingVariantID");

                    b.ToTable("Diapason");
                });

            modelBuilder.Entity("TR.Web.Models.Models.MeetingVariant", b =>
                {
                    b.Property<int>("MeetingVariantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingVariantID");

                    b.ToTable("MeetingVariant");
                });

            modelBuilder.Entity("TR.Web.Models.Models.Slot", b =>
                {
                    b.Property<int>("SlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiapasonID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinishSlotTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("MeetingVariantID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartSlotTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SlotID");

                    b.HasIndex("DiapasonID");

                    b.HasIndex("MeetingVariantID");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("TR.Web.Models.Models.AcceptedSlot", b =>
                {
                    b.HasOne("TR.Web.Models.Models.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TR.Web.Models.Models.Diapason", b =>
                {
                    b.HasOne("TR.Web.Models.Models.MeetingVariant", "MeetingVariant")
                        .WithMany()
                        .HasForeignKey("MeetingVariantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TR.Web.Models.Models.Slot", b =>
                {
                    b.HasOne("TR.Web.Models.Models.Diapason", "Diapason")
                        .WithMany()
                        .HasForeignKey("DiapasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TR.Web.Models.Models.MeetingVariant", "MeetingVariant")
                        .WithMany()
                        .HasForeignKey("MeetingVariantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
