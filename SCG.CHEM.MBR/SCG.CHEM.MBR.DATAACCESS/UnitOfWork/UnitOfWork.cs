using Microsoft.EntityFrameworkCore.Storage;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.Repository.Logging;
using SCG.CHEM.MBR.DATAACCESS.Repository.Logging.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Relate;
using SCG.CHEM.MBR.DATAACCESS.Repository.Relate.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface;
using SCG.CHEM.MBR.DATAACCESS.Repository.Views.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Views.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System.Transactions;

namespace SCG.CHEM.MBR.DATAACCESS.UnitOfWork
{
    public class UnitOfWork
    {
        #region Inject

        private readonly EntitiesMBRContext _context;
        private readonly AppSettings _appsettings;
        private readonly EntitiesMBRReadContext _readContext;

        public UnitOfWork(EntitiesMBRContext context, EntitiesMBRReadContext readContext, AppSettings appsettings)
        {
            this._context = context;
            this._appsettings = appsettings;
            this._readContext = readContext;
        }

        #endregion Inject

        #region Repository

        #region Master

        public ISaleConfirmRepo SaleConfirmRepo
        { get { return new SaleConfirmRepo(_context, _readContext); } }

        public IMasterRepo MasterRepo
        { get { return new MasterRepo(_context, _readContext); } }

        public IMasterConfigRepo MasterConfigRepo
        { get { return new MasterConfigRepo(_context, _readContext); } }

        public IMasterDeleteFlagRepo MasterDeleteFlagRepo
        { get { return new MasterDeleteFlagRepo(_context, _readContext); } }

        public IMasterGroupRepo MasterGroupRepo
        { get { return new MasterGroupRepo(_context, _readContext); } }

        public IMasterMappingRepo MasterMappingRepo
        { get { return new MasterMappingRepo(_context, _readContext); } }

        public IMasterExcelMappingRepo MasterExcelMappingRepo
        { get { return new MasterExcelMappingRepo(_context, _readContext); } }

        public IMasterMenuRepo MasterMenuRepo
        { get { return new MasterMenuRepo(_context, _readContext); } }

        public IMasterPageRepo MasterPageRepo
        { get { return new MasterPageRepo(_context, _readContext); } }

        public IMasterRoleRepo MasterRoleRepo
        { get { return new MasterRoleRepo(_context, _readContext); } }

        public IMasterUserProfileRepo MasterUserProfileRepo
        { get { return new MasterUserProfileRepo(_context, _readContext); } }

        public IMasterUsersRepo MasterUsersRepo
        { get { return new MasterUsersRepo(_context, _readContext); } }

        public IMasterExportMappingRepo MasterExportMappingRepo
        { get { return new MasterExportMappingRepo(_context, _readContext); } }

        public IGroupRoleRepo GroupRoleRepo
        { get { return new GroupRoleRepo(_context, _readContext); } }

        public IUserGroupRepo UserGroupRepo
        { get { return new UserGroupRepo(_context, _readContext); } }

        public IUserRoleRepo UserRoleRepo
        { get { return new UserRoleRepo(_context, _readContext); } }

        public ILogApiRepo LogApiRepo
        { get { return new LogApiRepo(_context, _readContext); } }

        public ILogSendDWHRepo LogSendDWHRepo
        { get { return new LogSendDWHRepo(_context, _readContext); } }

        public IDataFactoryRunRepo DataFactoryRunRepo
        { get { return new DataFactoryRunRepo(_context, _readContext); } }

        public IMasterProductMappingRepo MasterProductMappingRepo
        { get { return new MasterProductMappingRepo(_context, _readContext); } }

        public IMasterCustomerVendorMappingRepo MasterCustomerVendorMappingRepo
        { get { return new MasterCustomerVendorMappingRepo(_context, _readContext); } }

        public IMasterCaseRepo MasterCaseRepo
        { get { return new MasterCaseRepo(_context, _readContext); } }

        public IMasterLSPPriceFormulaRepo MasterLSPPriceFormulaRepo
        { get { return new MasterLSPPriceFormulaRepo(_context, _readContext); } }

        public IMasterMarketPriceMappingRepo MasterMarketPriceMappingRepo
        { get { return new MasterMarketPriceMappingRepo(_context, _readContext); } }

        public IMasterScenarioRepo MasterScenarioRepo
        { get { return new MasterScenarioRepo(_context, _readContext); } }

        public IMasterFormulaParameterMappingRepo MasterFormulaParameterMappingRepo
        { get { return new MasterFormulaParameterMappingRepo(_context, _readContext); } }

        public IFctMarketPriceOlefinsRepo FctMarketPriceOlefinsRepo
        { get { return new FctMarketPriceOlefinsRepo(_context, _readContext); } }

        public IMasterOptienceTypeRepo MasterOptienceTypeRepo
        { get { return new MasterOptienceTypeRepo(_context, _readContext); } }

        public IMasterCompanyRepo MasterCompanyRepo
        { get { return new MasterCompanyRepo(_context, _readContext); } }

        public IMasterMaintainPriceRepo MasterMaintainPriceRepo
        { get { return new MasterMaintainPriceRepo(_context, _readContext); } }

        public IMasterHistoryTypeRepo MasterHistoryTypeRepo
        { get { return new MasterHistoryTypeRepo(_context, _readContext); } }

        public IMasterPlanTypeRepo MasterPlanTypeRepo
        { get { return new MasterPlanTypeRepo(_context, _readContext); } }

        public IMasterOptienceRepo MasterOptienceRepo
        { get { return new MasterOptienceRepo(_context, _readContext); } }

        public ILockUnlockCycleRepo LockUnlockCycleRepo
        { get { return new LockUnlockCycleRepo(_context, _readContext); } }

        public IMasterExcelRepo MasterExcelRepo
        { get { return new MasterExcelRepo(_context, _readContext); } }

        public IAssumptionRepo AssumptionRepo
        { get { return new AssumptionRepo(_context, _readContext); } }

        #endregion Master

        #region Temp

        #region Master Temp

        public IMasterTempProductMappingRepo MasterTempProductMappingRepo
        { get { return new MasterTempProductMappingRepo(_context, _readContext); } }

        public IMasterTempCustomerVendorMappingRepo MasterTempCustomerVendorMappingRepo
        { get { return new MasterTempCustomerVendorMappingRepo(_context, _readContext); } }

        public IMasterTempLSPPriceFormulaRepo MasterTempLSPPriceFormulaRepo
        { get { return new MasterTempLSPPriceFormulaRepo(_context, _readContext); } }

        public IMasterTempMarketPriceMappingRepo MasterTempMarketPriceMappingRepo
        { get { return new MasterTempMarketPriceMappingRepo(_context, _readContext); } }

        #endregion Master Temp

        public IMarketPriceForecastTempRepo MarketPriceForecastTempRepo
        { get { return new MarketPriceForecastTempRepo(_context, _readContext); } }

        public IProductionVolumeTempRepo ProductionVolumeTempRepo
        { get { return new ProductionVolumeTempRepo(_context, _readContext); } }

        public IBeginningInventoryTempRepo BeginningInventoryTempRepo
        { get { return new BeginningInventoryTempRepo(_context, _readContext); } }

        public IFeedConsumptionTempRepo FeedConsumptionTempRepo
        { get { return new FeedConsumptionTempRepo(_context, _readContext); } }

        public IFeedPurchaseTempRepo FeedPurchaseTempRepo
        { get { return new FeedPurchaseTempRepo(_context, _readContext); } }

        public ISalesVoiumeTempRepo SalesVoiumeTempRepo
        { get { return new SalesVoiumeTempRepo(_context, _readContext); } }

        public IFeedInfoTempRepo FeedInfoTempRepo
        { get { return new FeedInfoTempRepo(_context, _readContext); } }

        public IMasterTempSalesPreviewSubmitRepo MasterTempSalesPreviewSubmitRepo
        { get { return new MasterTempSalesPreviewSubmitRepo(_context, _readContext); } }

        public IAssumptionTempRepo AssumptionTempRepo
        { get { return new AssumptionTempRepo(_context, _readContext); } }

        #endregion Temp

        #region View

        public IViewProductMappingRepo ViewProductMappingRepo
        { get { return new ViewProductMappingRepo(_context, _readContext); } }

        public IViewLSPPriceFormulaRepo ViewLSPPriceFormulaRepo
        { get { return new ViewLSPPriceFormulaRepo(_context, _readContext); } }

        public IViewCustomerVendorMappingRepo ViewCustomerVendorMappingRepo
        { get { return new ViewCustomerVendorMappingRepo(_context, _readContext); } }

        public IViewMarketPriceMappingRepo ViewMarketPriceMappingRepo
        { get { return new ViewMarketPriceMappingRepo(_context, _readContext); } }

        #endregion View

        #region Transaction

        public IMarketPriceForecastRepo MarketPriceForecastRepo
        { get { return new MarketPriceForecastRepo(_context, _readContext); } }

        public IBeginningInventoryRepo BeginningInventoryRepo
        { get { return new BeginningInventoryRepo(_context, _readContext); } }

        public IFeedConsumptionRepo FeedConsumptionRepo
        { get { return new FeedConsumptionRepo(_context, _readContext); } }

        public IFeedPurchaseRepo FeedPurchaseRepo
        { get { return new FeedPurchaseRepo(_context, _readContext); } }

        public IProductionVolumeRepo ProductionVolumeRepo
        { get { return new ProductionVolumeRepo(_context, _readContext); } }

        public ISalesVoiumeRepo SalesVoiumeRepo
        { get { return new SalesVoiumeRepo(_context, _readContext); } }

        public IFeedInfoRepo FeedInfoRepo
        { get { return new FeedInfoRepo(_context, _readContext); } }

        public IMergeHistoryRepo MergeHistoryRepo
        { get { return new MergeHistoryRepo(_context, _readContext); } }

        #endregion Transaction

        #endregion Repository

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

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}