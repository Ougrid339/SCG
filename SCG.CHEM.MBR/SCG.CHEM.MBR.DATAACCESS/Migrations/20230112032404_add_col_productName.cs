using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_col_productName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropColumn(
                name: "ProductName",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");
        }
    }
}
