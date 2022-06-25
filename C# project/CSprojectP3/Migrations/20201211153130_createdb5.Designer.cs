﻿// <auto-generated />
using System;
using CSprojectP3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSprojectP3.Migrations
{
    [DbContext(typeof(Mycontext))]
    [Migration("20201211153130_createdb5")]
    partial class createdb5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CSprojectP3.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Customer");
                });

            modelBuilder.Entity("CSprojectP3.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date1")
                        .HasColumnType("datetime2");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CSprojectP3.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Inventory_Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CSprojectP3.TransactionItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("transactionItems");
                });

            modelBuilder.Entity("CSprojectP3.Company", b =>
                {
                    b.HasBaseType("CSprojectP3.Customer");

                    b.Property<string>("CompanyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("CSprojectP3.User", b =>
                {
                    b.HasBaseType("CSprojectP3.Customer");

                    b.Property<string>("sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("CSprojectP3.Order", b =>
                {
                    b.HasOne("CSprojectP3.Customer", "Customer")
                        .WithMany("OrderList")
                        .HasForeignKey("CustomerID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CSprojectP3.TransactionItem", b =>
                {
                    b.HasOne("CSprojectP3.Order", "Order")
                        .WithMany("TItems")
                        .HasForeignKey("OrderID");

                    b.HasOne("CSprojectP3.Product", "Product")
                        .WithOne("transactionItem")
                        .HasForeignKey("CSprojectP3.TransactionItem", "ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CSprojectP3.Customer", b =>
                {
                    b.Navigation("OrderList");
                });

            modelBuilder.Entity("CSprojectP3.Order", b =>
                {
                    b.Navigation("TItems");
                });

            modelBuilder.Entity("CSprojectP3.Product", b =>
                {
                    b.Navigation("transactionItem");
                });
#pragma warning restore 612, 618
        }
    }
}
