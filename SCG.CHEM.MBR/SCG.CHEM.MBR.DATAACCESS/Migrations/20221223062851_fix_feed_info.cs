using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class fix_feed_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.AlterColumn<string>(
                name: "FeedNameKey",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FeedNameKey",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                column: "MonthNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.AlterColumn<string>(
                name: "FeedNameKey",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FeedNameKey",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                columns: new[] { "ID", "MonthNo" });
        }
    }
}
