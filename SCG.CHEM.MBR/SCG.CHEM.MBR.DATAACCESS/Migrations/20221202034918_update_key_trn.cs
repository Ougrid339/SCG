using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_key_trn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

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

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductShortName", "MonthIndex", "MC/SC" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

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

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductName", "MonthIndex" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductShortName", "MonthIndex" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductName", "MonthIndex" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductShortName", "MonthIndex" });
        }
    }
}
