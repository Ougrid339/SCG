using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class edit_col_FormulaName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FormulaName",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FormulaName",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
