using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_sourcesystem_customervendor_productmapping : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductMapping",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                columns: new[] { "MaterialCode", "VersionNo", "SourceSystem" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "Type", "VersionNo", "SourceSystem" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_ProductMapping",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                columns: new[] { "MaterialCode", "VersionNo", "SourceSystem" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                columns: new[] { "CustomerShortName", "Type", "VersionNo", "SourceSystem" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropColumn(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropColumn(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");

            migrationBuilder.DropColumn(
                name: "SourceSystem",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");

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
        }
    }
}
