using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_col_begin_inventory : Migration
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
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InventoryName",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TankNumber",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InventoryName",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TankNumber",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

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
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "InventoryName",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "TankNumber",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "SupplierKey",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "InventoryName",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "TankNumber",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "ProductShortName", "MonthNo", "MCSC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "ProductShortName", "MonthNo", "MCSC", "RunId" });
        }
    }
}
