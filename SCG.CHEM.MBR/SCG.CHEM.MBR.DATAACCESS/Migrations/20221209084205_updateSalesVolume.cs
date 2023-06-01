using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class updateSalesVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                newName: "PlanType");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                newName: "PlanType");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume");

            migrationBuilder.RenameColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_SalesVolume",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                newName: "Scenario");
        }
    }
}
