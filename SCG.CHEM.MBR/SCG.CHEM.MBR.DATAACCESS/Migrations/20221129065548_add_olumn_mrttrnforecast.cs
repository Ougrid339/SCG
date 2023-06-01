using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_olumn_mrttrnforecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast");

            migrationBuilder.DropColumn(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast");

            migrationBuilder.DropColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast");
        }
    }
}
