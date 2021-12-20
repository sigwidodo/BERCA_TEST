using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BERCA_TEST.Models;

#nullable disable

namespace BERCA_TEST.DbContexts
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("Collection");

                entity.Property(e => e.CollectionId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CollectionID");

                entity.Property(e => e.CollectionAmmountForeign).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CollectionAmmountIdr)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("CollectionAmmountIDR");

                entity.Property(e => e.CollectionDate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.InvoiceNo)
                    .HasConstraintName("FK__Collectio__Invoi__02FC7413");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => new { e.Currency1, e.EffectiveDate })
                    .HasName("PK__Currency__AFC4E285F507D7FB");

                entity.ToTable("Currency");

                entity.Property(e => e.Currency1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Currency");

                entity.Property(e => e.EffectiveDate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Topdays).HasColumnName("TOPDays");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo)
                    .HasName("PK__Invoice__D796B2265EB16E4A");

                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DueDate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceAmmountForeign).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceAmmountIdr)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("InvoiceAmmountIDR");

                entity.Property(e => e.InvoiceDate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OpenAmmountForeign).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OpenAmmountIdr)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("OpenAmmountIDR");

                entity.Property(e => e.Rate).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Remark).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
