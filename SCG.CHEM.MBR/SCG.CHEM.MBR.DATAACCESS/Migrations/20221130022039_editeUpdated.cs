using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class editeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                newName: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                newName: "UpdateBy");
        }
    }
}
