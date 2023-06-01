using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class remove_ubique_productmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MBR_TMP_ProductMapping_ProductShortName_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping");

            migrationBuilder.DropIndex(
                name: "IX_MBR_MST_ProductMapping_ProductShortName_VersionNo",
                schema: "mbr",
                table: "MBR_MST_ProductMapping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MBR_TMP_ProductMapping_ProductShortName_VersionNo",
                schema: "mbr",
                table: "MBR_TMP_ProductMapping",
                columns: new[] { "ProductShortName", "VersionNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MBR_MST_ProductMapping_ProductShortName_VersionNo",
                schema: "mbr",
                table: "MBR_MST_ProductMapping",
                columns: new[] { "ProductShortName", "VersionNo" },
                unique: true);
        }
    }
}
