using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addOptience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_TRN_BeginningInventory",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ProductShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_BeginningInventory", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.ProductShortName, x.MonthIndex });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TRN_FeedConsumption",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FeedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    FeedShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElementCodeEBA = table.Column<string>(name: "ElementCode(EBA)", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_FeedConsumption", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.FeedName, x.MonthIndex });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TRN_FeedPurchase",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FeedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    FeedShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElementCodeEBA = table.Column<string>(name: "ElementCode(EBA)", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_FeedPurchase", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.FeedName, x.MonthIndex });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TRN_ProductionVolume",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ProductShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElementCodeEBA = table.Column<string>(name: "ElementCode(EBA)", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_ProductionVolume", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.ProductName, x.MonthIndex });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TRN_BeginningInventory",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TRN_FeedConsumption",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TRN_FeedPurchase",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TRN_ProductionVolume",
                schema: "mbr");
        }
    }
}
