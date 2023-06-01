using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_feed_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_TMP_FeedInfo",
                schema: "mbr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: false),
                    MonthStatus = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FeedNameKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FeedGeoCategoryKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PricingIndexKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PricingRefKey = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    OriginKey = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ContractCategoryKey = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TransportationKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BuyerRightKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PurchasingVolume = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    PurchasingPremium = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    HedgingGainLoss = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    GITStatus = table.Column<string>(type: "char", nullable: false),
                    Surveyor = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Insurance = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Margin = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    TR = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_FeedInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MBR_TRN_FeedInfo",
                schema: "mbr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scenario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CyclePoly = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RefNo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    MCSC = table.Column<string>(name: "MC/SC", type: "nvarchar(2)", maxLength: 2, nullable: false),
                    MonthStatus = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FeedNameKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FeedGeoCategoryKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SupplierKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PricingIndexKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PricingRefKey = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    OriginKey = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ContractCategoryKey = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TransportationKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BuyerRightKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PurchasingVolume = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    PurchasingPremium = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    HedgingGainLoss = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    GITStatus = table.Column<string>(type: "char", nullable: false),
                    Surveyor = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Insurance = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Margin = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    TR = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MonthIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CopiedFrom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MergedWith = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TRN_FeedInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TMP_FeedInfo",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TRN_FeedInfo",
                schema: "mbr");
        }
    }
}
