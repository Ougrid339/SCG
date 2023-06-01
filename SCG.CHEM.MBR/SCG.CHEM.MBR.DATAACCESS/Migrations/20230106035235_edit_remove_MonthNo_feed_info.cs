using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class edit_remove_MonthNo_feed_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                columns: new[] { "ID", "RunId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                columns: new[] { "ID", "MonthNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                columns: new[] { "ID", "MonthNo", "RunId" });
        }
    }
}
