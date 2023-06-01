using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update2_fct_marketpriceolefin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ACTIVE_WEB",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ACTIVE_WEB",
                schema: "mbr",
                table: "MBR_FCT_MarketPriceOlefins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }
    }
}
