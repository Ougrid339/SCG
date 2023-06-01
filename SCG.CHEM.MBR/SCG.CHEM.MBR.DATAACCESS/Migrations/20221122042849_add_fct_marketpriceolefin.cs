using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_fct_marketpriceolefin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_FCT_MarketPriceOlefins",
                schema: "mbr",
                columns: table => new
                {
                    SCENARIO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PRICING_YEAR = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PRICING_MONTH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PRICING_WEEKNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PRICING_WEEK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PRICING_DATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRODUCT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRODUCT_FORM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRODUCT_COLOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE_SOURCE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REGION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INCOTERM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIN_PRICE = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    MAX_PRICE = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    AVG_PRICE = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    SUB_SCENARIO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRODUCT_WEB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ACTIVE_WEB = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_FCT_MarketPriceOlefins", x => new { x.SCENARIO, x.PRICING_YEAR, x.PRICING_MONTH, x.PRICING_WEEKNO, x.PRICING_WEEK });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_FCT_MarketPriceOlefins",
                schema: "mbr");
        }
    }
}
