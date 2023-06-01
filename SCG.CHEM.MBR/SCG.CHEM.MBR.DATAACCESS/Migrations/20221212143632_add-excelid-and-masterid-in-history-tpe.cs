using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addexcelidandmasteridinhistorytpe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExcelId",
                schema: "mbr",
                table: "MBR_MST_HistoryType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterId",
                schema: "mbr",
                table: "MBR_MST_HistoryType",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcelId",
                schema: "mbr",
                table: "MBR_MST_HistoryType");

            migrationBuilder.DropColumn(
                name: "MasterId",
                schema: "mbr",
                table: "MBR_MST_HistoryType");
        }
    }
}
