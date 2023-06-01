using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class change_assumption_structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TMP_Assumption");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_MST_Assumption");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_MST_Assumption");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_TMP_Assumption",
                type: "datetime2",
                nullable: true);

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
                name: "UpdatedBy",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                schema: "mbr",
                table: "MBR_MST_Assumption",
                type: "datetime2",
                nullable: true);
        }
    }
}
