﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace automobileManagementSystem.Model;

public partial class AutomobileManagementDbContext : DbContext
{
    public AutomobileManagementDbContext()
    {
    }

    public AutomobileManagementDbContext(DbContextOptions<AutomobileManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutoPart> AutoParts { get; set; }

    public virtual DbSet<CarModel> CarModels { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CompatibleCarModel> CompatibleCarModels { get; set; }

    public virtual DbSet<ManufacturingCompany> ManufacturingCompanies { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source =DESKTOP-9KHVLG5\\SQLEXPRESS; Initial Catalog = AutomobileManagementDB; Integrated Security = True;\nTrusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutoPart>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__AutoPart__7C3F0D30FF725C1D");

            entity.ToTable("AutoPart");

            entity.HasIndex(e => e.Code, "UQ__AutoPart__A25C5AA75C52A545").IsUnique();

            entity.Property(e => e.PartId).HasColumnName("PartID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.AutoParts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AutoPart__Catego__3F466844");

            entity.HasOne(d => d.Company).WithMany(p => p.AutoParts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AutoPart__Compan__403A8C7D");
        });

        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.HasKey(e => e.CarModelId).HasName("PK__CarModel__C585C36F413FFF67");

            entity.ToTable("CarModel");

            entity.Property(e => e.CarModelId).HasColumnName("CarModelID");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B60A62DA0");

            entity.ToTable("Category");

            entity.HasIndex(e => e.Name, "UQ__Category__737584F6364F5502").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CompatibleCarModel>(entity =>
        {
            entity.HasKey(e => e.CompatibilityId).HasName("PK__Compatib__D56A70CB6D2976A5");

            entity.Property(e => e.CompatibilityId).HasColumnName("CompatibilityID");
            entity.Property(e => e.CarModelId).HasColumnName("CarModelID");
            entity.Property(e => e.PartId).HasColumnName("PartID");

            entity.HasOne(d => d.CarModel).WithMany(p => p.CompatibleCarModels)
                .HasForeignKey(d => d.CarModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compatibl__CarMo__440B1D61");

            entity.HasOne(d => d.Part).WithMany(p => p.CompatibleCarModels)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compatibl__PartI__4316F928");
        });

        modelBuilder.Entity<ManufacturingCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Manufact__2D971C4C3E9014C8");

            entity.ToTable("ManufacturingCompany");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
