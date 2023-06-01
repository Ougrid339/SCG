using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Template.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System.Transactions;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Logging;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Logging.Interface;

namespace SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork
{
    public class UnitOfWork
    {
        #region Inject

        private readonly EntitiesContext _context;
        private readonly AppSettings _appsettings;
        private readonly EntitiesReadContext _readContext;

        public UnitOfWork(EntitiesContext context, EntitiesReadContext readContext, AppSettings appsettings)
        {
            this._context = context;
            this._appsettings = appsettings;
            this._readContext = readContext;
        }

        #endregion Inject



        #region Repository
        public ILogApiRepo LogApiRepo
        { get { return new LogApiRepo(_context, _readContext); } }
        public ILogSendDWHRepo LogSendDWHRepo
        { get { return new LogSendDWHRepo(_context, _readContext); } }

        public IMasterUserProfileRepo MasterUserProfileRepo
        { get { return new MasterUserProfileRepo(_context, _readContext); } }
        public IUserRoleRepo UserRoleRepo
        { get { return new UserRoleRepo(_context, _readContext); } }
        public IMasterMenuRepo MasterMenuRepo
        { get { return new MasterMenuRepo(_context, _readContext); } }
        public IMasterRoleRepo MasterRoleRepo
        { get { return new MasterRoleRepo(_context, _readContext); } }
        public IMasterGroupRepo MasterGroupRepo
        { get { return new MasterGroupRepo(_context, _readContext); } }
        public IGroupRoleRepo GroupRoleRepo
        { get { return new GroupRoleRepo(_context, _readContext); } }
        public IUserGroupRepo UserGroupRepo
        { get { return new UserGroupRepo(_context, _readContext); } }
        public IMasterConfigRepo MasterConfigRepo
        { get { return new MasterConfigRepo(_context, _readContext); } }
        public IDataFactoryRunRepo DataFactoryRunRepo
        { get { return new DataFactoryRunRepo(_context, _readContext); } }
        public IMasterGenerateRunningRepo MasterGenerateRunningRepo
        { get { return new MasterGenerateRunningRepo(_context, _readContext); } }
        public IMasterDataPartRepo MasterDataPartRepo
        { get { return new MasterDataPartRepo(_context, _readContext); } }
        public IMasterDeleteFlagRepo MasterDeleteFlagRepo
        { get { return new MasterDeleteFlagRepo(_context, _readContext); } }
        public IMasterProjectStatusRepo MasterProjectStatusRepo
        { get { return new MasterProjectStatusRepo(_context, _readContext); } }
        public IMasterRegionRepo MasterRegionRepo
        { get { return new MasterRegionRepo(_context, _readContext); } }
        public IMasterSubRegionRepo MasterSubRegionRepo
        { get { return new MasterSubRegionRepo(_context, _readContext); } }
        public IFCTMaterialRepo FCTMaterialRepo
        { get { return new FCTMaterialRepo(_context, _readContext); } }
        public IMasterMaterialGradeLevelRepo MasterMaterialGradeLevelRepo
        { get { return new MasterMaterialGradeLevelRepo(_context, _readContext); } }
        public IMasterChannelRepo MasterChannelRepo
        { get { return new MasterChannelRepo(_context, _readContext); } }
        public IMasterCustomerRepo MasterCustomerRepo
        { get { return new MasterCustomerRepo(_context, _readContext); } }
        public IMasterImportRMRotoRepo MasterImportRMRotoRepo
        { get { return new MasterImportRMRotoRepo(_context, _readContext); } }
        public IMasterTempImportRMRotoRepo MasterTempImportRMRotoRepo
        { get { return new MasterTempImportRMRotoRepo(_context, _readContext); } }
        public IMasterMonomerRepo MasterMonomerRepo
        { get { return new MasterMonomerRepo(_context, _readContext); } }
        public IMasterCompanyRepo MasterCompanyRepo
        { get { return new MasterCompanyRepo(_context, _readContext); } }
        public IMasterMarketGroupRepo MasterMarketGroupRepo
        { get { return new MasterMarketGroupRepo(_context, _readContext); } }
        public IMasterPriceUnitRepo MasterPriceUnitRepo
        { get { return new MasterPriceUnitRepo(_context, _readContext); } }
        public IMasterUnitRepo MasterUnitRepo
        { get { return new MasterUnitRepo(_context, _readContext); } }
        public IMasterRefGradeByProductGroupRepo MasterRefGradeByProductGroupRepo
        { get { return new MasterRefGradeByProductGroupRepo(_context, _readContext); } }
        public IMasterSandOPLocationMappingRepo MasterSandOPLocationMappingRepo
        { get { return new MasterSandOPLocationMappingRepo(_context, _readContext); } }
        public IMasterScenarionRepo MasterScenarionRepo
        { get { return new MasterScenarionRepo(_context, _readContext); } }
        public IMasterPriceTypeRepo MasterPriceTypeRepo
        { get { return new MasterPriceTypeRepo(_context, _readContext); } }
        public IMasterPlanningGroupRuleRepo MasterPlanningGroupRuleRepo
        { get { return new MasterPlanningGroupRuleRepo(_context, _readContext); } }

        public IMasterSandOPProductionVersionRepo MasterSandOPProductionVersionRepo
        { get { return new MasterSandOPProductionVersionRepo(_context, _readContext); } }

        public IMasterRepo MasterRepo
        { get { return new MasterRepo(_context, _readContext); } }
        public IMasterProductionSiteRepo MasterProductionSiteRepo
        { get { return new MasterProductionSiteRepo(_context, _readContext); } }
        public IMasterDeliveryMethodRepo MasterDeliveryMethodRepo
        { get { return new MasterDeliveryMethodRepo(_context, _readContext); } }
        public IMasterSalesGroupRepo MasterSalesGroupRepo
        { get { return new MasterSalesGroupRepo(_context, _readContext); } }
        public IMasterSalesDistrictRepo MasterSalesDistrictRepo
        { get { return new MasterSalesDistrictRepo(_context, _readContext); } }
        public IMasterSandOPProductionLineRepo MasterSandOPProductionLineRepo
        { get { return new MasterSandOPProductionLineRepo(_context, _readContext); } }
        public IMasterScenarioRepo MasterScenarioRepo
        { get { return new MasterScenarioRepo(_context, _readContext); } }
        public IMasterExportMappingRepo MasterExportMappingRepo
        { get { return new MasterExportMappingRepo(_context, _readContext); } }
        public IMasterMappingRepo MasterMappingRepo
        { get { return new MasterMappingRepo(_context, _readContext); } }
        public IMasterExcelMappingRepo MasterExcelMappingRepo
        { get { return new MasterExcelMappingRepo(_context, _readContext); } }
        public IMasterPlantRepo MasterPlantRepo
        { get { return new MasterPlantRepo(_context, _readContext); } }

        public IMasterFreightRepo MasterFreightRepo
        { get { return new MasterFreightRepo(_context, _readContext); } }
        public IMasterTempFreightRepo MasterTempFreightRepo
        { get { return new MasterTempFreightRepo(_context, _readContext); } }

        public IMasterDeliveryCostFlagRepo MasterDeliveryCostFlagRepo
        { get { return new MasterDeliveryCostFlagRepo(_context, _readContext); } }
        public IMasterTempDeliveryCostFlagRepo MasterTempDeliveryCostFlagRepo
        { get { return new MasterTempDeliveryCostFlagRepo(_context, _readContext); } }
        public IMasterDeliveryCostRepo MasterDeliveryCostRepo
        { get { return new MasterDeliveryCostRepo(_context, _readContext); } }
        public IMasterTempDeliveryCostRepo MasterTempDeliveryCostRepo
        { get { return new MasterTempDeliveryCostRepo(_context, _readContext); } }

        public IMasterAdditionalByGradePackRepo MasterAdditionalByGradePackRepo
        { get { return new MasterAdditionalByGradePackRepo(_context, _readContext); } }
        public IMasterTempAdditionalByGradePackRepo MasterTempAdditionalByGradePackRepo
        { get { return new MasterTempAdditionalByGradePackRepo(_context, _readContext); } }

        public IMasterMarketPriceGapRepo MasterMarketPriceGapRepo
        { get { return new MasterMarketPriceGapRepo(_context, _readContext); } }
        public IMasterTempMarketPriceGapRepo MasterTempMarketPriceGapRepo
        { get { return new MasterTempMarketPriceGapRepo(_context, _readContext); } }
        public IMasterAdditionalByPackRepo MasterAdditionalByPackRepo
        { get { return new MasterAdditionalByPackRepo(_context, _readContext); } }
        public IMasterTempAdditionalByPackRepo MasterTempAdditionalByPackRepo
        { get { return new MasterTempAdditionalByPackRepo(_context, _readContext); } }
        public IMasterMonomerExportExpenseRepo MasterMonomerExportExpenseRepo
        { get { return new MasterMonomerExportExpenseRepo(_context, _readContext); } }
        public IMasterTempMonomerExportExpenseRepo MasterTempMonomerExportExpenseRepo
        { get { return new MasterTempMonomerExportExpenseRepo(_context, _readContext); } }
        public IMasterMonomerPriceRepo MasterMonomerPriceRepo
        { get { return new MasterMonomerPriceRepo(_context, _readContext); } }
        public IMasterTempMonomerPriceRepo MasterTempMonomerPriceRepo
        { get { return new MasterTempMonomerPriceRepo(_context, _readContext); } }
        public IMasterExchangeRateRepo MasterExchangeRateRepo
        { get { return new MasterExchangeRateRepo(_context, _readContext); } }
        public IMasterTempExchangeRateRepo MasterTempExchangeRateRepo
        { get { return new MasterTempExchangeRateRepo(_context, _readContext); } }
        public IMasterRMRollingRepo MasterRMRollingRepo
        { get { return new MasterRMRollingRepo(_context, _readContext); } }
        public IMasterTempRMRollingRepo MasterTempRMRollingRepo
        { get { return new MasterTempRMRollingRepo(_context, _readContext); } }
        public IMasterStandardLineRepo MasterStandardLineRepo
        { get { return new MasterStandardLineRepo(_context, _readContext); } }
        public IMasterTempStandardLineRepo MasterTempStandardLineRepo
        { get { return new MasterTempStandardLineRepo(_context, _readContext); } }
        public IMasterMoveMappingByGradeRepo MasterMoveMappingByGradeRepo
        { get { return new MasterMoveMappingByGradeRepo(_context, _readContext); } }
        public IMasterTempMoveMappingByGradeRepo MasterTempMoveMappingByGradeRepo
        { get { return new MasterTempMoveMappingByGradeRepo(_context, _readContext); } }

        public IMasterWaxAllocationRepo MasterWaxAllocationRepo
        { get { return new MasterWaxAllocationRepo(_context, _readContext); } }
        public IMasterTempWaxAllocationRepo MasterTempWaxAllocationRepo
        { get { return new MasterTempWaxAllocationRepo(_context, _readContext); } }

        public IMasterPriceGapRepo MasterPriceGapRepo
        { get { return new MasterPriceGapRepo(_context, _readContext); } }
        public IMasterTempPriceGapRepo MasterTempPriceGapRepo
        { get { return new MasterTempPriceGapRepo(_context, _readContext); } }
        public IMasterFreightSubRegionRepo MasterFreightSubRegionRepo
        { get { return new MasterFreightSubRegionRepo(_context, _readContext); } }
        public IMasterTempFreightSubRegionRepo MasterTempFreightSubRegionRepo
        { get { return new MasterTempFreightSubRegionRepo(_context, _readContext); } }
        public IMasterAdditionalByCustomerRepo MasterAdditionalByCustomerRepo
        { get { return new MasterAdditionalByCustomerRepo(_context, _readContext); } }
        public IMasterTempAdditionalByCustomerRepo MasterTempAdditionalByCustomerRepo
        { get { return new MasterTempAdditionalByCustomerRepo(_context, _readContext); } }
        public IMasterCPDGradeAttrRepo MasterCPDGradeAttrRepo
        { get { return new MasterCPDGradeAttrRepo(_context, _readContext); } }
        public IMasterTempCPDGradeAttrRepo MasterTempCPDGradeAttrRepo
        { get { return new MasterTempCPDGradeAttrRepo(_context, _readContext); } }
        public IMasterActualHedgingRepo MasterActualHedgingRepo
        { get { return new MasterActualHedgingRepo(_context, _readContext); } }
        public IMasterTempActualHedgingRepo MasterTempActualHedgingRepo
        { get { return new MasterTempActualHedgingRepo(_context, _readContext); } }
        public IMasterRawMatGapRepo MasterRawMatGapRepo
        { get { return new MasterRawMatGapRepo(_context, _readContext); } }
        public IMasterTempRawMatGapRepo MasterTempRawMatGapRepo
        { get { return new MasterTempRawMatGapRepo(_context, _readContext); } }
        public IMasterManualCostRotoRepo MasterManualCostRotoRepo
        { get { return new MasterManualCostRotoRepo(_context, _readContext); } }
        public IMasterTempManualCostRotoRepo MasterTempManualCostRotoRepo
        { get { return new MasterTempManualCostRotoRepo(_context, _readContext); } }
        public IMasterTariffDestinationDeliveryCostRepo MasterTariffDestinationDeliveryCostRepo
        { get { return new MasterTariffDestinationDeliveryCostRepo(_context, _readContext); } }
        public IMasterTempTariffDestinationDeliveryCostRepo MasterTempTariffDestinationDeliveryCostRepo
        { get { return new MasterTempTariffDestinationDeliveryCostRepo(_context, _readContext); } }
        public IMasterOtherCostRepo MasterOtherCostRepo
        { get { return new MasterOtherCostRepo(_context, _readContext); } }
        public IMasterTempOtherCostRepo MasterTempOtherCostRepo
        { get { return new MasterTempOtherCostRepo(_context, _readContext); } }
        public IMasterMultisiteRotoRepo MasterMultisiteRotoRepo
        { get { return new MasterMultisiteRotoRepo(_context, _readContext); } }
        public IMasterTempMultisiteRotoRepo MasterTempMultisiteRotoRepo
        { get { return new MasterTempMultisiteRotoRepo(_context, _readContext); } }

        public IMasterManualAdjustCostGradeLineRepo MasterManualAdjustCostGradeLineRepo
        { get { return new MasterManualAdjustCostGradeLineRepo(_context, _readContext); } }
        public IMasterTempManualAdjustCostGradeLineRepo MasterTempManualAdjustCostGradeLineRepo
        { get { return new MasterTempManualAdjustCostGradeLineRepo(_context, _readContext); } }

        public IMasterOperationChargeRepo MasterOperationChargeRepo
        { get { return new MasterOperationChargeRepo(_context, _readContext); } }
        public IMasterTempOperationChargeRepo MasterTempOperationChargeRepo
        { get { return new MasterTempOperationChargeRepo(_context, _readContext); } }

        public IMasterDeliveryByZoneRepo MasterDeliveryByZoneRepo
        { get { return new MasterDeliveryByZoneRepo(_context, _readContext); } }
        public IMasterTempDeliveryByZoneRepo MasterTempDeliveryByZoneRepo
        { get { return new MasterTempDeliveryByZoneRepo(_context, _readContext); } }

        public IMasterPolymerPriceRepo MasterPolymerPriceRepo
        { get { return new MasterPolymerPriceRepo(_context, _readContext); } }
        public IMasterTempPolymerPriceRepo MasterTempPolymerPriceRepo
        { get { return new MasterTempPolymerPriceRepo(_context, _readContext); } }

        public IMasterMappingWaxGroupByGradeRepo MasterMappingWaxGroupByGradeRepo
        { get { return new MasterMappingWaxGroupByGradeRepo(_context, _readContext); } }
        public IMasterTempMappingWaxGroupByGradeRepo MasterTempMappingWaxGroupByGradeRepo
        { get { return new MasterTempMappingWaxGroupByGradeRepo(_context, _readContext); } }
        public IMasterPlanningGroupRepo MasterPlanningGroupRepo
        { get { return new MasterPlanningGroupRepo(_context, _readContext); } }
        public IMasterNewProductFlagRepo MasterNewProductFlagRepo
        { get { return new MasterNewProductFlagRepo(_context, _readContext); } }

        public IMasterRefGradeRepo MasterRefGradeRepo
        { get { return new MasterRefGradeRepo(_context, _readContext); } }
        public IMasterPPRCostValidationRepo MasterPPRCostValidationRepo
        { get { return new MasterPPRCostValidationRepo(_context, _readContext); } }
        public IMasterPPRPackageCostByGradePackageRepo MasterPPRPackageCostByGradePackageRepo
        { get { return new MasterPPRPackageCostByGradePackageRepo(_context, _readContext); } }
        public IMasterPPRPackageCostByGradePackageLSPRepo MasterPPRPackageCostByGradePackageLSPRepo
        { get { return new MasterPPRPackageCostByGradePackageLSPRepo(_context, _readContext); } }
        public IFCTBusinessPartnerRepo FCTBusinessPartnerRepo
        { get { return new FCTBusinessPartnerRepo(_context, _readContext); } }
        public IMasterCustomerDummyRepo MasterCustomerDummyRepo
        { get { return new MasterCustomerDummyRepo(_context, _readContext); } }
        public IMasterAvailableProductionLineByPlanningGroupAndPlanTypeRepo MasterAvailableProductionLineByPlanningGroupAndPlanTypeRepo
        { get { return new MasterAvailableProductionLineByPlanningGroupAndPlanTypeRepo(_context, _readContext); } }
        public IMasterHVASegmentRepo MasterHVASegmentRepo
        { get { return new MasterHVASegmentRepo(_context, _readContext); } }
        public IMasterHVASalesGroupDummyCustomerRepo MasterHVASalesGroupDummyCustomerRepo
        { get { return new MasterHVASalesGroupDummyCustomerRepo(_context, _readContext); } }
        public IMasterHVASalesGroupGradeRepo MasterHVASalesGroupGradeRepo
        { get { return new MasterHVASalesGroupGradeRepo(_context, _readContext); } }
        public IMasterStockTypeRepo MasterStockTypeRepo
        { get { return new MasterStockTypeRepo(_context, _readContext); } }

        public IMasterAFPStandardEarnRepo MasterAFPStandardEarnRepo
        { get { return new MasterAFPStandardEarnRepo(_context, _readContext); } }
        public IMasterTempAFPStandardEarnRepo MasterTempAFPStandardEarnRepo
        { get { return new MasterTempAFPStandardEarnRepo(_context, _readContext); } }

        public IMasterWaxViscosityPercentRepo MasterWaxViscosityPercentRepo
        { get { return new MasterWaxViscosityPercentRepo(_context, _readContext); } }
        public IMasterTempWaxViscosityPercentRepo MasterTempWaxViscosityPercentRepo
        { get { return new MasterTempWaxViscosityPercentRepo(_context, _readContext); } }
        public IMasterRevisionRepo MasterRevisionRepo
        { get { return new MasterRevisionRepo(_context, _readContext); } }
        public IMasterMonomerTypeRepo MasterMonomerTypeRepo
        { get { return new MasterMonomerTypeRepo(_context, _readContext); } }
        public IMasterByPassMinLogicRepo MasterByPassMinLogicRepo
        { get { return new MasterByPassMinLogicRepo(_context, _readContext); } }
        public IMasterHistoryTypeRepo MasterHistoryTypeRepo
        { get { return new MasterHistoryTypeRepo(_context, _readContext); } }
        public IMasterUsersRepo MasterUsersRepo
        { get { return new MasterUsersRepo(_context, _readContext); } }
        public IMasterPageRepo MasterPageRepo
        { get { return new MasterPageRepo(_context, _readContext); } }
         public IMasterCountryMasterRepo MasterCountryMasterRepo
        { get { return new MasterCountryMasterRepo(_context, _readContext); } }

        public ITransactionMinbibleRepo TransactionMinbibleRepo
        { get { return new TransactionMinbibleRepo(_context, _readContext); } }
        public ITransactionNonPrimeRepo TransactionNonPrimeRepo
        { get { return new TransactionNonPrimeRepo(_context, _readContext); } }
        public ITransactionMasterBatchRepo TransactionMasterBatchRepo
        { get { return new TransactionMasterBatchRepo(_context, _readContext); } }
        public ITransactionUnconstraintSalesPlanRepo TransactionUnconstraintSalesPlanRepo
        { get { return new TransactionUnconstraintSalesPlanRepo(_context, _readContext); } }
        public ITransactionLockUnlockCycleRepo TransactionLockUnlockCycleRepo
        { get { return new TransactionLockUnlockCycleRepo(_context, _readContext); } }
        public ITransactionLockUnlockUnconstraintRepo TransactionLockUnlockUnconstraintRepo
        { get { return new TransactionLockUnlockUnconstraintRepo(_context, _readContext); } }
        public ITransactionLockUnlockConstraintRepo TransactionLockUnlockConstraintRepo
        { get { return new TransactionLockUnlockConstraintRepo(_context, _readContext); } }
        public ITransactionConstraintSalesPlanRepo TransactionConstraintSalesPlanRepo
        { get { return new TransactionConstraintSalesPlanRepo(_context, _readContext); } }

        public ITransactionProductionPlanRepo TransactionProductionPlanRepo
        { get { return new TransactionProductionPlanRepo(_context, _readContext); } }
        public ITransactionMonomerAvailableConspRepo TransactionMonomerAvailableConspRepo
        { get { return new TransactionMonomerAvailableConspRepo(_context, _readContext); } }
        public ITransactionNewProjectRegisRepo TransactionNewProjectRegisRepo
        { get { return new TransactionNewProjectRegisRepo(_context, _readContext); } }
        public IMasterValTypeToProductionLineRepo MasterValTypeToProductionLineRepo
        { get { return new MasterValTypeToProductionLineRepo(_context, _readContext); } }

        public ITransactionCalculatePriceSaleRepo TransactionCalculatePriceSaleRepo
        { get { return new TransactionCalculatePriceSaleRepo(_context, _readContext); } }

        #endregion Repository

        #region View Repo

        #region export

        public IViewFreightExportRepo ViewFreightExportRepo
        { get { return new ViewFreightExportRepo(_context, _readContext); } }
        public IViewFreightSubRegionExportRepo ViewFreightSubRegionExportRepo
        { get { return new ViewFreightSubRegionExportRepo(_context, _readContext); } }
        public IViewDeliveryCostFlagExportRepo ViewDeliveryCostFlagExportRepo
        { get { return new ViewDeliveryCostFlagExportRepo(_context, _readContext); } }
        public IViewDeliveryCostExportRepo ViewDeliveryCostExportRepo
        { get { return new ViewDeliveryCostExportRepo(_context, _readContext); } }
        public IViewAdditionalByCustomerExportRepo ViewAdditionalByCustomerExportRepo
        { get { return new ViewAdditionalByCustomerExportRepo(_context, _readContext); } }
        public IViewAdditionalByGradePackExportRepo ViewAdditionalByGradePackExportRepo
        { get { return new ViewAdditionalByGradePackExportRepo(_context, _readContext); } }
        public IViewAdditionalByPackExportRepo ViewAdditionalByPackExportRepo
        { get { return new ViewAdditionalByPackExportRepo(_context, _readContext); } }
        public IViewCPDGradeAttrExportRepo ViewCPDGradeAttrExportRepo
        { get { return new ViewCPDGradeAttrExportRepo(_context, _readContext); } }
        public IViewManualAdjustCostGradeLineExportRepo ViewManualAdjustCostGradeLineExportRepo
        { get { return new ViewManualAdjustCostGradeLineExportRepo(_context, _readContext); } }
        public IViewMonomerExportExpenseExportRepo ViewMonomerExportExpenseExportRepo
        { get { return new ViewMonomerExportExpenseExportRepo(_context, _readContext); } }
        public IViewRawMatGapExportRepo ViewRawMatGapExportRepo
        { get { return new ViewRawMatGapExportRepo(_context, _readContext); } }
        public IViewMarketPriceGapExportRepo ViewMarketPriceGapExportRepo
        { get { return new ViewMarketPriceGapExportRepo(_context, _readContext); } }
        public IViewMonomerPriceExportRepo ViewMonomerPriceExportRepo
        { get { return new ViewMonomerPriceExportRepo(_context, _readContext); } }
        public IViewActualHedgingExportRepo ViewActualHedgingExportRepo
        { get { return new ViewActualHedgingExportRepo(_context, _readContext); } }
        public IViewWaxAllocationExportRepo ViewWaxAllocationExportRepo
        { get { return new ViewWaxAllocationExportRepo(_context, _readContext); } }
        public IViewExchangeRateExportRepo ViewExchangeRateExportRepo
        { get { return new ViewExchangeRateExportRepo(_context, _readContext); } }
        public IViewOtherCostExportRepo ViewOtherCostExportRepo
        { get { return new ViewOtherCostExportRepo(_context, _readContext); } }
        public IViewOperationChargeExportRepo ViewOperationChargeExportRepo
        { get { return new ViewOperationChargeExportRepo(_context, _readContext); } }
        public IViewRMRollingExportRepo ViewRMRollingExportRepo
        { get { return new ViewRMRollingExportRepo(_context, _readContext); } }
        public IViewManualCostRotoExportRepo ViewManualCostRotoExportRepo
        { get { return new ViewManualCostRotoExportRepo(_context, _readContext); } }
        public IViewPriceGapExportRepo ViewPriceGapExportRepo
        { get { return new ViewPriceGapExportRepo(_context, _readContext); } }
        public IViewImportRMRotoExportRepo ViewImportRMRotoExportRepo
        { get { return new ViewImportRMRotoExportRepo(_context, _readContext); } }
        public IViewMultisiteRotoExportRepo ViewMultisiteRotoExportRepo
        { get { return new ViewMultisiteRotoExportRepo(_context, _readContext); } }
        public IViewPolymerPriceExportRepo ViewPolymerPriceExportRepo
        { get { return new ViewPolymerPriceExportRepo(_context, _readContext); } }
        public IViewStandardLineExportRepo ViewStandardLineExportRepo
        { get { return new ViewStandardLineExportRepo(_context, _readContext); } }
        public IViewTariffDestinationDeliveryCostExportRepo ViewTariffDestinationDeliveryCostExportRepo
        { get { return new ViewTariffDestinationDeliveryCostExportRepo(_context, _readContext); } }
        public IViewDeliveryByZoneExportRepo ViewDeliveryByZoneExportRepo
        { get { return new ViewDeliveryByZoneExportRepo(_context, _readContext); } }
        public IViewMoveMappingByGradeExportRepo ViewMoveMappingByGradeExportRepo
        { get { return new ViewMoveMappingByGradeExportRepo(_context, _readContext); } }
        public IViewMappingWaxGroupByGradeExportRepo ViewMappingWaxGroupByGradeExportRepo
        { get { return new ViewMappingWaxGroupByGradeExportRepo(_context, _readContext); } }
        public IViewAFPStandardEarnExportRepo ViewAFPStandardEarnExportRepo
        { get { return new ViewAFPStandardEarnExportRepo(_context, _readContext); } }
        public IViewWaxViscosityPercentExportRepo ViewWaxViscosityPercentExportRepo
        { get { return new ViewWaxViscosityPercentExportRepo(_context, _readContext); } }

        #endregion export

        #region template

        public IViewFreightTemplateRepo ViewFreightTemplateRepo
        { get { return new ViewFreightTemplateRepo(_context, _readContext); } }
        public IViewFreightSubRegionTemplateRepo ViewFreightSubRegionTemplateRepo
        { get { return new ViewFreightSubRegionTemplateRepo(_context, _readContext); } }
        public IViewDeliveryCostFlagTemplateRepo ViewDeliveryCostFlagTemplateRepo
        { get { return new ViewDeliveryCostFlagTemplateRepo(_context, _readContext); } }
        public IViewDeliveryCostTemplateRepo ViewDeliveryCostTemplateRepo
        { get { return new ViewDeliveryCostTemplateRepo(_context, _readContext); } }
        public IViewAdditionalByCustomerTemplateRepo ViewAdditionalByCustomerTemplateRepo
        { get { return new ViewAdditionalByCustomerTemplateRepo(_context, _readContext); } }
        public IViewAdditionalByGradePackTemplateRepo ViewAdditionalByGradePackTemplateRepo
        { get { return new ViewAdditionalByGradePackTemplateRepo(_context, _readContext); } }
        public IViewAdditionalByPackTemplateRepo ViewAdditionalByPackTemplateRepo
        { get { return new ViewAdditionalByPackTemplateRepo(_context, _readContext); } }
        public IViewCPDGradeAttrTemplateRepo ViewCPDGradeAttrTemplateRepo
        { get { return new ViewCPDGradeAttrTemplateRepo(_context, _readContext); } }
        public IViewManualAdjustCostGradeLineTemplateRepo ViewManualAdjustCostGradeLineTemplateRepo
        { get { return new ViewManualAdjustCostGradeLineTemplateRepo(_context, _readContext); } }
        public IViewMonomerExportExpenseTemplateRepo ViewMonomerExportExpenseTemplateRepo
        { get { return new ViewMonomerExportExpenseTemplateRepo(_context, _readContext); } }
        public IViewRawMatGapTemplateRepo ViewRawMatGapTemplateRepo
        { get { return new ViewRawMatGapTemplateRepo(_context, _readContext); } }
        public IViewMarketPriceGapTemplateRepo ViewMarketPriceGapTemplateRepo
        { get { return new ViewMarketPriceGapTemplateRepo(_context, _readContext); } }
        public IViewMonomerPriceTemplateRepo ViewMonomerPriceTemplateRepo
        { get { return new ViewMonomerPriceTemplateRepo(_context, _readContext); } }
        public IViewActualHedgingTemplateRepo ViewActualHedgingTemplateRepo
        { get { return new ViewActualHedgingTemplateRepo(_context, _readContext); } }
        public IViewWaxAllocationTemplateRepo ViewWaxAllocationTemplateRepo
        { get { return new ViewWaxAllocationTemplateRepo(_context, _readContext); } }
        public IViewExchangeRateTemplateRepo ViewExchangeRateTemplateRepo
        { get { return new ViewExchangeRateTemplateRepo(_context, _readContext); } }
        public IViewOtherCostTemplateRepo ViewOtherCostTemplateRepo
        { get { return new ViewOtherCostTemplateRepo(_context, _readContext); } }
        public IViewOperationChargeTemplateRepo ViewOperationChargeTemplateRepo
        { get { return new ViewOperationChargeTemplateRepo(_context, _readContext); } }
        public IViewRMRollingTemplateRepo ViewRMRollingTemplateRepo
        { get { return new ViewRMRollingTemplateRepo(_context, _readContext); } }
        public IViewManualCostRotoTemplateRepo ViewManualCostRotoTemplateRepo
        { get { return new ViewManualCostRotoTemplateRepo(_context, _readContext); } }
        public IViewPriceGapTemplateRepo ViewPriceGapTemplateRepo
        { get { return new ViewPriceGapTemplateRepo(_context, _readContext); } }
        public IViewImportRMRotoTemplateRepo ViewImportRMRotoTemplateRepo
        { get { return new ViewImportRMRotoTemplateRepo(_context, _readContext); } }
        public IViewMultisiteRotoTemplateRepo ViewMultisiteRotoTemplateRepo
        { get { return new ViewMultisiteRotoTemplateRepo(_context, _readContext); } }
        public IViewPolymerPriceTemplateRepo ViewPolymerPriceTemplateRepo
        { get { return new ViewPolymerPriceTemplateRepo(_context, _readContext); } }
        public IViewStandardLineTemplateRepo ViewStandardLineTemplateRepo
        { get { return new ViewStandardLineTemplateRepo(_context, _readContext); } }
        public IViewTariffDestinationDeliveryCostTemplateRepo ViewTariffDestinationDeliveryCostTemplateRepo
        { get { return new ViewTariffDestinationDeliveryCostTemplateRepo(_context, _readContext); } }
        public IViewDeliveryByZoneTemplateRepo ViewDeliveryByZoneTemplateRepo
        { get { return new ViewDeliveryByZoneTemplateRepo(_context, _readContext); } }
        public IViewMoveMappingByGradeTemplateRepo ViewMoveMappingByGradeTemplateRepo
        { get { return new ViewMoveMappingByGradeTemplateRepo(_context, _readContext); } }
        public IViewMappingWaxGroupByGradeTemplateRepo ViewMappingWaxGroupByGradeTemplateRepo
        { get { return new ViewMappingWaxGroupByGradeTemplateRepo(_context, _readContext); } }
        public IViewAFPStandardEarnTemplateRepo ViewAFPStandardEarnTemplateRepo
        { get { return new ViewAFPStandardEarnTemplateRepo(_context, _readContext); } }
        public IViewWaxViscosityPercentTemplateRepo ViewWaxViscosityPercentTemplateRepo
        { get { return new ViewWaxViscosityPercentTemplateRepo(_context, _readContext); } }

        #endregion template

        #region account

        public IViewLSPConstraintSalesPlanRepo ViewLSPConstraintSalesPlanRepo
        { get { return new ViewLSPConstraintSalesPlanRepo(_context, _readContext); } }
        public IViewLSPExchangeRateRepo ViewLSPExchangeRateRepo
        { get { return new ViewLSPExchangeRateRepo(_context, _readContext); } }
        public IViewLSPMarketPriceRepo ViewLSPMarketPriceRepo
        { get { return new ViewLSPMarketPriceRepo(_context, _readContext); } }
        public IViewLSPMonomerPriceRepo ViewLSPMonomerPriceRepo
        { get { return new ViewLSPMonomerPriceRepo(_context, _readContext); } }
        public IViewLSPProductPlanRepo ViewLSPProductPlanRepo
        { get { return new ViewLSPProductPlanRepo(_context, _readContext); } }
        public IViewLSPRMPriceRepo ViewLSPRMPriceRepo
        { get { return new ViewLSPRMPriceRepo(_context, _readContext); } }
        public IViewLSPMonomerAvailableComspRMPrice ViewLSPMonomerAvailableComspRMPrice
        { get { return new ViewLSPMonomerAvailableComspRMPrice(_context, _readContext); } }

        #endregion account

        #region transaction

        public IViewTransactionUnconstraintSellingPriceSiloTHRepo ViewTransactionUnconstraintSellingPriceSiloTHRepo
        { get { return new ViewTransactionUnconstraintSellingPriceSiloTHRepo(_context, _readContext); } }
        public IViewTransactionUnconstraintSellingPriceSiloVNRepo ViewTransactionUnconstraintSellingPriceSiloVNRepo
        { get { return new ViewTransactionUnconstraintSellingPriceSiloVNRepo(_context, _readContext); } }
        public IViewMarketPriceAtSiloRepo ViewMarketPriceAtSiloRepo
        { get { return new ViewMarketPriceAtSiloRepo(_context, _readContext); } }
        public IViewTransactionConstraintSellingPriceSiloTHRepo ViewTransactionConstraintSellingPriceSiloTHRepo
        { get { return new ViewTransactionConstraintSellingPriceSiloTHRepo(_context, _readContext); } }
        public IViewTransactionConstraintSellingPriceSiloVNRepo ViewTransactionConstraintSellingPriceSiloVNRepo
        { get { return new ViewTransactionConstraintSellingPriceSiloVNRepo(_context, _readContext); } }
        public IViewValTypeToProductionLineRepo ViewValTypeToProductionLineRepo
        { get { return new ViewValTypeToProductionLineRepo(_context, _readContext); } }
        public IViewTransactionCalculatePriceSaleRepo ViewTransactionCalculatePriceSaleRepo
        { get { return new ViewTransactionCalculatePriceSaleRepo(_context, _readContext); } }

        #endregion transaction

        #endregion View Repo

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveTransaction()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.SaveChanges();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}