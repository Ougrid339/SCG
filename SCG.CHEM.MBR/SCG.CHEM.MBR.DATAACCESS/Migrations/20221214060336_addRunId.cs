using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addRunId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo", "RunId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo" });
        }
    }
}
