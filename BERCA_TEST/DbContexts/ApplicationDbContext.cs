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

                entity.Property(e => e.CollectionAmmountForeign)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionAmmountIdr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
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

                entity.Property(e => e.Rate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.InvoiceNo)
                    .HasConstraintName("FK__Collectio__Invoi__3B75D760");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Currency");

                entity.Property(e => e.Currency1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Currency");

                entity.Property(e => e.EffectiveDate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasMaxLength(25)
                    .IsUnicode(false);
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
                    .HasName("PK__Invoice__D796B2260EC9C74A");

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

                entity.Property(e => e.InvoiceAmmountForeign)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceAmmountIdr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("InvoiceAmmountIDR");

                entity.Property(e => e.InvoiceDate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OpenAmmountForeign)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OpenAmmountIdr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OpenAmmountIDR");

                entity.Property(e => e.Rate)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Remark).IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoice__Custome__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
