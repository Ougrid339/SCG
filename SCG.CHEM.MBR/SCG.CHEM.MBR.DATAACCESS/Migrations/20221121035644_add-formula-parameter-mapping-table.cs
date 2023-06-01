using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addformulaparametermappingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_MST_FormulaParameterMapping",
                schema: "mbr",
                columns: table => new
                {
                    FormulaID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FormulaName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Parameter = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ConditionVariable = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_FormulaParameterMapping", x => new { x.FormulaID, x.FormulaName, x.Parameter });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_MST_FormulaParameterMapping",
                schema: "mbr");
        }
    }
}
