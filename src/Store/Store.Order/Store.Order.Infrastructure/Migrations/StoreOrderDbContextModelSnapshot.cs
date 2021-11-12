﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Store.Order.Infrastructure;

#nullable disable

namespace Store.Order.Infrastructure.Migrations
{
    [DbContext(typeof(StoreOrderDbContext))]
    partial class StoreOrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Store.Core.Infrastructure.EntityFramework.Entity.SubscriptionCheckpointEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Position")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("position");

                    b.Property<string>("SubscriptionId")
                        .HasColumnType("text")
                        .HasColumnName("subscription_id");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("subscription_checkpoint", "public");
                });

            modelBuilder.Entity("Store.Order.Infrastructure.Entity.CartEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("text")
                        .HasColumnName("customer_number");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb")
                        .HasColumnName("data");

                    b.HasKey("Id");

                    b.ToTable("cart", "public");
                });

            modelBuilder.Entity("Store.Order.Infrastructure.Entity.CartEntryEntity", b =>
                {
                    b.Property<string>("CatalogueNumber")
                        .HasColumnType("text");

                    b.ToTable("CartEntryEntity", "public");
                });

            modelBuilder.Entity("Store.Order.Infrastructure.Entity.OrderDisplayEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb")
                        .HasColumnName("data");

                    b.HasKey("Id");

                    b.ToTable("order_display", "public");
                });
#pragma warning restore 612, 618
        }
    }
}
