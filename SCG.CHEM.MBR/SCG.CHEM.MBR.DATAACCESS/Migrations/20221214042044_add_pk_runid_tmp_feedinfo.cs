using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_pk_runid_tmp_feedinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                columns: new[] { "ID", "MonthNo", "RunId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                columns: new[] { "ID", "MonthNo" });
        }
    }
}
