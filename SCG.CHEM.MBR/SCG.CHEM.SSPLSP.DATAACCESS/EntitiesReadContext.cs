using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;

namespace SCG.CHEM.SSPLSP.DATAACCESS
{
    public class EntitiesReadContext : EntitiesContext
    {
        public EntitiesReadContext(DbContextOptions<EntitiesReadContext> options, AppSettings appSettings) : base(options, appSettings)
        {
            _AppSettings = appSettings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (this._AppSettings != null && this._AppSettings.databaseSchema != null && !string.IsNullOrEmpty(this._AppSettings.databaseSchema.dbo))
            {
                modelBuilder.HasDefaultSchema(this._AppSettings.databaseSchema.dbo);
            }
            modelBuilder.Entity<REL_GROUP_ROLE>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.GroupId,
                    e.RoleId
                });
            });

            modelBuilder.Entity<REL_MENU_ROLE>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.RoleId });
            });

            modelBuilder.Entity<REL_USER_GROUP>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId });
            });

            #region Master

            modelBuilder.Entity<SSP_MST_USERS>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Username });
            });
            modelBuilder.Entity<SSP_MST_ROLES>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RoleName });
            });
            modelBuilder.Entity<SSP_MST_PAGES>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Pages });
            });

            modelBuilder.Entity<SSP_MST_REGION>(entity =>
            {
                entity.HasKey(e => new { e.Region, e.Country, e.SalesOrg });
            });

            modelBuilder.Entity<SSP_MST_SUB_REGION>(entity =>
            {
                entity.HasKey(e => new { e.SubRegion, e.Region });
            });

            modelBuilder.Entity<SSP_MST_RAW_MAT_PLANT_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MaterialCode, e.Plant });
            });

            modelBuilder.Entity<SSP_MST_FREIGHT>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.RegionCode, e.PlanType, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_FREIGHT_SUBREGION>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.SubRegion, e.RegionCode, e.PlanType, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_DELIVERY_COST_FLAG>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.ChannelGroup, e.DeliveryMethod, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_DELIVERY_COST>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_ADDITIONAL_BY_CUSTOMER>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.Customer, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_ADDITIONAL_BY_GRADEPACK>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Grade, e.Package, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_ADDITIONAL_BY_PACK>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.Package, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_CPD_GRADE_ATTR>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.StartMonth, e.MatPrefix, e.Grade, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_OTHER_COST>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.StartMonth, e.Channel, e.SalesOrg, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MANUAL_ADJUST_COST_GRADELINE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Grade, e.Plant, e.ProductionLine, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MONOMER_EXPORT_EXPENSE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.ProductSub, e.Product, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_RAW_MAT_GAP>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.Company, e.MatCode, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MARKET_PRICE_GAP>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MarketGroup, e.BaseMarketGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MONOMER_PRICE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.InputM1, e.VersionName, e.Monomer, e.PriceUnitId, e.MonthNo, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_PRICE_GAP>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.RawMatCode, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_IMPORT_RM_ROTO>(entity =>
            {
                entity.HasKey(e => new { e.RawMatCode, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MULTISITE_ROTO>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.ValType, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_POLYMER_PRICE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.InputM1, e.VersionName, e.MarketGroup, e.MonthNo, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_STANDARD_LINE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.MatPrefix, e.Grade, e.Plant, e.ProductionLine, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.ProductionSite, e.Product, e.ProductSub, e.Region, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_DELIVERY_BY_ZONE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.Zone, e.Product, e.ProductSub, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MOVE_MAPPING_BY_GRADE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.Grade, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_SANDOP_PRODUCTION_LINE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionLineCode, e.Plant });
            });

            modelBuilder.Entity<SSP_MST_PPR_COST_VALIDATION>(entity =>
            {
                entity.HasKey(e => new { e.Material, e.Plant, e.CusValuationType1, e.StartYearMonth });
            });

            modelBuilder.Entity<SSP_MST_REF_GRADE_BY_PRODUCT_GROUP>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.Product, e.PrdSub, e.ProductGroupId, e.ProductGroupSDesc, e.ProductionSite });
            });

            modelBuilder.Entity<SSP_MST_HVA_SALES_GROUP_DUMMT_CUSTOMER>(entity =>
            {
                entity.HasKey(e => new { e.SalesGroup, e.Customer, e.StartYearMonth });
            });

            modelBuilder.Entity<SSP_MST_SANDOP_LOCATION_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.ProductionLineCode, e.SDPlantCode });
            });

            modelBuilder.Entity<SSP_MST_MATERIAL_GRADE_LEVEL>(entity =>
            {
                entity.HasKey(e => new { e.Grade, e.MatPrefix });
            });

            modelBuilder.Entity<SSP_MST_REF_GRADE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.Product, e.PrdSub, e.ProductionSite });
            });

            modelBuilder.Entity<SSP_MST_HVA_SALES_GROUP_GRADE>(entity =>
            {
                entity.HasKey(e => new { e.SalesGroup, e.Grade, e.StartYearMonth });
            });

            modelBuilder.Entity<SSP_MST_WAX_ALLOCATION>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.WaxGroupId, e.FromProductionLine, e.ToProductionLine, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_EXCHANGE_RATE>(entity =>
            {
                entity.HasKey(e => new { e.StartMonth, e.PlanType, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_OPERATION_CHARGE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.SourceCompany, e.Product, e.ProductSub, e.ChannelCode, e.SalesOrg, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_RM_ROLLING>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.InputM1, e.VersionName, e.CompanyCode, e.MatCode, e.DataPart, e.UnitId, e.MonthNo, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MANUAL_COST_ROTO>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.StartMonth, e.Product, e.ProductSub, e.ProductForm, e.ProductColor, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE>(entity =>
            {
                entity.HasKey(e => new { e.FiscalYear, e.StartYearMonth, e.EndYearMonth, e.MatPrefix, e.Grade, e.Package });
            });

            modelBuilder.Entity<SSP_MST_PPR_PACKAGE_COST_BY_GRADE_PACKAGE_LSP>(entity =>
            {
                entity.HasKey(e => new { e.FiscalYear, e.StartYearMonth, e.EndYearMonth, e.MatPrefix, e.Grade, e.Package });
            });

            modelBuilder.Entity<SSP_MST_ACTUAL_HEDGING>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.ProductionSite, e.Customer, e.SalesGroup, e.MatCode, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_MASTER_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.MasterId, e.Variable });
            });
            modelBuilder.Entity<SSP_MST_EXPORT_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.MasterId, e.Variable });
            });
            modelBuilder.Entity<SSP_MST_EXCEL_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.ExcelId, e.Variable });
            });

            modelBuilder.Entity<SSP_MST_MAPPING_WAX_GROUP_BY_GRADE>(entity =>
            {
                entity.HasKey(e => new { e.Grade, e.WaxGroup, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_AVAILABLE_PRODUCTION_LINE_BY_PLANNING_GROUP_AND_PLAN_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.AvailableId });
            });

            modelBuilder.Entity<SSP_MST_PLANNING_GROUP_RULE>(entity =>
            {
                entity.HasKey(e => new { e.IsNotPlanningGroupName, e.PlanningGroupName, e.IsNotMatPrefix, e.MatPrefix, e.IsNotMaterialGroup, e.MaterialGroup, e.IsNotProduct, e.Product, e.IsNotProductSub, e.ProductSub, e.IsNotApplication, e.Application, e.IsNotProductForm, e.ProductForm, e.IsNotProductColor, e.ProductColor });
            });

            modelBuilder.Entity<SSP_MST_WAX_VISCOSITY_PERCENT>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.Grade, e.GradeComp, e.Plant, e.ProductionLine, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_MST_AFP_STANDARD_EARN>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.Grade, e.ProductionLine, e.StartMonth, e.VersionNo });
            });

            #endregion Master

            #region Template

            modelBuilder.Entity<SSP_TMP_FREIGHT>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.RegionCode, e.PlanType, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_FREIGHT_SUBREGION>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.SubRegion, e.RegionCode, e.PlanType, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_DELIVERY_COST_FLAG>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.ChannelGroup, e.DeliveryMethod, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_DELIVERY_COST>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_ADDITIONAL_BY_CUSTOMER>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.Customer, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_ADDITIONAL_BY_GRADEPACK>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Grade, e.Package, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_ADDITIONAL_BY_PACK>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Product, e.ProductSub, e.Package, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_PRICE_GAP>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.RawMatCode, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_IMPORT_RM_ROTO>(entity =>
            {
                entity.HasKey(e => new { e.RawMatCode, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_OTHER_COST>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.SalesOrg, e.Channel, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_CPD_GRADE_ATTR>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.StartMonth, e.MatPrefix, e.Grade, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MULTISITE_ROTO>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.ValType, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MANUAL_ADJUST_COST_GRADELINE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.Grade, e.Plant, e.ProductionLine, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_POLYMER_PRICE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.InputM1, e.VersionName, e.MarketGroup, e.MonthNo, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MONOMER_EXPORT_EXPENSE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MatPrefix, e.ProductSub, e.Product, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_STANDARD_LINE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.MatPrefix, e.Grade, e.Plant, e.ProductionLine, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_RAW_MAT_GAP>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.Company, e.MatCode, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_TARIFF_DESTINATION_DELIVERY_COST>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.ProductionSite, e.Product, e.ProductSub, e.Region, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MARKET_PRICE_GAP>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.MarketGroup, e.BaseMarketGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_DELIVERY_BY_ZONE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.PlanType, e.Zone, e.Product, e.ProductSub, e.ChannelGroup, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MONOMER_PRICE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.InputM1, e.VersionName, e.Monomer, e.PriceUnitId, e.MonthNo, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MOVE_MAPPING_BY_GRADE>(entity =>
            {
                entity.HasKey(e => new { e.ProductionSite, e.Grade, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_WAX_ALLOCATION>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.WaxGroupId, e.FromProductionLine, e.ToProductionLine, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_EXCHANGE_RATE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_OPERATION_CHARGE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.SourceCompany, e.Product, e.ProductSub, e.ChannelCode, e.SalesOrg, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_RM_ROLLING>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.InputM1, e.VersionName, e.CompanyCode, e.MatCode, e.DataPart, e.UnitId, e.MonthNo, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MANUAL_COST_ROTO>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.StartMonth, e.Product, e.ProductSub, e.ProductForm, e.ProductColor, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_ACTUAL_HEDGING>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.ProductionSite, e.Customer, e.SalesGroup, e.MatCode, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_MAPPING_WAX_GROUP_BY_GRADE>(entity =>
            {
                entity.HasKey(e => new { e.Grade, e.WaxGroup, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_WAX_VISCOSITY_PERCENT>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.Grade, e.GradeComp, e.Plant, e.ProductionLine, e.StartMonth, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TMP_AFP_STANDARD_EARN>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.MatPrefix, e.Grade, e.ProductionLine, e.StartMonth, e.VersionNo });
            });

            #endregion Template

            #region Views Export

            modelBuilder.Entity<vSSP_MST_FREIGHT_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_Freight_Export");
            });

            modelBuilder.Entity<vSSP_MST_FREIGHT_SUBREGION_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_FreightSubRegion_Export");
            });

            modelBuilder.Entity<vSSP_MST_DELIVERY_COST_FLAG_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_DeliveryCostFlag_Export");
            });

            modelBuilder.Entity<vSSP_MST_DELIVERY_COST_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_DeliveryCost_Export");
            });

            modelBuilder.Entity<vSSP_MST_ADDITIONAL_BY_CUSTOMER_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AdditionalByCustomer_Export");
            });

            modelBuilder.Entity<vSSP_MST_ADDITIONAL_BY_GRADEPACK_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AdditionalByGradePack_Export");
            });

            modelBuilder.Entity<vSSP_MST_ADDITIONAL_BY_PACK_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AdditionalByPack_Export");
            });

            modelBuilder.Entity<vSSP_MST_CPD_GRADE_ATTR_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_CPDGradeAttr_Export");
            });

            modelBuilder.Entity<vSSP_MST_MANUAL_ADJUST_COST_GRADELINE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ManualAdjustCostGradeLine_Export");
            });

            modelBuilder.Entity<vSSP_MST_MONOMER_EXPORT_EXPENSE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MonomerExportExpense_Export");
            });

            modelBuilder.Entity<vSSP_MST_RAW_MAT_GAP_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_RawMatGap_Export");
            });

            modelBuilder.Entity<vSSP_MST_MARKET_PRICE_GAP_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MarketPriceGap_Export");
            });

            modelBuilder.Entity<vSSP_MST_MONOMER_PRICE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MonomerPrice_Export");
            });

            modelBuilder.Entity<vSSP_MST_ACTUAL_HEDGING_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ActualHedging_Export");
            });

            modelBuilder.Entity<vSSP_MST_WAX_ALLOCATION_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_WaxAllocation_Export");
            });

            modelBuilder.Entity<vSSP_MST_EXCHANGE_RATE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ExchangeRate_Export");
            });

            modelBuilder.Entity<vSSP_MST_OTHER_COST_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_OtherCost_Export");
            });

            modelBuilder.Entity<vSSP_MST_OPERATION_CHARGE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_OperationCharge_Export");
            });

            modelBuilder.Entity<vSSP_MST_RM_ROLLING_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_RMRolling_Export");
            });

            modelBuilder.Entity<vSSP_MST_MANUAL_COST_ROTO_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ManualCostRoto_Export");
            });

            modelBuilder.Entity<vSSP_MST_PRICE_GAP_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_PriceGap_Export");
            });

            modelBuilder.Entity<vSSP_MST_IMPORT_RM_ROTO_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ImportRMRoto_Export");
            });

            modelBuilder.Entity<vSSP_MST_MULTISITE_ROTO_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MultisiteRoto_Export");
            });

            modelBuilder.Entity<vSSP_MST_POLYMER_PRICE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_PolymerPrice_Export");
            });

            modelBuilder.Entity<vSSP_MST_STANDARD_LINE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_StandardLine_Export");
            });

            modelBuilder.Entity<vSSP_MST_TARIFF_DESTINATION_DELIVERY_COST_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_TariffDestinationDeliveryCost_Export");
            });

            modelBuilder.Entity<vSSP_MST_DELIVERY_BY_ZONE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_DeliveryByZone_Export");
            });

            modelBuilder.Entity<vSSP_MST_MOVE_MAPPING_BY_GRADE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MoveMappingByGrade_Export");
            });

            modelBuilder.Entity<vSSP_MST_MAPPING_WAX_GROUP_BY_GRADE_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MappingWaxGroupByGrade_Export");
            });
            modelBuilder.Entity<vSSP_MST_WAX_VISCOSITY_PERCENT_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_WaxViscosityPercent_Export");
            });
            modelBuilder.Entity<vSSP_MST_AFP_STANDARD_EARN_EXPORT>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AFPStandardEarn_Export");
            });

            #endregion Views Export

            #region Views Template

            modelBuilder.Entity<vSSP_MST_FREIGHT_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_Freight_Template");
            });

            modelBuilder.Entity<vSSP_MST_FREIGHT_SUBREGION_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_FreightSubRegion_Template");
            });

            modelBuilder.Entity<vSSP_MST_DELIVERY_COST_FLAG_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_DeliveryCostFlag_Template");
            });

            modelBuilder.Entity<vSSP_MST_DELIVERY_COST_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_DeliveryCost_Template");
            });

            modelBuilder.Entity<vSSP_MST_ADDITIONAL_BY_CUSTOMER_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AdditionalByCustomer_Template");
            });

            modelBuilder.Entity<vSSP_MST_ADDITIONAL_BY_GRADEPACK_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AdditionalByGradePack_Template");
            });

            modelBuilder.Entity<vSSP_MST_ADDITIONAL_BY_PACK_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AdditionalByPack_Template");
            });

            modelBuilder.Entity<vSSP_MST_CPD_GRADE_ATTR_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_CPDGradeAttr_Template");
            });

            modelBuilder.Entity<vSSP_MST_MANUAL_ADJUST_COST_GRADELINE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ManualAdjustCostGradeLine_Template");
            });

            modelBuilder.Entity<vSSP_MST_MONOMER_EXPORT_EXPENSE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MonomerExportExpense_Template");
            });

            modelBuilder.Entity<vSSP_MST_RAW_MAT_GAP_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_RawMatGap_Template");
            });

            modelBuilder.Entity<vSSP_MST_MARKET_PRICE_GAP_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MarketPriceGap_Template");
            });

            modelBuilder.Entity<vSSP_MST_MONOMER_PRICE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MonomerPrice_Template");
            });

            modelBuilder.Entity<vSSP_MST_ACTUAL_HEDGING_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ActualHedging_Template");
            });

            modelBuilder.Entity<vSSP_MST_WAX_ALLOCATION_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_WaxAllocation_Template");
            });

            modelBuilder.Entity<vSSP_MST_EXCHANGE_RATE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ExchangeRate_Template");
            });

            modelBuilder.Entity<vSSP_MST_OTHER_COST_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_OtherCost_Template");
            });

            modelBuilder.Entity<vSSP_MST_OPERATION_CHARGE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_OperationCharge_Template");
            });

            modelBuilder.Entity<vSSP_MST_RM_ROLLING_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_RMRolling_Template");
            });

            modelBuilder.Entity<vSSP_MST_MANUAL_COST_ROTO_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ManualCostRoto_Template");
            });

            modelBuilder.Entity<vSSP_MST_PRICE_GAP_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_PriceGap_Template");
            });

            modelBuilder.Entity<vSSP_MST_IMPORT_RM_ROTO_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ImportRMRoto_Template");
            });

            modelBuilder.Entity<vSSP_MST_MULTISITE_ROTO_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MultisiteRoto_Template");
            });

            modelBuilder.Entity<vSSP_MST_POLYMER_PRICE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_PolymerPrice_Template");
            });

            modelBuilder.Entity<vSSP_MST_STANDARD_LINE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_StandardLine_Template");
            });

            modelBuilder.Entity<vSSP_MST_TARIFF_DESTINATION_DELIVERY_COST_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_TariffDestinationDeliveryCost_Template");
            });

            modelBuilder.Entity<vSSP_MST_DELIVERY_BY_ZONE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_DeliveryByZone_Template");
            });

            modelBuilder.Entity<vSSP_MST_MOVE_MAPPING_BY_GRADE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MoveMappingByGrade_Template");
            });

            modelBuilder.Entity<vSSP_MST_MAPPING_WAX_GROUP_BY_GRADE_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MappingWaxGroupByGrade_Template");
            });
            modelBuilder.Entity<vSSP_MST_WAX_VISCOSITY_PERCENT_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_WaxViscosityPercent_Template");
            });
            modelBuilder.Entity<vSSP_MST_AFP_STANDARD_EARN_TEMPLATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_AFPStandardEarn_Template");
            });

            #endregion Views Template

            #region View Transaction

            modelBuilder.Entity<vSSP_TRN_UNCONSTRAINT_SELLING_PRICE_SILO_TH>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_TRN_UnconstraintSellingPriceSiloTH");
            });

            modelBuilder.Entity<vSSP_TRN_UNCONSTRAINT_SELLING_PRICE_SILO_VN>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_TRN_UnconstraintSellingPriceSiloVN");
            });

            modelBuilder.Entity<vSSP_MST_MARKETPRICEATSILO>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_MarketPriceAtSilo");
            });

            modelBuilder.Entity<vSSP_TRN_CONSTRAINT_SELLING_PRICE_SILO_TH>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_TRN_ConstraintSellingPriceSiloTH");
            });

            modelBuilder.Entity<vSSP_TRN_CONSTRAINT_SELLING_PRICE_SILO_VN>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_TRN_ConstraintSellingPriceSiloVN");
            });

            modelBuilder.Entity<vSSP_MST_VAL_TYPE_TO_PRODUCTION_LINE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_MST_ValTypeToProductionLine");
            });

            modelBuilder.Entity<vSSP_TRN_CALCULATE_PRICE_SALE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_TRN_CalculatePriceSale");
            });

            #endregion View Transaction

            #region Views Account

            modelBuilder.Entity<vSSP_INF_LSP_RM_PRICE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_INF_LSP_RMPrice");
            });
            modelBuilder.Entity<vSSP_INF_LSP_EXCHANGE_RATE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_INF_LSP_ExchangeRate");
            });
            modelBuilder.Entity<vSSP_INF_LSP_MARKET_PRICE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_INF_LSP_MarketPrice");
            });
            modelBuilder.Entity<vSSP_INF_LSP_PRODUCTION_PLAN>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_INF_LSP_ProductionPlan");
            });
            modelBuilder.Entity<vSSP_INF_LSP_MONOMER_PRICE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_INF_LSP_MonomerPrice");
            });
            modelBuilder.Entity<vSSP_INF_LSP_CONSTRAINT_SALES_PLAN>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_INF_LSP_ConstraintSalesPlan");
            });
            modelBuilder.Entity<vSSP_INF_LSP_MONOMER_AVAILABLE_COMSP_RM_PRICE>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("vSSP_TRN_MonomerConsumptionRMPrice");
            });

            #endregion Views Account

            #region Transaction

            modelBuilder.Entity<SSP_TRN_MINBIBLE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.StartMonth, e.ScenarioId, e.CustomerCode, e.Channel, e.MatCodeMst, e.MatCodeTrn, e.NewProductId, e.SalesGroupCode, e.PlanningGroup, e.Region, e.ReqProductSite, e.Unit, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TRN_NON_PRIME>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.StartMonth, e.ScenarioId, e.CustomerCode, e.Channel, e.MatCodeMst, e.MatCodeTrn, e.NewProductId, e.SalesGroupCode, e.PlanningGroup, e.Region, e.ReqProductSite, e.SubRegion, e.SalesDistrict, e.Unit, e.HVASegmentCode, e.ProjectID, e.PriceUnitId, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TRN_MASTER_BATCH>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.StartMonth, e.ScenarioId, e.CustomerCode, e.Channel, e.MatCodeMst, e.MatCodeTrn, e.NewProductId, e.SalesGroupCode, e.PlanningGroup, e.Region, e.ReqProductSite, e.SubRegion, e.SalesDistrict, e.Unit, e.HVASegmentCode, e.ProjectID, e.PriceUnitId, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TRN_UNCONSTRAINT_SALES_PLAN>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.ScenarioId, e.CustomerCode, e.Channel, e.MatCodeMst, e.MatCodeTrn, e.NewProductId, e.SalesGroupCode, e.PlanningGroup, e.Region, e.ReqProductionSite, e.SubRegion, e.SalesDistrict, e.Unit, e.HVASegmentCode, e.PriceUnitId, e.InputM1, e.MonthNo, e.AutoGenFlag, e.VersionNo, e.ProjectID });
            });

            modelBuilder.Entity<SSP_TRN_LOCK_UNLOCK_CYCLE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.Cycle });
            });

            modelBuilder.Entity<SSP_TRN_LOCK_UNLOCK_UNCONSTRAINT>(entity =>
            {
                entity.HasKey(e => new { e.PlanCategory, e.PlanType, e.Cycle, e.PlanningGroup, e.SalesGroupCode });
            });

            modelBuilder.Entity<SSP_TRN_LOCK_UNLOCK_CONSTRAINT>(entity =>
            {
                entity.HasKey(e => new { e.PlanCategory, e.PlanType, e.Cycle, e.PlanningGroup });
            });
            modelBuilder.Entity<SSP_TRN_CONSTRAINT_SALES_PLAN>(entity =>
            {
                entity.HasKey(e => new { e.VersionName, e.PlanningGroup, e.MonthNo, e.SalesGroupCode​, e.Channel, e.Region, e.SubRegion​, e.ScenarioId, e.NewProductId, e.RevId, e.PrdKey, e.StockId, e.CustomerCode, e.MatCodeMst, e.MatcodeTrn, e.HVASegmentCode, e.SalesDistrict, e.ProjectID, e.ReqProductionSite, e.Unit, e.PriceUnitId, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TRN_PRODUCTION_PLAN>(entity =>
            {
                entity.HasKey(e => new { e.VersionName, e.PlanningGroup, e.RevId, e.Plant, e.Bom, e.Line, e.MatCodeMst, e.MatCodeTrn, e.Unit, e.MonthNo, e.NewProductId, e.VersionNo });
            });

            modelBuilder.Entity<SSP_TRN_MONOMER_AVAILABLE_CONSP>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.VersionName, e.MonomerType, e.MatCodeMst, e.DataPart, e.Tier, e.PriceUnitId, e.InputM1, e.MonthNo, e.VersionNo });
            });

            #endregion Transaction

            #region EXAMPLE COMBINE_KEY & PROPERTY

            // Set Combine Key
            //modelBuilder.Entity<TABLE_CLASS>(entity =>
            //{
            //    entity.HasKey(e => new { e.fieldKey1, e.fieldKey2 });
            //});

            // Set Property
            //modelBuilder.Entity<TABLE_CLASS>().Property(x => x.field).HasPrecision(15, 2);

            #endregion EXAMPLE COMBINE_KEY & PROPERTY
        }
    }
}