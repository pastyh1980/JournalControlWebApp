using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JournalControlWebApp.Models.dbo
{
    public partial class journalContext : IdentityDbContext<Worker, Role, int>
    {
        public journalContext()
        {
        }

        public journalContext(DbContextOptions<journalContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<Subunit> Subunits { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=journal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Check>(entity =>
            {
                entity.ToTable("check");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckDate)
                    .HasColumnName("check_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckWorker)
                    .IsRequired()
                    .HasColumnName("check_worker")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ControlIndicator)
                    .IsRequired()
                    .HasColumnName("control_indicator")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CountOperations).HasColumnName("count_operations");

                entity.Property(e => e.DeleteDate)
                    .HasColumnName("delete_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteWorker).HasColumnName("delete_worker");

                entity.Property(e => e.FailCount)
                    .IsRequired()
                    .HasColumnName("fail_count")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FailDescription)
                    .IsRequired()
                    .HasColumnName("fail_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");

                entity.Property(e => e.IsFail).HasColumnName("isFail");

                entity.Property(e => e.RegDate)
                    .HasColumnName("reg_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegWorker).HasColumnName("reg_worker");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.Property(e => e.TdKd)
                    .IsRequired()
                    .HasColumnName("td_kd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeleteWorkerNavigation)
                    .WithMany(p => p.CheckDeleteWorkerNavigation)
                    .HasForeignKey(d => d.DeleteWorker)
                    .HasConstraintName("FK_delete_worker");

                entity.HasOne(d => d.RegWorkerNavigation)
                    .WithMany(p => p.CheckRegWorkerNavigation)
                    .HasForeignKey(d => d.RegWorker)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reg_worker");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Check)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_check_sector");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckId).HasColumnName("check_id");

                entity.Property(e => e.DeleteDate)
                    .HasColumnName("delete_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteWorker).HasColumnName("delete_worker");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DevelopDate)
                    .HasColumnName("develop_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Developer).HasColumnName("developer");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.FailReason)
                    .HasColumnName("fail_reason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");

                entity.Property(e => e.ProofInf)
                    .HasColumnName("proof_inf")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDate)
                    .HasColumnName("report_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportWorker).HasColumnName("report_worker");

                entity.Property(e => e.ResponsWorker)
                    .IsRequired()
                    .HasColumnName("respons_worker")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Check)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CheckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_events_check");

                entity.HasOne(d => d.DeleteWorkerNavigation)
                    .WithMany(p => p.EventsDeleteWorkerNavigation)
                    .HasForeignKey(d => d.DeleteWorker)
                    .HasConstraintName("FK_events_delete_worker");

                entity.HasOne(d => d.DeveloperNavigation)
                    .WithMany(p => p.EventsDeveloperNavigation)
                    .HasForeignKey(d => d.Developer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_events_developer");

                entity.HasOne(d => d.ReportWorkerNavigation)
                    .WithMany(p => p.EventsReportWorkerNavigation)
                    .HasForeignKey(d => d.ReportWorker)
                    .HasConstraintName("FK_events_report_worker");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("sectors");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsMain).HasColumnName("is_main");

                entity.Property(e => e.SectorName)
                    .IsRequired()
                    .HasColumnName("sector")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubunitId).HasColumnName("subunit_id");

                entity.HasOne(d => d.Subunit)
                    .WithMany(p => p.Sectors)
                    .HasForeignKey(d => d.SubunitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sector_subunit");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.ToTable("shows");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckId).HasColumnName("check_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.Check)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.CheckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shows_check");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shows_workers");
            });

            modelBuilder.Entity<Subunit>(entity =>
            {
                entity.ToTable("Subunits");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("workers");

                entity.Property(e => e.Id).HasColumnName("id");
                
                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasColumnName("family")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Otch)
                    .IsRequired()
                    .HasColumnName("otch")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasColumnName("post")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsFirstLogin)
                    .IsRequired()
                    .HasColumnName("is_first_login");

                entity.Property(e => e.SectorId).HasColumnName("sector_id");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_worker_sector");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
