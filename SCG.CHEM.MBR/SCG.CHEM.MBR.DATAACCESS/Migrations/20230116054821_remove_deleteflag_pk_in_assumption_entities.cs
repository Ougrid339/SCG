using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class remove_deleteflag_pk_in_assumption_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_Assumption",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_Assumption",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_MST_Assumption",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo", "DeletedFlag", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_Assumption",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo", "DeletedFlag" });
        }
    }
}
