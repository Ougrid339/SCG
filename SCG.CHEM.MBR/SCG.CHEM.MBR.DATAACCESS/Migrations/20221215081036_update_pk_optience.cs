using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_pk_optience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "MergedWithCycle");

            migrationBuilder.RenameColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "MergedWithCycle");

            migrationBuilder.RenameColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "MergedWithCycle");

            migrationBuilder.RenameColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "MergedWithCycle");

            migrationBuilder.RenameColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "MonthNo");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                newName: "CopiedFromCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                newName: "MonthNo");

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "ProductName", "MonthNo", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "FeedName", "MonthNo", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "FeedName", "MonthNo", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "ProductShortName", "MonthNo", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "ProductName", "MonthNo", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "FeedName", "MonthNo", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "FeedName", "MonthNo", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "PlanType", "Company", "Cycle", "ProductShortName", "MonthNo", "MC/SC", "RunId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory");

            migrationBuilder.RenameColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "CopiedFrom");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "CopiedFrom");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "CopiedFrom");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "CopiedFrom");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                newName: "Scenario");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_ProductionVolume",
                schema: "mbr",
                table: "MBR_TRN_ProductionVolume",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedPurchase",
                schema: "mbr",
                table: "MBR_TRN_FeedPurchase",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_FeedConsumption",
                schema: "mbr",
                table: "MBR_TRN_FeedConsumption",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TRN_BeginningInventory",
                schema: "mbr",
                table: "MBR_TRN_BeginningInventory",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductShortName", "MonthIndex", "MC/SC" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_ProductionVolume",
                schema: "mbr",
                table: "MBR_TMP_ProductionVolume",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductName", "MonthIndex", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedPurchase",
                schema: "mbr",
                table: "MBR_TMP_FeedPurchase",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_FeedConsumption",
                schema: "mbr",
                table: "MBR_TMP_FeedConsumption",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "FeedName", "MonthIndex", "MC/SC", "RunId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_BeginningInventory",
                schema: "mbr",
                table: "MBR_TMP_BeginningInventory",
                columns: new[] { "Case", "Scenario", "Company", "Cycle", "ProductShortName", "MonthIndex", "MC/SC", "RunId" });
        }
    }
}
