using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addMaintainPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_MST_MaintainPrice",
                schema: "mbr",
                columns: table => new
                {
                    MaintainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintainName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsZero = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_MaintainPrice", x => x.MaintainId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_MST_MaintainPrice",
                schema: "mbr");
        }
    }
}
