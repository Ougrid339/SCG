using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addTmpOptience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MBR_TMP_BeginningInventory",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ProductShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_BeginningInventory", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.ProductShortName, x.MonthIndex });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_FeedConsumption",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FeedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    FeedShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElementCodeEBA = table.Column<string>(name: "ElementCode(EBA)", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_FeedConsumption", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.FeedName, x.MonthIndex });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_FeedPurchase",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FeedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    FeedShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElementCodeEBA = table.Column<string>(name: "ElementCode(EBA)", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_FeedPurchase", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.FeedName, x.MonthIndex });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_ProductionVolume",
                schema: "mbr",
                columns: table => new
                {
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ProductShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElementCodeEBA = table.Column<string>(name: "ElementCode(EBA)", type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_ProductionVolume", x => new { x.Case, x.Scenario, x.Company, x.Cycle, x.ProductName, x.MonthIndex });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TMP_BeginningInventory",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_FeedConsumption",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_FeedPurchase",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_ProductionVolume",
                schema: "mbr");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");
        }
    }
}
