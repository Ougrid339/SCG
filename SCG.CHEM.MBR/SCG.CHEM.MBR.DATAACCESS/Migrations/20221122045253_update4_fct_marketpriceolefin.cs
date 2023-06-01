using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update4_fct_marketpriceolefin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ACTIVE_WEB",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ACTIVE_WEB",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldNullable: true);
        }
    }
}
