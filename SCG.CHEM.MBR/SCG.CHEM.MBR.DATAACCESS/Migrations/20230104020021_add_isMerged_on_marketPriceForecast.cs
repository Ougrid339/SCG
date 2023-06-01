using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_isMerged_on_marketPriceForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast");

            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast");
        }
    }
}
