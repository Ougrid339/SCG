using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class renamecolumnlsppriceformulatemptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRODUCT_SHORT_NAME",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "ProductShortName");

            migrationBuilder.RenameColumn(
                name: "PRODUCT_DESCRIPTION",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "ProductDescription");

            migrationBuilder.RenameColumn(
                name: "PRODUCT_CODE",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "ProductCode");

            migrationBuilder.RenameColumn(
                name: "FORMULA_EQUATION",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "FormulaEquation");

            migrationBuilder.RenameColumn(
                name: "FORMULA_DESCRIPTION",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "FormulaDescription");

            migrationBuilder.RenameColumn(
                name: "FORMULA_NAME",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "FormulaName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductShortName",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "PRODUCT_SHORT_NAME");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "PRODUCT_DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "ProductCode",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "PRODUCT_CODE");

            migrationBuilder.RenameColumn(
                name: "FormulaEquation",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "FORMULA_EQUATION");

            migrationBuilder.RenameColumn(
                name: "FormulaDescription",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "FORMULA_DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "FormulaName",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                newName: "FORMULA_NAME");
        }
    }
}
