using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                columns: new[] { "MaterialCode", "ProductShortName", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                columns: new[] { "FORMULA_NAME", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "CustomerCode", "Type", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                columns: new[] { "MaterialCode", "ProductShortName", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula",
                columns: new[] { "FORMULA_NAME", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "CustomerCode", "Type", "VersionNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                columns: new[] { "MaterialCode", "ProductShortName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_TMP_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                column: "FORMULA_NAME");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "CustomerCode", "Type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                columns: new[] { "MaterialCode", "ProductShortName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_MarketPriceMapping",
                schema: "mbr",
                table: "MBR_MST_MarketPriceMapping",
                columns: new[] { "MarketPriceMI", "MarketPriceWebPricing" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_LSPPriceFormula",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula",
                column: "FORMULA_NAME");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "CustomerCode", "Type" });
        }
    }
}
