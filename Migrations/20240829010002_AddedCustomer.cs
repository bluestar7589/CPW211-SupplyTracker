using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__6EA8896CC8EBCB19", x => x.DepartmentCode);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductC__A6C3D9BDFA1B2403", x => x.ProductCategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastDateLogin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC826BF9D5", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vendors__10C18F5D92055247", x => x.VendorCode);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentCode = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B8AEBB0A92", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK__Customers__Depar__267ABA7A",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode");
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentCode = table.Column<int>(type: "int", nullable: true),
                    DateOfRequest = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SupplyRe__33A8519A988C8C7A", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK__SupplyReq__Depar__29572725",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UnitOfSupply = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfProduct = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfExpire = table.Column<DateOnly>(type: "date", nullable: false),
                    ProductCategoryCode = table.Column<int>(type: "int", nullable: false),
                    VendorCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__B40CC6ED94C999CE", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK__Products__Produc__32E0915F",
                        column: x => x.ProductCategoryCode,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Products__Vendor__33D4B598",
                        column: x => x.VendorCode,
                        principalTable: "Vendors",
                        principalColumn: "VendorCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorCode = table.Column<int>(type: "int", nullable: true),
                    ShipmentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipment__5CAD378D937708EE", x => x.ShipmentID);
                    table.ForeignKey(
                        name: "FK__Shipments__Vendo__398D8EEE",
                        column: x => x.VendorCode,
                        principalTable: "Vendors",
                        principalColumn: "VendorCode");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    VendorID = table.Column<int>(type: "int", nullable: true),
                    DateOfOrder = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BAF7AD07935", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__Customer__403A8C7D",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Orders__VendorID__412EB0B6",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorCode");
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    QuantityInStock = table.Column<int>(type: "int", nullable: true),
                    ReorderLevel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventor__F5FDE6D3070DA167", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK__Inventori__Produ__36B12243",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "ShipmentDetails",
                columns: table => new
                {
                    ShipmentDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    QuantityOrdered = table.Column<int>(type: "int", nullable: true),
                    QuantityReceived = table.Column<int>(type: "int", nullable: true),
                    QuantityLeft = table.Column<int>(type: "int", nullable: true, computedColumnSql: "([QuantityOrdered]-[QuantityReceived])", stored: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shipment__047142C0984B8DC6", x => x.ShipmentDetailID);
                    table.ForeignKey(
                        name: "FK__ShipmentD__Produ__3D5E1FD2",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK__ShipmentD__Shipm__3C69FB99",
                        column: x => x.ShipmentID,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__D3B9D30C78AAEEF2", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__440B1D61",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Produ__44FF419A",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DepartmentCode",
                table: "Customers",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductID",
                table: "Inventories",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VendorID",
                table: "Orders",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryCode",
                table: "Products",
                column: "ProductCategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorCode",
                table: "Products",
                column: "VendorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_ProductID",
                table: "ShipmentDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_ShipmentID",
                table: "ShipmentDetails",
                column: "ShipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_VendorCode",
                table: "Shipments",
                column: "VendorCode");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequests_DepartmentCode",
                table: "SupplyRequests",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__536C85E49408954E",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShipmentDetails");

            migrationBuilder.DropTable(
                name: "SupplyRequests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
