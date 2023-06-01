using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class edit_tmp_salesvolume_param_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Premium",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IB",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Den",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BD",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Alpha2",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Alpha1",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj5",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj4",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj3",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj2",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj1",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Premium",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IB",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Den",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BD",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Alpha2",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Alpha1",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj5",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj4",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj3",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj2",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Adj1",
                schema: "mbr",
                table: "MBR_TMP_SalesVolume",
                type: "decimal(15,5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)");
        }
    }
}
