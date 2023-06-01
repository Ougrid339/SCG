using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class add_lockunlock_saleconfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_MST_LockUnlockCycle",
                schema: "mbr",
                columns: table => new
                {
                    PlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_LockUnlockCycle", x => new { x.PlanType, x.Cycle, x.Case });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_SalesConfirm",
                schema: "mbr",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cycle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Case = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductGroup = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_SalesConfirm", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_MST_LockUnlockCycle",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_SalesConfirm",
                schema: "mbr");
        }
    }
}
