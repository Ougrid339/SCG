using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class rename_termspot_field_trn_salesvolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TermSpot",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                newName: "ContractSpot");

            migrationBuilder.RenameColumn(
                name: "TermSpot",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                newName: "ContractSpot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContractSpot",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                newName: "TermSpot");

            migrationBuilder.RenameColumn(
                name: "ContractSpot",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                newName: "TermSpot");
        }
    }
}
