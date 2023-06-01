using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class drop_Master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_CODE",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerCode",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_CODE",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerCode",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                columns: new[] { "MaterialCode", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "Type", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                columns: new[] { "MaterialCode", "VersionNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "Type", "VersionNo" });

            migrationBuilder.CreateIndex(
                name: "IX_MBR_TMP_ProductMapping_ProductShortName",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                column: "ProductShortName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MBR_TMP_CustomerVendorMapping_CustomerCode",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                column: "CustomerCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MBR_MST_ProductMapping_ProductShortName",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                column: "ProductShortName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MBR_MST_CustomerVendorMapping_CustomerCode",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                column: "CustomerCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_ProductMapping_ProductShortName",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_CustomerVendorMapping_CustomerCode",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_MST_ProductMapping_ProductShortName",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_MST_CustomerVendorMapping_CustomerCode",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_CODE",
                schema: "mbr",
                table: "MBR_TMP_LSPPriceFormula",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerCode",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialCode",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_CODE",
                schema: "mbr",
                table: "MBR_MST_LSPPriceFormula",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerCode",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                columns: new[] { "MaterialCode", "ProductShortName", "VersionNo" });

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
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "CustomerCode", "Type", "VersionNo" });
        }
    }
}
