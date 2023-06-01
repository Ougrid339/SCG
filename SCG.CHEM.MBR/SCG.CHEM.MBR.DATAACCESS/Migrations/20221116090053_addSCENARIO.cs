using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addSCENARIO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_MST_Scenario",
                schema: "mbr",
                columns: table => new
                {
                    SceneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SceneDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SceneSDesc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Scenario", x => x.SceneId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_MST_Scenario",
                schema: "mbr");
        }
    }
}
