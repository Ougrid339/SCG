using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_merge_datafact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithPlantype",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun");

            migrationBuilder.DropColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun");

            migrationBuilder.DropColumn(
                name: "MergedWithPlantype",
                schema: "mbr",
                table: "MBR_MST_DataFactoryRun");
        }
    }
}
