using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_pk_runid_tmp_marketpriceforecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceForecast",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast");

            migrationBuilder.AlterColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceForecast",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                columns: new[] { "Case", "PlanType", "MarketSource", "Cycle", "MonthNo", "RunId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceForecast",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast");

            migrationBuilder.AlterColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceForecast",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                columns: new[] { "Case", "PlanType", "MarketSource", "Cycle", "MonthNo" });
        }
    }
}
