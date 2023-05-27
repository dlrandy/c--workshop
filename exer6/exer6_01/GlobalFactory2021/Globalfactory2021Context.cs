using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exer6_01.GlobalFactory2021;

public partial class Globalfactory2021Context : DbContext
{
    public Globalfactory2021Context()
    {
    }

    public Globalfactory2021Context(DbContextOptions<Globalfactory2021Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        {
            optionsBuilder.LogTo((s)=>Debug.WriteLine(s));
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=globalfactory2021Context");
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("manufacturer_pkey");

            entity.ToTable("manufacturer", "factory");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.FoundedAt)
                .HasColumnType("date");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product", "factory");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Manufacturerid).HasColumnName("manufacturerid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            // entity.Property(e => e.Price)
            //     .HasColumnType("money")
            //     .HasColumnName("price");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.Manufacturerid)
                .HasConstraintName("product_manufacturerid_id");
        });

        modelBuilder.Entity<ProductPriceHistory>(entity =>
        {
            entity.ToTable("ProductPriceHistory", "factory");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.DateOfPrice).HasColumnType("date");
            RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder)entity.HasOne(d=>d.Product).WithMany(p=>p.PriceHistory).HasForeignKey(d=>d.ProductId),"FK_ProductPriceHistory_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
