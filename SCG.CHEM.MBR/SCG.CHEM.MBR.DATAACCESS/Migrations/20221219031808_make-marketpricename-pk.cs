using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class makemarketpricenamepk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing", "VersionNo", "MarketPriceName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing", "VersionNo", "MarketPriceName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing", "VersionNo" });
        }
    }
}
