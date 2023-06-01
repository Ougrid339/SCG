using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class droupmarketPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TMP_MarketPriceForecast",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TRN_MarketPriceForecast",
                schema: "mbr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_TMP_MarketPriceForecast",
                schema: "mbr",
                columns: table => new
                {
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MarketSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    RunId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_MarketPriceForecast", x => new { x.Case, x.Scenario, x.MarketSource, x.Cycle, x.MonthIndex });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TRN_MarketPriceForecast",
                schema: "mbr",
                columns: table => new
                {
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MarketSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_MarketPriceForecast", x => new { x.Case, x.Scenario, x.MarketSource, x.Cycle, x.MonthIndex });
                });
        }
    }
}
