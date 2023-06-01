using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class addPreviewSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBR_TMP_SalesPreviewSubmit",
                schema: "mbr",
                columns: table => new
                {
                    WebUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriviewRunId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmitRunId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_SalesPreviewSubmit", x => x.WebUUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBR_TMP_SalesPreviewSubmit",
                schema: "mbr");
        }
    }
}
