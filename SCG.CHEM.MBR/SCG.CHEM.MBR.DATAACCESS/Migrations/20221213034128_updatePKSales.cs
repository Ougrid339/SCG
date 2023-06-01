using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class updatePKSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MonthIndex", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MonthIndex", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo" });
        }
    }
}
