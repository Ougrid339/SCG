using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addisdownloadisuploadflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDownload",
                schema: "mbr",
                table: "MBR_MST_MasterExcelMapping",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpload",
                schema: "mbr",
                table: "MBR_MST_MasterExcelMapping",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDownload",
                schema: "mbr",
                table: "MBR_MST_MasterExcelMapping");

            migrationBuilder.DropColumn(
                name: "IsUpload",
                schema: "mbr",
                table: "MBR_MST_MasterExcelMapping");
        }
    }
}
