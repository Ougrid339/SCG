using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_optience_company_in_role_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvailableCompany",
                schema: "mbr",
                table: "MBR_MST_Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvailableOptience",
                schema: "mbr",
                table: "MBR_MST_Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MBR_MST_Optience",
                schema: "mbr",
                columns: table => new
                {
                    OptienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptienceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OptienceTable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OptienceTemp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sheet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mode = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Optience", x => x.OptienceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_MST_Optience",
                schema: "mbr");

            migrationBuilder.DropColumn(
                name: "AvailableCompany",
                schema: "mbr",
                table: "MBR_MST_Roles");

            migrationBuilder.DropColumn(
                name: "AvailableOptience",
                schema: "mbr",
                table: "MBR_MST_Roles");
        }
    }
}
