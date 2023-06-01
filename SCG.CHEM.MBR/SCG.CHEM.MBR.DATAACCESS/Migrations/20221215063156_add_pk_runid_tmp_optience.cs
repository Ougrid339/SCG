using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_pk_runid_tmp_optience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductName", "MonthIndex", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductShortName", "MonthIndex", "MC/SC", "RunId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductShortName", "MonthIndex", "MC/SC" });
        }
    }
}
