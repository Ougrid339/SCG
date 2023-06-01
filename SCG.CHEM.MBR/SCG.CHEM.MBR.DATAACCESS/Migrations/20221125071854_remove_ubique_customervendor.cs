using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class remove_ubique_customervendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_CustomerVendorMapping_CustomerCode_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_MST_CustomerVendorMapping_CustomerCode_VersionNo",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MBR_TMP_CustomerVendorMapping_CustomerCode_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_CustomerVendorMapping",
                columns: new[] { "CustomerCode", "VersionNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MBR_MST_CustomerVendorMapping_CustomerCode_VersionNo",
                schema: "mbr",
                table: "MBR_MST_CustomerVendorMapping",
                columns: new[] { "CustomerCode", "VersionNo" },
                unique: true);
        }
    }
}
