using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class remove_ismerge_trn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast");

            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast");

            migrationBuilder.DropColumn(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_MarketPriceForecast",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceForecast",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerged",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "bit",
                nullable: true);
        }
    }
}
