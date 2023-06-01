using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_supplier_code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Cycle", "ProductShortName", "MonthNo", "MCSC", "MaterialCode", "SupplierCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Cycle", "ProductShortName", "MonthNo", "MCSC", "RunId", "MaterialCode", "SupplierCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Cycle", "ProductShortName", "MonthNo", "MCSC", "MaterialCode", "SupplierKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Cycle", "ProductShortName", "MonthNo", "MCSC", "RunId", "MaterialCode", "SupplierKey" });
        }
    }
}
