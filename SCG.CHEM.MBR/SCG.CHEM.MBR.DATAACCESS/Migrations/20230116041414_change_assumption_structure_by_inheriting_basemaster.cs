using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class change_assumption_structure_by_inheriting_basemaster : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeletedFlag",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeletedFlag",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo", "DeletedFlag" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_Assumption",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case", "VersionNo", "DeletedFlag" });
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

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "DeletedFlag",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "VersionNo",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "DeletedFlag",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_TMP_Assumption",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBR_MST_Assumption",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                columns: new[] { "Type", "PlanType", "Cycle", "Case" });
        }
    }
}
