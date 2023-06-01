using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_role_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableDWHPlanningGroups",
                schema: "mbr",
                table: "MBR_MST_Roles");

            migrationBuilder.DropColumn(
                name: "AvailableNewProductFlag",
                schema: "mbr",
                table: "MBR_MST_Roles");

            migrationBuilder.DropColumn(
                name: "AvailableSalesGroup",
                schema: "mbr",
                table: "MBR_MST_Roles");

            migrationBuilder.DropColumn(
                name: "AvailableUploadPlanningGroups",
                schema: "mbr",
                table: "MBR_MST_Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvailableDWHPlanningGroups",
                schema: "mbr",
                table: "MBR_MST_Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableNewProductFlag",
                schema: "mbr",
                table: "MBR_MST_Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableSalesGroup",
                schema: "mbr",
                table: "MBR_MST_Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableUploadPlanningGroups",
                schema: "mbr",
                table: "MBR_MST_Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
