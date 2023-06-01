using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_col_FormulaEquation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormulaEquation",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormulaEquation",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping");
        }
    }
}
