using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_back_id_in_feed_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                columns: new[] { "ID", "MonthNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                column: "MonthNo");
        }
    }
}
