using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addversionnoindexfortemptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_ProductMapping_ProductShortName",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_CustomerVendorMapping_CustomerCode",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.CreateIndex(
                name: "IX_MBR_TMP_ProductMapping_ProductShortName_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                columns: new[] { "ProductShortName", "VersionNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MBR_TMP_CustomerVendorMapping_CustomerCode_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                columns: new[] { "CustomerCode", "VersionNo" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_ProductMapping_ProductShortName_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_CustomerVendorMapping_CustomerCode_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

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
        }
    }
}
