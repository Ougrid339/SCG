using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_runid_field_for_tmp_assumption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.AddColumn<string>(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo", "DeletedFlag", "RunId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "RunId",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo", "DeletedFlag" });
        }
    }
}
