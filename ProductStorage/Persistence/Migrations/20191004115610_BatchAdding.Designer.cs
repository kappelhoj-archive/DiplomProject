﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(StorageDbContext))]
    [Migration("20191004115610_BatchAdding")]
    partial class BatchAdding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Batch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.HasKey("Id");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("Domain.ProductAddition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("ProductBatchId");

                    b.Property<int>("Reason");

                    b.HasKey("Id");

                    b.HasIndex("ProductBatchId");

                    b.ToTable("AdditionEvents");
                });

            modelBuilder.Entity("Domain.ProductBatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<Guid>("BatchId");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.ToTable("ProductBatches");
                });

            modelBuilder.Entity("Domain.ProductRemoval", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("ProductBatchId");

                    b.Property<int>("Reason");

                    b.HasKey("Id");

                    b.HasIndex("ProductBatchId");

                    b.ToTable("RemovalEvents");
                });

            modelBuilder.Entity("Domain.ProductAddition", b =>
                {
                    b.HasOne("Domain.ProductBatch", "ProductBatch")
                        .WithMany()
                        .HasForeignKey("ProductBatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.ProductBatch", b =>
                {
                    b.HasOne("Domain.Batch", "Batch")
                        .WithMany("Products")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.ProductRemoval", b =>
                {
                    b.HasOne("Domain.ProductBatch", "ProductBatch")
                        .WithMany()
                        .HasForeignKey("ProductBatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
