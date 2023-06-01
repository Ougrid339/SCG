using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class Update_Field_feed_info : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                columns: new[] { "ID", "MonthNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                columns: new[] { "ID", "MonthNo" });
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

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.AlterColumn<string>(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedInfo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedInfo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                column: "ID");
        }
    }
}
