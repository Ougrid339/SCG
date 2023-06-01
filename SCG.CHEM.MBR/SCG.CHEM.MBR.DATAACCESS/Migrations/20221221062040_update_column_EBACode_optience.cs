using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_column_EBACode_optience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElementCode(EBA)",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "ElementCode");

            migrationBuilder.RenameColumn(
                name: "ElementCode(EBA)",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "ElementCode");

            migrationBuilder.RenameColumn(
                name: "ElementCode(EBA)",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "ElementCode");

            migrationBuilder.RenameColumn(
                name: "ElementCode(EBA)",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "ElementCode");

            migrationBuilder.RenameColumn(
                name: "ElementCode(EBA)",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "ElementCode");

            migrationBuilder.RenameColumn(
                name: "ElementCode(EBA)",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "ElementCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "ElementCode(EBA)");

            migrationBuilder.RenameColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "ElementCode(EBA)");

            migrationBuilder.RenameColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "ElementCode(EBA)");

            migrationBuilder.RenameColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "ElementCode(EBA)");

            migrationBuilder.RenameColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "ElementCode(EBA)");

            migrationBuilder.RenameColumn(
                name: "ElementCode",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "ElementCode(EBA)");
        }
    }
}
