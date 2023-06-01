using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addconditionvariabletobeakey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_FormulaParameterMapping",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping");

            migrationBuilder.AlterColumn<string>(
                name: "ConditionVariable",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_FormulaParameterMapping",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping",
                columns: new[] { "FormulaID", "FormulaName", "Parameter", "ConditionVariable" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_FormulaParameterMapping",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping");

            migrationBuilder.AlterColumn<string>(
                name: "ConditionVariable",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_FormulaParameterMapping",
                schema: "mbr",
                table: "MBR_MST_FormulaParameterMapping",
                columns: new[] { "FormulaID", "FormulaName", "Parameter" });
        }
    }
}
