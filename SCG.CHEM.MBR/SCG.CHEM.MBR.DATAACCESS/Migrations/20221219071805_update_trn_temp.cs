using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_trn_temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                newName: "MCSC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                newName: "MC/SC");
        }
    }
}
