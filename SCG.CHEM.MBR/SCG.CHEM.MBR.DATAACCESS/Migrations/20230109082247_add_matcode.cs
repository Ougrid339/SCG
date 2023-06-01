using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_matcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");
        }
    }
}
