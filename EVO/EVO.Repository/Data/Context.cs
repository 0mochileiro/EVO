using EVO.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EVO.Repository.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<InvoiceServices> InvoiceServices { get; set; }
    public virtual DbSet<ServiceByInvoice> ServiceByInvoice { get; set; }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<UserAccessLevelDomain> UserAccessLevelDomain { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Comments)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByUserNavigation)
                .WithMany(p => p.Customer)
                .HasForeignKey(d => d.CreatedByUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Customer_User_CreatedByUser");
        });

        modelBuilder.Entity<InvoiceServices>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.Property(e => e.Montante).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.ApprovedByUserNavigation)
                .WithMany(p => p.InvoiceServicesApprovedByUserNavigation)
                .HasForeignKey(d => d.ApprovedByUser)
                .HasConstraintName("Fk_InvoiceServices_User_ApprovedByUser");

            entity.HasOne(d => d.CreatedByUserNavigation)
                .WithMany(p => p.InvoiceServicesCreatedByUserNavigation)
                .HasForeignKey(d => d.CreatedByUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_InvoiceServices_User_CreatedByUser");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.InvoiceServices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_InvoiceServices_Customer_CustomerID");
        });

        modelBuilder.Entity<ServiceByInvoice>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Amount).HasColumnType("decimal(9, 2)");

            entity.Property(e => e.Details)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.InvoiceServicesId).HasColumnName("InvoiceServicesID");

            entity.HasOne(d => d.CreatedByUserNavigation)
                .WithMany(p => p.ServiceByInvoice)
                .HasForeignKey(d => d.CreatedByUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_ServiceByInvoice_User_CreatedByUser");

            entity.HasOne(d => d.InvoiceServices)
                .WithMany(p => p.ServiceByInvoice)
                .HasForeignKey(d => d.InvoiceServicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_ServiceByInvoice_InvoiceServices_InvoiceServicesID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.AccessLevelId).HasColumnName("AccessLevelID");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(300);

            entity.HasOne(d => d.AccessLevel)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.AccessLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UserAccessLevelDomain>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Department)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.Function)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
