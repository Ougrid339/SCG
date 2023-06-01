using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_field_mergeHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_MergeHistory",
                schema: "mbr",
                table: "MBR_TRN_MergeHistory");

            migrationBuilder.AddColumn<int>(
                name: "ExcelId",
                schema: "mbr",
                table: "MBR_TRN_MergeHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_MergeHistory",
                schema: "mbr",
                table: "MBR_TRN_MergeHistory",
                columns: new[] { "Id", "ExcelId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_MergeHistory",
                schema: "mbr",
                table: "MBR_TRN_MergeHistory");

            migrationBuilder.DropColumn(
                name: "ExcelId",
                schema: "mbr",
                table: "MBR_TRN_MergeHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_MergeHistory",
                schema: "mbr",
                table: "MBR_TRN_MergeHistory",
                column: "Id");
        }
    }
}
