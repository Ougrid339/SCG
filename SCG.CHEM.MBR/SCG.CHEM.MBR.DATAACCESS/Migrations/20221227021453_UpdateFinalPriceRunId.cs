using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class UpdateFinalPriceRunId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mode",
                schema: "mbr",
                table: "MBR_TMP_SalesPreviewSubmit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateFinalPriceRunId",
                schema: "mbr",
                table: "MBR_TMP_SalesPreviewSubmit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mode",
                schema: "mbr",
                table: "MBR_TMP_SalesPreviewSubmit");

            migrationBuilder.DropColumn(
                name: "UpdateFinalPriceRunId",
                schema: "mbr",
                table: "MBR_TMP_SalesPreviewSubmit");
        }
    }
}
