using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addisdowloadisuploadformastermapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDownload",
                schema: "mbr",
                table: "MBR_MST_MasterMapping",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpload",
                schema: "mbr",
                table: "MBR_MST_MasterMapping",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDownload",
                schema: "mbr",
                table: "MBR_MST_MasterMapping");

            migrationBuilder.DropColumn(
                name: "IsUpload",
                schema: "mbr",
                table: "MBR_MST_MasterMapping");
        }
    }
}
