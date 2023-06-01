using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_Eba_marketpricefore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EBACode",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EBACode",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EBACode",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast");

            migrationBuilder.DropColumn(
                name: "EBACode",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast");
        }
    }
}
