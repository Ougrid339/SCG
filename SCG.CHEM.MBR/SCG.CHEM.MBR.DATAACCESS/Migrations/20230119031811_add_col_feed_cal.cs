using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_col_feed_cal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InsuranceUSDPerTon",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MOPJM0",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketPrice",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceUSDPerTon",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SurveyorUSDPerTon",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InsuranceUSDPerTon",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MOPJM0",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketPrice",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceUSDPerTon",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SurveyorUSDPerTon",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "decimal(15,5)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "InsuranceUSDPerTon",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MOPJM0",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MarketPrice",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "PriceUSDPerTon",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "SurveyorUSDPerTon",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "InsuranceUSDPerTon",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MOPJM0",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MarketPrice",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "PriceUSDPerTon",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "SurveyorUSDPerTon",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");
        }
    }
}
