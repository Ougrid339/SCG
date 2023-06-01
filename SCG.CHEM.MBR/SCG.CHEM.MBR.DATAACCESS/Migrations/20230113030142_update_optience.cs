using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_optience : Migration
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
    }
}
