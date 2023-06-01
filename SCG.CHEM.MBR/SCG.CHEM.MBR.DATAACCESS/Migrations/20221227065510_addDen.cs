using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addDen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Den",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "decimal(15,5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Den",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Den",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "Den",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");
        }
    }
}
