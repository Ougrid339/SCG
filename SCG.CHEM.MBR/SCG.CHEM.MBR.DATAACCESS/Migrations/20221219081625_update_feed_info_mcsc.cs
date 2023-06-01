using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_feed_info_mcsc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "MCSC");

            migrationBuilder.RenameColumn(
                name: "MC/SC",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "MCSC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "MC/SC");

            migrationBuilder.RenameColumn(
                name: "MCSC",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "MC/SC");
        }
    }
}
