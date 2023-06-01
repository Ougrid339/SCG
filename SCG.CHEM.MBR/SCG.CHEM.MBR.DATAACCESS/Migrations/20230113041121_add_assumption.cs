using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_assumption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_MST_Assumption",
                schema: "mbr",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Assumption = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Assumption", x => new { x.Type, x.PlanType, x.Cycle, x.Case });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_Assumption",
                schema: "mbr",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Assumption = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_Assumption", x => new { x.Type, x.PlanType, x.Cycle, x.Case });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_MST_Assumption",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_Assumption",
                schema: "mbr");
        }
    }
}
