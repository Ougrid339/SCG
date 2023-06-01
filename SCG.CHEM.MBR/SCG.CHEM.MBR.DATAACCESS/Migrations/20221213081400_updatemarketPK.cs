using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class updatemarketPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_TMP_MarketPriceForecast",
                schema: "mbr",
                columns: table => new
                {
                    PlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MarketSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CopiedFromCycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWithCycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CopiedFromPlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MergedWithPlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CopiedFromCase = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MergedWithCase = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RunId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_MarketPriceForecast", x => new { x.Case, x.PlanType, x.MarketSource, x.Cycle, x.MonthNo });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TRN_MarketPriceForecast",
                schema: "mbr",
                columns: table => new
                {
                    PlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MarketSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CopiedFromCycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWithCycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CopiedFromPlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MergedWithPlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CopiedFromCase = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MergedWithCase = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_MarketPriceForecast", x => new { x.Case, x.PlanType, x.MarketSource, x.Cycle, x.MonthNo });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TMP_MarketPriceForecast",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TRN_MarketPriceForecast",
                schema: "mbr");
        }
    }
}
