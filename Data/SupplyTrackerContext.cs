using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SupplyTracker.Models;

namespace SupplyTracker.Data;

public partial class SupplyTrackerContext : DbContext
{
    public SupplyTrackerContext()
    {
    }

    public SupplyTrackerContext(DbContextOptions<SupplyTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }

    public virtual DbSet<SupplyRequest> SupplyRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SupplyTracker");
        optionsBuilder.LogTo(message => Debug.WriteLine(message), new[] { DbLoggerCategory.Query.Name });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8AEBB0A92");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Position).HasMaxLength(50);

            entity.HasOne(d => d.DepartmentCodeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.DepartmentCode)
                .HasConstraintName("FK__Customers__Depar__267ABA7A");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentCode).HasName("PK__Departme__6EA8896CC8EBCB19");

            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6D3070DA167");

            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventori__Produ__36B12243");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF7AD07935");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__403A8C7D");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Orders__VendorID__412EB0B6");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C78AAEEF2");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__440B1D61");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__44FF419A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED94C999CE");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.LotNumber).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.UnitOfSupply).HasMaxLength(50);

            entity.HasOne(d => d.ProductCategoryCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryCode)
                .HasConstraintName("FK__Products__Produc__32E0915F");

            entity.HasOne(d => d.VendorCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendorCode)
                .HasConstraintName("FK__Products__Vendor__33D4B598");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryCode).HasName("PK__ProductC__A6C3D9BDFA1B2403");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Purpose).HasMaxLength(255);
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("PK__Shipment__5CAD378D937708EE");

            entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.VendorCodeNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.VendorCode)
                .HasConstraintName("FK__Shipments__Vendo__398D8EEE");
        });

        modelBuilder.Entity<ShipmentDetail>(entity =>
        {
            entity.HasKey(e => e.ShipmentDetailId).HasName("PK__Shipment__047142C0984B8DC6");

            entity.Property(e => e.ShipmentDetailId).HasColumnName("ShipmentDetailID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.QuantityLeft).HasComputedColumnSql("([QuantityOrdered]-[QuantityReceived])", false);
            entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");

            entity.HasOne(d => d.Product).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ShipmentD__Produ__3D5E1FD2");

            entity.HasOne(d => d.Shipment).WithMany(p => p.ShipmentDetails)
                .HasForeignKey(d => d.ShipmentId)
                .HasConstraintName("FK__ShipmentD__Shipm__3C69FB99");
        });

        modelBuilder.Entity<SupplyRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__SupplyRe__33A8519A988C8C7A");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.RequestorName).HasMaxLength(100);

            entity.HasOne(d => d.DepartmentCodeNavigation).WithMany(p => p.SupplyRequests)
                .HasForeignKey(d => d.DepartmentCode)
                .HasConstraintName("FK__SupplyReq__Depar__29572725");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__Users__1788CCAC826BF9D5");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E49408954E").IsUnique();

            entity.Property(e => e.UserID).HasColumnName("UserID");
            entity.Property(e => e.LastDateLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorCode).HasName("PK__Vendors__10C18F5D92055247");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.VendorName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
