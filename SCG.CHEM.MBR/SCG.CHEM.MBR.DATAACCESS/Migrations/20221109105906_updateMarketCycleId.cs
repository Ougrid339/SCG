using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class updateMarketCycleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_TRN_MarketPriceForcase",
                schema: "mbr",
                columns: table => new
                {
                    ScenarioId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    CycleId = table.Column<int>(type: "int", nullable: false),
                    MARKET_SOURCE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    M0 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M1 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M2 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M3 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M4 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M5 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M6 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M7 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M8 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M9 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M10 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M11 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M12 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M13 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M14 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M15 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M16 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M17 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M18 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_MarketPriceForcase", x => new { x.CaseId, x.ScenarioId, x.MARKET_SOURCE, x.CycleId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TRN_MarketPriceForcase",
                schema: "mbr");
        }
    }
}
