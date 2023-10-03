﻿// <auto-generated />
using System;
using BikeRentalSystem.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeRentalSystem.Server.Data.Migrations
{
    [DbContext(typeof(BikeRentalSystemDbContext))]
    [Migration("20231003200116_AddBaseAuditableEntity")]
    partial class AddBaseAuditableEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.Bikes.Bike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<string>("ThumbnailImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Type");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Type"), false);

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.Customers.Customer", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<uint>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.RentOrders.LineItem", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<uint>("Id"));

                    b.Property<Guid>("BikeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<uint>("RentOrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.HasIndex("RentOrderId");

                    b.ToTable("LineItems", t =>
                        {
                            t.HasCheckConstraint("CK_LineItem_Quantity", "[Quantity] > 0");
                        });
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.RentOrders.RentOrder", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<uint>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<uint>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Total")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("RentOrders");
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.Customers.Customer", b =>
                {
                    b.OwnsOne("BikeRentalSystem.Server.Data.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<uint>("CustomerId")
                                .HasColumnType("bigint");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long>("HouseNumber")
                                .HasColumnType("bigint");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("BikeRentalSystem.Server.Data.ValueObjects.PhoneNumber", "Phone", b1 =>
                        {
                            b1.Property<uint>("CustomerId")
                                .HasColumnType("bigint");

                            b1.Property<long>("CountryCode")
                                .HasColumnType("bigint");

                            b1.Property<string>("InternationalPrefix")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long>("LocalNumber")
                                .HasColumnType("bigint");

                            b1.Property<long>("NationalPrefix")
                                .HasColumnType("bigint");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.RentOrders.LineItem", b =>
                {
                    b.HasOne("BikeRentalSystem.Server.Data.Entities.Bikes.Bike", "Bike")
                        .WithMany("LineItems")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeRentalSystem.Server.Data.Entities.RentOrders.RentOrder", "RentOrder")
                        .WithMany("LineItems")
                        .HasForeignKey("RentOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");

                    b.Navigation("RentOrder");
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.RentOrders.RentOrder", b =>
                {
                    b.HasOne("BikeRentalSystem.Server.Data.Entities.Customers.Customer", "Customer")
                        .WithMany("RentOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.Bikes.Bike", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.Customers.Customer", b =>
                {
                    b.Navigation("RentOrders");
                });

            modelBuilder.Entity("BikeRentalSystem.Server.Data.Entities.RentOrders.RentOrder", b =>
                {
                    b.Navigation("LineItems");
                });
#pragma warning restore 612, 618
        }
    }
}