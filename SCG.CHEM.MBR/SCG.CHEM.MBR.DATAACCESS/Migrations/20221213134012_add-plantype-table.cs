using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addplantypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_MST_PlanType",
                schema: "mbr",
                columns: table => new
                {
                    PlanTypeId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PlanTypeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_PlanType", x => x.PlanTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_MST_PlanType",
                schema: "mbr");
        }
    }
}
