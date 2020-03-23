using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace beaverNet.POS.WebApp.Data.Migrations
{
    public partial class POSintegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PriceSell = table.Column<decimal>(nullable: false),
                    PricePurchase = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    SalesOrderId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SalesOrderDate = table.Column<DateTimeOffset>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvenTran",
                columns: table => new
                {
                    InvenTranId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    TranSourceId = table.Column<Guid>(nullable: false),
                    TranSourceNumber = table.Column<string>(nullable: true),
                    TranSourceType = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    InvenTranDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvenTran", x => x.InvenTranId);
                    table.ForeignKey(
                        name: "FK_InvenTran_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PurchaseOrderDate = table.Column<DateTimeOffset>(nullable: true),
                    VendorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderLine",
                columns: table => new
                {
                    SalesOrderLineId = table.Column<Guid>(nullable: false),
                    SalesOrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLine", x => x.SalesOrderLineId);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceive",
                columns: table => new
                {
                    GoodsReceiveId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GoodsReceiveDate = table.Column<DateTimeOffset>(nullable: true),
                    PurchaseOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceive", x => x.GoodsReceiveId);
                    table.ForeignKey(
                        name: "FK_GoodsReceive_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLine",
                columns: table => new
                {
                    PurchaseOrderLineId = table.Column<Guid>(nullable: false),
                    PurchaseOrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLine", x => x.PurchaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLine_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLine_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceiveLine",
                columns: table => new
                {
                    GoodsReceiveLineId = table.Column<Guid>(nullable: false),
                    GoodsReceiveId = table.Column<Guid>(nullable: false),
                    PurchaseOrderLineId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    QtyPurchase = table.Column<int>(nullable: false),
                    QtyReceive = table.Column<int>(nullable: false),
                    QtyReceived = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiveLine", x => x.GoodsReceiveLineId);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveLine_GoodsReceive_GoodsReceiveId",
                        column: x => x.GoodsReceiveId,
                        principalTable: "GoodsReceive",
                        principalColumn: "GoodsReceiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveLine_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceive_PurchaseOrderId",
                table: "GoodsReceive",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveLine_GoodsReceiveId",
                table: "GoodsReceiveLine",
                column: "GoodsReceiveId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveLine_ProductId",
                table: "GoodsReceiveLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvenTran_ProductId",
                table: "InvenTran",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_VendorId",
                table: "PurchaseOrder",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLine_ProductId",
                table: "PurchaseOrderLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLine_PurchaseOrderId",
                table: "PurchaseOrderLine",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerId",
                table: "SalesOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_ProductId",
                table: "SalesOrderLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_SalesOrderId",
                table: "SalesOrderLine",
                column: "SalesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceiveLine");

            migrationBuilder.DropTable(
                name: "InvenTran");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLine");

            migrationBuilder.DropTable(
                name: "SalesOrderLine");

            migrationBuilder.DropTable(
                name: "GoodsReceive");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
