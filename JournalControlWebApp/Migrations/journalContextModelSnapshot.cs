﻿// <auto-generated />
using System;
using JournalControlWebApp.Models.dbo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JournalControlWebApp.Migrations
{
    [DbContext(typeof(journalContext))]
    partial class journalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Check", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckDate")
                        .HasColumnName("check_date")
                        .HasColumnType("datetime");

                    b.Property<string>("CheckWorker")
                        .IsRequired()
                        .HasColumnName("check_worker")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ControlIndicator")
                        .IsRequired()
                        .HasColumnName("control_indicator")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("CountOperations")
                        .HasColumnName("count_operations")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("delete_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("DeleteWorker")
                        .HasColumnName("delete_worker")
                        .HasColumnType("int");

                    b.Property<string>("FailCount")
                        .IsRequired()
                        .HasColumnName("fail_count")
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("FailDescription")
                        .IsRequired()
                        .HasColumnName("fail_description")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool>("IsActive")
                        .HasColumnName("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCorrect")
                        .HasColumnName("isCorrect")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFail")
                        .HasColumnName("isFail")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegDate")
                        .HasColumnName("reg_date")
                        .HasColumnType("datetime");

                    b.Property<int>("RegWorker")
                        .HasColumnName("reg_worker")
                        .HasColumnType("int");

                    b.Property<int>("SectorId")
                        .HasColumnName("sector_id")
                        .HasColumnType("int");

                    b.Property<string>("TdKd")
                        .IsRequired()
                        .HasColumnName("td_kd")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("DeleteWorker");

                    b.HasIndex("RegWorker");

                    b.HasIndex("SectorId");

                    b.ToTable("check");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CheckId")
                        .HasColumnName("check_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnName("delete_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("DeleteWorker")
                        .HasColumnName("delete_worker")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<DateTime>("DevelopDate")
                        .HasColumnName("develop_date")
                        .HasColumnType("datetime");

                    b.Property<int>("Developer")
                        .HasColumnName("developer")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnName("due_date")
                        .HasColumnType("date");

                    b.Property<string>("FailReason")
                        .HasColumnName("fail_reason")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool>("IsActive")
                        .HasColumnName("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCorrect")
                        .HasColumnName("isCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("ProofInf")
                        .HasColumnName("proof_inf")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Report")
                        .HasColumnName("report")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ReportDate")
                        .HasColumnName("report_date")
                        .HasColumnType("datetime");

                    b.Property<int?>("ReportWorker")
                        .HasColumnName("report_worker")
                        .HasColumnType("int");

                    b.Property<string>("ResponsWorker")
                        .IsRequired()
                        .HasColumnName("respons_worker")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CheckId");

                    b.HasIndex("DeleteWorker");

                    b.HasIndex("Developer");

                    b.HasIndex("ReportWorker");

                    b.ToTable("events");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsMain")
                        .HasColumnName("is_main")
                        .HasColumnType("bit");

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnName("sector")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("SubunitId")
                        .HasColumnName("subunit_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubunitId");

                    b.ToTable("sectors");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CheckId")
                        .HasColumnName("check_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime");

                    b.Property<int>("WorkerId")
                        .HasColumnName("worker_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckId");

                    b.HasIndex("WorkerId");

                    b.ToTable("shows");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Subunit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Subunits");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnName("family")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<bool>("IsFirstLogin")
                        .HasColumnName("is_first_login")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Otch")
                        .IsRequired()
                        .HasColumnName("otch")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnName("post")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("SectorId")
                        .HasColumnName("sector_id")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SectorId");

                    b.ToTable("workers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Check", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", "DeleteWorkerNavigation")
                        .WithMany("CheckDeleteWorkerNavigation")
                        .HasForeignKey("DeleteWorker")
                        .HasConstraintName("FK_delete_worker");

                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", "RegWorkerNavigation")
                        .WithMany("CheckRegWorkerNavigation")
                        .HasForeignKey("RegWorker")
                        .HasConstraintName("FK_reg_worker")
                        .IsRequired();

                    b.HasOne("JournalControlWebApp.Models.dbo.Sector", "Sector")
                        .WithMany("Check")
                        .HasForeignKey("SectorId")
                        .HasConstraintName("FK_check_sector")
                        .IsRequired();
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Event", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Check", "Check")
                        .WithMany("Events")
                        .HasForeignKey("CheckId")
                        .HasConstraintName("FK_events_check")
                        .IsRequired();

                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", "DeleteWorkerNavigation")
                        .WithMany("EventsDeleteWorkerNavigation")
                        .HasForeignKey("DeleteWorker")
                        .HasConstraintName("FK_events_delete_worker");

                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", "DeveloperNavigation")
                        .WithMany("EventsDeveloperNavigation")
                        .HasForeignKey("Developer")
                        .HasConstraintName("FK_events_developer")
                        .IsRequired();

                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", "ReportWorkerNavigation")
                        .WithMany("EventsReportWorkerNavigation")
                        .HasForeignKey("ReportWorker")
                        .HasConstraintName("FK_events_report_worker");
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Sector", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Subunit", "Subunit")
                        .WithMany("Sectors")
                        .HasForeignKey("SubunitId")
                        .HasConstraintName("FK_sector_subunit")
                        .IsRequired();
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Show", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Check", "Check")
                        .WithMany("Shows")
                        .HasForeignKey("CheckId")
                        .HasConstraintName("FK_shows_check")
                        .IsRequired();

                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", "Worker")
                        .WithMany("Shows")
                        .HasForeignKey("WorkerId")
                        .HasConstraintName("FK_shows_workers")
                        .IsRequired();
                });

            modelBuilder.Entity("JournalControlWebApp.Models.dbo.Worker", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Sector", "Sector")
                        .WithMany("Workers")
                        .HasForeignKey("SectorId")
                        .HasConstraintName("FK_worker_sector")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("JournalControlWebApp.Models.dbo.Worker", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
