using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCG.CHEM.MBR.DATAACCESS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mbr");

            migrationBuilder.CreateTable(
                name: "LOG_API",
                schema: "mbr",
                columns: table => new
                {
                    InterfaceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterfaceStatus = table.Column<int>(type: "int", nullable: true),
                    ServicePath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InboundTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutboundTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InboundMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    PlanType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cycle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValidationSuccess = table.Column<bool>(type: "bit", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG_API", x => x.InterfaceId);
                });

            migrationBuilder.CreateTable(
                name: "LOG_SEND_DWH",
                schema: "mbr",
                columns: table => new
                {
                    InterfaceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterfaceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InboundTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutboundTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InboundMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutboundMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cycle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PlanningGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SalesGroupCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG_SEND_DWH", x => x.InterfaceId);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_Case",
                schema: "mbr",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Case", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_CustomerVendorMapping",
                schema: "mbr",
                columns: table => new
                {
                    CustomerShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_CustomerVendorMapping", x => new { x.CustomerShortName, x.CustomerCode, x.Type });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_DataFactoryRun",
                schema: "mbr",
                columns: table => new
                {
                    RunId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_DataFactoryRun", x => x.RunId);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_DeleteFlag",
                schema: "mbr",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_DeleteFlag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_ExportMapping",
                schema: "mbr",
                columns: table => new
                {
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    Variable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExcelHeader = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_ExportMapping", x => new { x.MasterId, x.Variable });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_HistoryType",
                schema: "mbr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_HistoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_LSPPriceFormula",
                schema: "mbr",
                columns: table => new
                {
                    FORMULA_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PRODUCT_CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PRODUCT_SHORT_NAME = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PRODUCT_DESCRIPTION = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FORMULA_DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FORMULA_EQUATION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_LSPPriceFormula", x => x.FORMULA_NAME);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_MarketPriceMapping",
                schema: "mbr",
                columns: table => new
                {
                    MarketPriceMI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarketPriceWebPricing = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MarketPriceShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MarketPriceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EBACode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_MarketPriceMapping", x => new { x.MarketPriceMI, x.MarketPriceWebPricing });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_Master",
                schema: "mbr",
                columns: table => new
                {
                    MasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MasterTable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MasterTemp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sheet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    ViewExport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ViewTemplate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlanType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Master", x => x.MasterId);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_MasterExcel",
                schema: "mbr",
                columns: table => new
                {
                    ExcelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MasterTable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_MasterExcel", x => x.ExcelId);
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_MasterExcelMapping",
                schema: "mbr",
                columns: table => new
                {
                    ExcelId = table.Column<int>(type: "int", nullable: false),
                    Variable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExcelHeader = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    Require = table.Column<bool>(type: "bit", nullable: true),
                    Primary = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_MasterExcelMapping", x => new { x.ExcelId, x.Variable });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_MasterMapping",
                schema: "mbr",
                columns: table => new
                {
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    Variable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExcelHeader = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    Require = table.Column<bool>(type: "bit", nullable: true),
                    Primary = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_MasterMapping", x => new { x.MasterId, x.Variable });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_Pages",
                schema: "mbr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Pages", x => new { x.Id, x.Pages });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_ProductMapping",
                schema: "mbr",
                columns: table => new
                {
                    ProductShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductGroup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_ProductMapping", x => new { x.MaterialCode, x.ProductShortName });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_Roles",
                schema: "mbr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvailablePages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableMasters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableUploadPlanningGroups = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableDWHPlanningGroups = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSalesGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableNewProductFlag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Roles", x => new { x.Id, x.RoleName });
                });

            migrationBuilder.CreateTable(
                name: "MBR_MST_Users",
                schema: "mbr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_MST_Users", x => new { x.Id, x.Username });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_CustomerVendorMapping",
                schema: "mbr",
                columns: table => new
                {
                    CustomerShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_CustomerVendorMapping", x => new { x.CustomerShortName, x.CustomerCode, x.Type });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_LSPPriceFormula",
                schema: "mbr",
                columns: table => new
                {
                    FORMULA_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PRODUCT_CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PRODUCT_SHORT_NAME = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PRODUCT_DESCRIPTION = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FORMULA_DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FORMULA_EQUATION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_LSPPriceFormula", x => x.FORMULA_NAME);
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_MarketPriceForcase",
                schema: "mbr",
                columns: table => new
                {
                    SCENARIO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CASE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CYCLE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MARKET_SOURCE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    M0 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M1 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M2 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M3 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M4 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M5 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M6 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M7 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M8 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M9 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M10 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M11 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M12 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M13 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M14 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M15 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M16 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M17 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    M18 = table.Column<decimal>(type: "decimal(15,5)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_MarketPriceForcase", x => new { x.CASE, x.SCENARIO, x.MARKET_SOURCE, x.CYCLE });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_MarketPriceMapping",
                schema: "mbr",
                columns: table => new
                {
                    MarketPriceMI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarketPriceWebPricing = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MarketPriceShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MarketPriceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EBACode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_MarketPriceMapping", x => new { x.MarketPriceMI, x.MarketPriceWebPricing });
                });

            migrationBuilder.CreateTable(
                name: "MBR_TMP_ProductMapping",
                schema: "mbr",
                columns: table => new
                {
                    ProductShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductGroup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedFlag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBR_TMP_ProductMapping", x => new { x.MaterialCode, x.ProductShortName });
                });

            migrationBuilder.CreateTable(
                name: "MST_CONFIG",
                schema: "mbr",
                columns: table => new
                {
                    CONFIG_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CONFIG_VALUE = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CONFIG_DESC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FLAG_DECRYPT = table.Column<bool>(type: "bit", nullable: false),
                    FLAG_ADMIN_ONLY = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_CONFIG", x => x.CONFIG_ID);
                });

            migrationBuilder.CreateTable(
                name: "MST_GROUP",
                schema: "mbr",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_GROUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MST_MENU",
                schema: "mbr",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARENT_ID = table.Column<int>(type: "int", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORDER = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_MENU", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MST_ROLE",
                schema: "mbr",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ROLE_TYPE_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MST_USER_PROFILE",
                schema: "mbr",
                columns: table => new
                {
                    USER_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PURCHASING_GROUP_ID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DELETE_FLAG = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_USER_PROFILE", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "REL_GROUP_ROLE",
                schema: "mbr",
                columns: table => new
                {
                    GROUP_ID = table.Column<short>(type: "smallint", nullable: false),
                    ROLE_ID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REL_GROUP_ROLE", x => new { x.GROUP_ID, x.ROLE_ID });
                });

            migrationBuilder.CreateTable(
                name: "REL_MENU_ROLE",
                schema: "mbr",
                columns: table => new
                {
                    MENU_ID = table.Column<int>(type: "int", nullable: false),
                    ROLE_ID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REL_MENU_ROLE", x => new { x.MENU_ID, x.ROLE_ID });
                });

            migrationBuilder.CreateTable(
                name: "REL_USER_GROUP",
                schema: "mbr",
                columns: table => new
                {
                    USER_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GROUP_ID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REL_USER_GROUP", x => new { x.USER_ID, x.GROUP_ID });
                });

            migrationBuilder.CreateTable(
                name: "REL_USER_ROLE",
                schema: "mbr",
                columns: table => new
                {
                    USER_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REL_USER_ROLE", x => x.USER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOG_API",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "LOG_SEND_DWH",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_Case",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_CustomerVendorMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_DataFactoryRun",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_DeleteFlag",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_ExportMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_HistoryType",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_LSPPriceFormula",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_MarketPriceMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_Master",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_MasterExcel",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_MasterExcelMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_MasterMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_Pages",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_ProductMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_Roles",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_MST_Users",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_CustomerVendorMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_LSPPriceFormula",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_MarketPriceForcase",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_MarketPriceMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MBR_TMP_ProductMapping",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MST_CONFIG",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MST_GROUP",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MST_MENU",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MST_ROLE",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "MST_USER_PROFILE",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "REL_GROUP_ROLE",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "REL_MENU_ROLE",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "REL_USER_GROUP",
                schema: "mbr");

            migrationBuilder.DropTable(
                name: "REL_USER_ROLE",
                schema: "mbr");
        }
    }
}
