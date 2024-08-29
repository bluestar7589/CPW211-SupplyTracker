﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupplyTracker.Data;

#nullable disable

namespace SupplyTracker.Migrations
{
    [DbContext(typeof(SupplyTrackerContext))]
    partial class SupplyTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SupplyTracker.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<int?>("DepartmentCode")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerID")
                        .HasName("PK__Customer__A4AE64B8AEBB0A92");

                    b.HasIndex("DepartmentCode");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SupplyTracker.Models.Department", b =>
                {
                    b.Property<int>("DepartmentCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentCode"));

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DepartmentCode")
                        .HasName("PK__Departme__6EA8896CC8EBCB19");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SupplyTracker.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("InventoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<int?>("ReorderLevel")
                        .HasColumnType("int");

                    b.HasKey("InventoryId")
                        .HasName("PK__Inventor__F5FDE6D3070DA167");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("SupplyTracker.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateOnly?>("DateOfOrder")
                        .HasColumnType("date");

                    b.Property<int?>("VendorId")
                        .HasColumnType("int")
                        .HasColumnName("VendorID");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__C3905BAF7AD07935");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VendorId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SupplyTracker.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId")
                        .HasName("PK__OrderDet__D3B9D30C78AAEEF2");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SupplyTracker.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<DateOnly>("DateOfExpire")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfProduct")
                        .HasColumnType("date");

                    b.Property<string>("LotNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProductCategoryCode")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UnitOfSupply")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VendorCode")
                        .HasColumnType("int");

                    b.HasKey("ProductId")
                        .HasName("PK__Products__B40CC6ED94C999CE");

                    b.HasIndex("ProductCategoryCode");

                    b.HasIndex("VendorCode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SupplyTracker.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryCode"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Purpose")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ProductCategoryCode")
                        .HasName("PK__ProductC__A6C3D9BDFA1B2403");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SupplyTracker.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentId"));

                    b.Property<DateOnly?>("ShipmentDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<int?>("VendorCode")
                        .HasColumnType("int");

                    b.HasKey("ShipmentId")
                        .HasName("PK__Shipment__5CAD378D937708EE");

                    b.HasIndex("VendorCode");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("SupplyTracker.Models.ShipmentDetail", b =>
                {
                    b.Property<int>("ShipmentDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipmentDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentDetailId"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("QuantityLeft")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("([QuantityOrdered]-[QuantityReceived])", false);

                    b.Property<int?>("QuantityOrdered")
                        .HasColumnType("int");

                    b.Property<int?>("QuantityReceived")
                        .HasColumnType("int");

                    b.Property<int?>("ShipmentId")
                        .HasColumnType("int")
                        .HasColumnName("ShipmentID");

                    b.HasKey("ShipmentDetailId")
                        .HasName("PK__Shipment__047142C0984B8DC6");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentDetails");
                });

            modelBuilder.Entity("SupplyTracker.Models.SupplyRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RequestID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<DateOnly?>("DateOfRequest")
                        .HasColumnType("date");

                    b.Property<int?>("DepartmentCode")
                        .HasColumnType("int");

                    b.Property<string>("RequestorName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RequestId")
                        .HasName("PK__SupplyRe__33A8519A988C8C7A");

                    b.HasIndex("DepartmentCode");

                    b.ToTable("SupplyRequests");
                });

            modelBuilder.Entity("SupplyTracker.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime?>("LastDateLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Salt")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID")
                        .HasName("PK__Users__1788CCAC826BF9D5");

                    b.HasIndex(new[] { "Username" }, "UQ__Users__536C85E49408954E")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SupplyTracker.Models.Vendor", b =>
                {
                    b.Property<int>("VendorCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorCode"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("VendorName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VendorCode")
                        .HasName("PK__Vendors__10C18F5D92055247");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("SupplyTracker.Models.Customer", b =>
                {
                    b.HasOne("SupplyTracker.Models.Department", "DepartmentCodeNavigation")
                        .WithMany("Customers")
                        .HasForeignKey("DepartmentCode")
                        .HasConstraintName("FK__Customers__Depar__267ABA7A");

                    b.Navigation("DepartmentCodeNavigation");
                });

            modelBuilder.Entity("SupplyTracker.Models.Inventory", b =>
                {
                    b.HasOne("SupplyTracker.Models.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Inventori__Produ__36B12243");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SupplyTracker.Models.Order", b =>
                {
                    b.HasOne("SupplyTracker.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Orders__Customer__403A8C7D");

                    b.HasOne("SupplyTracker.Models.Vendor", "Vendor")
                        .WithMany("Orders")
                        .HasForeignKey("VendorId")
                        .HasConstraintName("FK__Orders__VendorID__412EB0B6");

                    b.Navigation("Customer");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("SupplyTracker.Models.OrderDetail", b =>
                {
                    b.HasOne("SupplyTracker.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__440B1D61");

                    b.HasOne("SupplyTracker.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__OrderDeta__Produ__44FF419A");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SupplyTracker.Models.Product", b =>
                {
                    b.HasOne("SupplyTracker.Models.ProductCategory", "ProductCategoryCodeNavigation")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Products__Produc__32E0915F");

                    b.HasOne("SupplyTracker.Models.Vendor", "VendorCodeNavigation")
                        .WithMany("Products")
                        .HasForeignKey("VendorCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Products__Vendor__33D4B598");

                    b.Navigation("ProductCategoryCodeNavigation");

                    b.Navigation("VendorCodeNavigation");
                });

            modelBuilder.Entity("SupplyTracker.Models.Shipment", b =>
                {
                    b.HasOne("SupplyTracker.Models.Vendor", "VendorCodeNavigation")
                        .WithMany("Shipments")
                        .HasForeignKey("VendorCode")
                        .HasConstraintName("FK__Shipments__Vendo__398D8EEE");

                    b.Navigation("VendorCodeNavigation");
                });

            modelBuilder.Entity("SupplyTracker.Models.ShipmentDetail", b =>
                {
                    b.HasOne("SupplyTracker.Models.Product", "Product")
                        .WithMany("ShipmentDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ShipmentD__Produ__3D5E1FD2");

                    b.HasOne("SupplyTracker.Models.Shipment", "Shipment")
                        .WithMany("ShipmentDetails")
                        .HasForeignKey("ShipmentId")
                        .HasConstraintName("FK__ShipmentD__Shipm__3C69FB99");

                    b.Navigation("Product");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("SupplyTracker.Models.SupplyRequest", b =>
                {
                    b.HasOne("SupplyTracker.Models.Department", "DepartmentCodeNavigation")
                        .WithMany("SupplyRequests")
                        .HasForeignKey("DepartmentCode")
                        .HasConstraintName("FK__SupplyReq__Depar__29572725");

                    b.Navigation("DepartmentCodeNavigation");
                });

            modelBuilder.Entity("SupplyTracker.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SupplyTracker.Models.Department", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("SupplyRequests");
                });

            modelBuilder.Entity("SupplyTracker.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SupplyTracker.Models.Product", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("OrderDetails");

                    b.Navigation("ShipmentDetails");
                });

            modelBuilder.Entity("SupplyTracker.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SupplyTracker.Models.Shipment", b =>
                {
                    b.Navigation("ShipmentDetails");
                });

            modelBuilder.Entity("SupplyTracker.Models.Vendor", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Shipments");
                });
#pragma warning restore 612, 618
        }
    }
}
