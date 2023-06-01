using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class update_feed_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "PlanType");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "MergedWithPlanType");

            migrationBuilder.RenameColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "MergedWithCycle");

            migrationBuilder.RenameColumn(
                name: "Scenario",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "PlanType");

            migrationBuilder.RenameColumn(
                name: "MergedWith",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "MergedWithPlanType");

            migrationBuilder.RenameColumn(
                name: "CopiedFrom",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "MergedWithCycle");

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo");

            migrationBuilder.DropColumn(
                name: "CopiedFromCase",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "CopiedFromCycle",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "CopiedFromPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MergedWithCase",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.DropColumn(
                name: "MonthNo",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo");

            migrationBuilder.RenameColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TRN_FeedInfo",
                newName: "CopiedFrom");

            migrationBuilder.RenameColumn(
                name: "PlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "Scenario");

            migrationBuilder.RenameColumn(
                name: "MergedWithPlanType",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "MergedWith");

            migrationBuilder.RenameColumn(
                name: "MergedWithCycle",
                schema: "mbr",
                table: "MBR_TMP_FeedInfo",
                newName: "CopiedFrom");
        }
    }
}
