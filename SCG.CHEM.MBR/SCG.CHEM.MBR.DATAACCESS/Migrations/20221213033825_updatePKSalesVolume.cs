using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class updatePKSalesVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "ID",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.RenameColumn(
                name: "Month",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "Month",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                newName: "MonthNo");

            migrationBuilder.AddColumn<string>(
                name: "MonthIndex",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MonthIndex",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MonthIndex", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "Product", "MonthIndex", "MCSC", "Channel", "FormulaName", "Customers", "TermSpot", "PriceSet", "MonthNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MonthIndex",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MonthIndex",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "CyclePoly",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                newName: "Month");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_SalesVolume",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_SalesVolume",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                column: "ID");
        }
    }
}
