using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_datafact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Case",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cycle",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMerge",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plantype",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Case",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun");

            migrationBuilder.DropColumn(
                name: "Cycle",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun");

            migrationBuilder.DropColumn(
                name: "IsMerge",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun");

            migrationBuilder.DropColumn(
                name: "Plantype",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun");
        }
    }
}
