using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class rename_ContractCategoryKey_feed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractCategoryKey",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "ContractCategoryKey",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.AddColumn<string>(
                name: "ContractSpot",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContractSpot",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractSpot",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "ContractSpot",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.AddColumn<string>(
                name: "ContractCategoryKey",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContractCategoryKey",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
