using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addSalesVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_TMP_SalesVolume",
                schema: "mbr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MCSC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Month = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Product = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Channel = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ReEXP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FormulaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Customers = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Margin = table.Column<int>(type: "int", nullable: true),
                    TransportationMode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryPort = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Countries = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TermSpot = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PriceSet = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PaymentCondition = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ContractNo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    VesselOrderNo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VolTons = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    HedgingGainLoss = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Alpha1 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Alpha2 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Premium = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    BD = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    IB = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj1 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj2 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj3 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj4 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj5 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_SalesVolume", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBR_TRN_SalesVolume",
                schema: "mbr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MCSC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Month = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Product = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Channel = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ReEXP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FormulaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Customers = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Margin = table.Column<int>(type: "int", nullable: true),
                    TransportationMode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryPort = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Countries = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TermSpot = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PriceSet = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PaymentCondition = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ContractNo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    VesselOrderNo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VolTons = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    HedgingGainLoss = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Alpha1 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Alpha2 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Premium = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    BD = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    IB = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj1 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj2 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj3 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj4 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Adj5 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_SalesVolume", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TMP_SalesVolume",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TRN_SalesVolume",
                schema: "mbr");
        }
    }
}
