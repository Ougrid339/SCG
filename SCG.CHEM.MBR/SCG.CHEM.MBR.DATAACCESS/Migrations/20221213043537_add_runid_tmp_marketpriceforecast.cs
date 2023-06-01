using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_runid_tmp_marketpriceforecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast");
        }
    }
}
