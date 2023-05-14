﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using exer6_01.GlobalFactory2021;

#nullable disable

namespace exer6_01.Migrations
{
    [DbContext(typeof(Globalfactory2021Context))]
    [Migration("20230507101012_MyFirstMigration")]
    partial class MyFirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("exer6_01.GlobalFactory2021.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("country");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("manufacturer_pkey");

                    b.ToTable("manufacturer", "factory");
                });

            modelBuilder.Entity("exer6_01.GlobalFactory2021.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("Manufacturerid")
                        .HasColumnType("integer")
                        .HasColumnName("manufacturerid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("product_pkey");

                    b.HasIndex("Manufacturerid");

                    b.ToTable("product", "factory");
                });

            modelBuilder.Entity("exer6_01.GlobalFactory2021.Product", b =>
                {
                    b.HasOne("exer6_01.GlobalFactory2021.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("Manufacturerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("product_manufacturerid_id");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("exer6_01.GlobalFactory2021.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
