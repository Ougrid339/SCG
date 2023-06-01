using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_key_fct_marketpriceolefin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_FCT_MarketPriceOlefins",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_FORM",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_COLOR",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_FCT_MarketPriceOlefins",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                columns: new[] { "SCENARIO", "PRICING_YEAR", "PRICING_MONTH", "PRICING_WEEKNO", "PRICING_WEEK", "PRODUCT", "PRODUCT_COLOR", "PRODUCT_FORM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_FCT_MarketPriceOlefins",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_FORM",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_COLOR",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_FCT_MarketPriceOlefins",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                columns: new[] { "SCENARIO", "PRICING_YEAR", "PRICING_MONTH", "PRICING_WEEKNO", "PRICING_WEEK" });
        }
    }
}
