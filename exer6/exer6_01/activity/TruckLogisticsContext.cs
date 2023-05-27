// using System;
// using System.Diagnostics;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using Microsoft.EntityFrameworkCore.Migrations;
// using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
// namespace Exer06.activity;

// public partial class TruckLogisticsContext : DbContext
// {
//     public TruckLogisticsContext()
//     {
//     }

//     public TruckLogisticsContext(DbContextOptions<TruckLogisticsContext> options)
//         : base(options)
//     {
//     }

//     public virtual DbSet<Person> People { get; set; }

//     public virtual DbSet<Truck> Trunks { get; set; }
//     public virtual DbSet<TruckDispatch> TrunkDispatches { get; set; }
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//     {
//         optionsBuilder.LogTo((s) => Debug.WriteLine(s));
//         optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=TruckLogistics");
//     }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Person>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK_Person");

//             entity.ToTable("Person", "TruckLogistics");

//             entity.Property(e => e.Id)
//                 .UseIdentityAlwaysColumn()
//                 .HasColumnName("id");
//             entity.Property(e => e.Name)
//                 .HasMaxLength(300)
//                 .HasColumnName("name");
//             entity.Property(e => e.DoB)
//                 .HasColumnType("date")
//                 .HasColumnName("DoB");
//         });

//         modelBuilder.Entity<Truck>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK_Truck");

//             entity.ToTable("Truck", "TruckLogistics");

//             entity.Property(e => e.Id)
//                 .UseIdentityAlwaysColumn()
//                 .HasColumnName("id");
//             entity.Property(e => e.Brand).HasColumnName("brand");
//             entity.Property(e => e.Model)
//                 .HasMaxLength(50)
//                 .HasColumnName("name");
//             entity.Property(e => e.YearOfMaking)
//                 .HasColumnType("money")
//                 .HasColumnName("YearOfMaking");
//         });

//         modelBuilder.Entity<TruckDispatch>(entity =>
//         {
//             entity.ToTable("TruckDispatch", "TruckLogistics");
//             entity.Property(e => e.Id)
//                 .UseIdentityAlwaysColumn()
//                 .HasColumnName("id");
//             // entity.Property(e => e.DriverId).HasColumnType("integer");
//             // entity.Property(e => e.TruckId).HasColumnType("integer");
//             entity.Property(e => e.CurrentLocation)
//             .HasMaxLength(200)
//             .HasColumnName("CurrentLocation");
//             entity.Property(e => e.Deadline)
//     .HasColumnType("date")
//     .HasColumnName("Deadline");
    
//             entity.HasOne(d => d.Truck).WithMany(t =>t.)
//                 .HasForeignKey(d => d.Manufacturerid)
//                 .HasConstraintName("product_manufacturerid_id");
//             RelationalForeignKeyBuilderExtensions.HasConstraintName((ReferenceCollectionBuilder)entity.HasOne(d => d.Truck).WithMany(t => t.).HasForeignKey(d => d.ProductId), "FK_TruckDispatch_Truck_TruckId");
//         });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

// }
