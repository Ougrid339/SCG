using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Relate;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Views.Master;
using System.Data.Common;

namespace SCG.CHEM.MBR.DATAACCESS
{
    public class EntitiesMBRContext : DbContext
    {
        public AppSettings _AppSettings;

        public EntitiesMBRContext(DbContextOptions<EntitiesMBRContext> options, AppSettings appSettings) : base(options)
        {
            _AppSettings = appSettings;
        }

        protected EntitiesMBRContext(DbContextOptions options, AppSettings appSettings) : base(options)
        {
        }

        #region Database model

        public virtual DbSet<MST_USER_PROFILE> MST_USER_PROFILEs { get; set; }
        public virtual DbSet<MST_ROLE> MST_ROLEs { get; set; }
        public virtual DbSet<MST_GROUP> MST_GROUPs { get; set; }
        public virtual DbSet<MST_MENU> MST_MENUs { get; set; }

        public virtual DbSet<REL_MENU_ROLE> REL_MENU_ROLEs { get; set; }
        public virtual DbSet<REL_GROUP_ROLE> REL_GROUP_ROLEs { get; set; }
        public virtual DbSet<REL_USER_GROUP> REL_USER_GROUPs { get; set; }
        public virtual DbSet<REL_USER_ROLE> REL_USER_ROLEs { get; set; }

        #region Master

        public virtual DbSet<MST_CONFIG> MST_CONFIGs { get; set; }
        public virtual DbSet<MBR_MST_USERS> MBR_MST_USERSs { get; set; }
        public virtual DbSet<MBR_MST_ROLES> MBR_MST_ROLESs { get; set; }
        public virtual DbSet<MBR_MST_PAGES> MBR_MST_PAGESs { get; set; }

        public virtual DbSet<MBR_MST_SALECONFIRM> MBR_MST_SALECONFIRMs { get; set; }
        public virtual DbSet<MBR_MST_LOCKUNLOCKCYCLE> MBR_MST_LOCKUNLOCKCYCLEs { get; set; }
        public virtual DbSet<MBR_FCT_MARKETPRICEOLEFINS> MBR_FCT_MARKETPRICEOLEFINs { get; set; }

        public virtual DbSet<MBR_MST_PRODUCT_MAPPING> MBR_MST_PRODUCT_MAPPINGs { get; set; }
        public virtual DbSet<MBR_MST_CUSTOMER_VENDOR_MAPPING> MBR_MST_CUSTOMER_VENDOR_MAPPINGs { get; set; }
        public virtual DbSet<MBR_MST_LSP_PRICE_FORMULA> MBR_MST_LSP_PRICE_FORMULAs { get; set; }
        public virtual DbSet<MBR_MST_MARKET_PRICE_MAPPING> MBR_MST_MARKET_PRICE_MAPPINGs { get; set; }

        public virtual DbSet<MBR_MST_MASTER_MAPPING> MBR_MST_MASTER_MAPPINGs { get; set; }
        public virtual DbSet<MBR_MST_MASTER_EXCEL_MAPPING> MBR_MST_MASTER_EXCEL_MAPPINGs { get; set; }
        public virtual DbSet<MBR_MST_MASTER_EXCEL> MBR_MST_MASTER_EXCELs { get; set; }
        public virtual DbSet<MBR_MST_MASTER> MBR_MST_MASTERs { get; set; }
        public virtual DbSet<MBR_MST_EXPORT_MAPPING> MBR_MST_EXPORT_MAPPINGs { get; set; }
        public virtual DbSet<MBR_MST_DELETE_FLAG> MBR_MST_DELETE_FLAGs { get; set; }
        public virtual DbSet<MBR_MST_HISTORY_TYPE> MBR_MST_HISTORY_TYPEs { get; set; }
        public virtual DbSet<MBR_MST_DATAFACTORY_RUN> MBR_MST_DATAFACTORY_RUNs { get; set; }
        public virtual DbSet<MBR_MST_CASE> MBR_MST_CASEs { get; set; }
        public virtual DbSet<MBR_MST_SCENARIO> MBR_MST_SCENARIOs { get; set; }
        public virtual DbSet<MBR_MST_FormulaParameterMapping> MBR_MST_FormulaParameterMapping { get; set; }
        public virtual DbSet<MBR_MST_MAINTAIN_PRICE> MBR_MST_MAINTAIN_PRICEs { get; set; }
        public virtual DbSet<MBR_MST_PLANTYPE> MBR_MST_PLANTYPE { get; set; }
        public virtual DbSet<MBR_MST_OPTIENCE> MBR_MST_OPTIENCEs { get; set; }
        public virtual DbSet<MBR_MST_ASSUMPTION> MBR_MST_ASSUMPTIONs { get; set; }

        #endregion Master

        #region Temp

        public virtual DbSet<MBR_TMP_PRODUCT_MAPPING> MBR_TMP_PRODUCT_MAPPINGs { get; set; }
        public virtual DbSet<MBR_TMP_CUSTOMER_VENDOR_MAPPING> MBR_TMP_CUSTOMER_VENDOR_MAPPINGs { get; set; }
        public virtual DbSet<MBR_TMP_LSP_PRICE_FORMULA> MBR_TMP_LSP_PRICE_FORMULAs { get; set; }
        public virtual DbSet<MBR_TMP_MARKET_PRICE_MAPPING> MBR_TMP_MARKET_PRICE_MAPPINGs { get; set; }
        public virtual DbSet<MBR_TMP_MARKET_PRICE_FORECAST> MBR_TMP_MARKET_PRICE_FORECASTs { get; set; }
        public virtual DbSet<MBR_TMP_BEGINING_INVENTORY> MBR_TMP_BEGINING_INVENTORYs { get; set; }
        public virtual DbSet<MBR_TMP_FEED_CONSUMPTION> MBR_TMP_FEED_CONSUMPTIONs { get; set; }
        public virtual DbSet<MBR_TMP_FEED_PURCHASE> MBR_TMP_FEED_PURCHASEs { get; set; }
        public virtual DbSet<MBR_TMP_PRODUCTION_VOLUME> MBR_TMP_PRODUCTION_VOLUMEs { get; set; }
        public virtual DbSet<MRB_TMP_FEED_INFO> MRB_TMP_FEED_INFOs { get; set; }
        public virtual DbSet<MBR_TMP_SALES_VOLUME> MBR_TMP_SALES_VOLUMEs { get; set; }
        public virtual DbSet<MBR_TMP_SALES_PREVIEW_SUBMIT> MBR_TMP_SALES_PREVIEW_SUBMITs { get; set; }
        public virtual DbSet<MBR_TMP_ASSUMPTION> MBR_TMP_ASSUMPTIONs { get; set; }

        #endregion Temp

        #region Transation

        public virtual DbSet<MBR_TRN_MARKET_PRICE_FORECAST> MBR_TRN_MARKET_PRICE_FORECASTs { get; set; }
        public virtual DbSet<MBR_TRN_BEGINING_INVENTORY> MBR_TRN_BEGINING_INVENTORYs { get; set; }
        public virtual DbSet<MBR_TRN_FEED_CONSUMPTION> MBR_TRN_FEED_CONSUMPTIONs { get; set; }
        public virtual DbSet<MBR_TRN_FEED_PURCHASE> MBR_TRN_FEED_PURCHASEs { get; set; }
        public virtual DbSet<MBR_TRN_PRODUCTION_VOLUME> MBR_TRN_PRODUCTION_VOLUMEs { get; set; }
        public virtual DbSet<MRB_TRN_FEED_INFO> MRB_TRN_FEED_INFOs { get; set; }
        public virtual DbSet<MBR_TRN_SALES_VOLUME> MBR_TRN_SALES_VOLUMEs { get; set; }
        public virtual DbSet<MBR_TRN_MERGE_HISTORY> MBR_TRN_MERGE_HISTORYs { get; set; }

        #endregion Transation

        #region Logging

        public virtual DbSet<LOG_API> LOG_APIs { get; set; }
        public virtual DbSet<LOG_SEND_DWH> LOG_SEND_DWHs { get; set; }

        #endregion Logging

        #region Views

        public virtual DbSet<vMBR_MST_ProductMapping> vMBR_MST_ProductMapping { get; set; }
        public virtual DbSet<vMBR_MST_LSPPriceFormula> vMBR_MST_LSPPriceFormula { get; set; }
        public virtual DbSet<vMBR_MST_CustomerVendorMapping> vMBR_MST_CustomerVendorMapping { get; set; }
        public virtual DbSet<vMBR_MST_MarketPriceMapping> vMBR_MST_MarketPriceMapping { get; set; }

        #endregion Views

        #endregion Database model

        public DbConnection DbConnenct => this.Database.GetDbConnection();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost; port=3306; database=it1appdb; user=root; password=!P@ssw0rd; Persist Security Info=False; Connect Timeout=300");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (this._AppSettings != null && !string.IsNullOrEmpty(this._AppSettings.DatabaseSchema))
            //{
            //    modelBuilder.HasDefaultSchema(this._AppSettings.DatabaseSchema);
            //}
            if (this._AppSettings != null && this._AppSettings.databaseSchema != null && !string.IsNullOrEmpty(this._AppSettings.databaseSchema.mbr))
            {
                modelBuilder.HasDefaultSchema(this._AppSettings.databaseSchema.mbr);
            }

            modelBuilder.Entity<REL_GROUP_ROLE>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.RoleId });
            });

            modelBuilder.Entity<REL_MENU_ROLE>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.RoleId });
            });

            modelBuilder.Entity<REL_USER_GROUP>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId });
            });

            #region master

            modelBuilder.Entity<MBR_FCT_MARKETPRICEOLEFINS>().HasNoKey();
            modelBuilder.Entity<MBR_MST_PRODUCT_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.MaterialCode, e.VersionNo, e.SourceSystem });
            });

            modelBuilder.Entity<MBR_MST_CUSTOMER_VENDOR_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.CustomerShortName, e.Type, e.VersionNo, e.SourceSystem });
            });
            modelBuilder.Entity<MBR_MST_LSP_PRICE_FORMULA>(entity =>
            {
                entity.HasKey(e => new { e.FormulaName, e.VersionNo });
            });
            modelBuilder.Entity<MBR_MST_MARKET_PRICE_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.MarketPriceMI, e.MarketPriceWebPricing, e.VersionNo, e.MarketPriceName });
            });
            modelBuilder.Entity<MBR_MST_MASTER_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.MasterId, e.Variable });
            });
            modelBuilder.Entity<MBR_MST_MASTER_EXCEL_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.ExcelId, e.Variable });
            });
            modelBuilder.Entity<MBR_MST_EXPORT_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.MasterId, e.Variable });
            });
            modelBuilder.Entity<MBR_MST_USERS>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Username });
            });
            modelBuilder.Entity<MBR_MST_ROLES>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RoleName });
            });
            modelBuilder.Entity<MBR_MST_PAGES>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Pages });
            });

            modelBuilder.Entity<MBR_MST_FormulaParameterMapping>(entity =>
            {
                entity.HasKey(e => new { e.FormulaID, e.FormulaName, e.Parameter, e.ConditionVariable });
            });

            modelBuilder.Entity<MBR_MST_PLANTYPE>(entity =>
            {
                entity.HasKey(e => new { e.PlanTypeId });
            });

            modelBuilder.Entity<MBR_MST_LOCKUNLOCKCYCLE>(entity =>
            {
                entity.HasKey(e => new { e.PlanType, e.Cycle, e.Case });
            });

            modelBuilder.Entity<MBR_MST_ASSUMPTION>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.PlanType, e.Cycle, e.Case, e.VersionNo });
            });

            #region Set Unique

            //modelBuilder.Entity<MBR_MST_PRODUCT_MAPPING>().HasIndex(i => new { i.ProductShortName, i.VersionNo }).IsUnique();
            //modelBuilder.Entity<MBR_MST_CUSTOMER_VENDOR_MAPPING>().HasIndex(i => new { i.CustomerCode, i.VersionNo }).IsUnique();

            #endregion Set Unique

            #endregion master

            #region Temp

            modelBuilder.Entity<MBR_TMP_PRODUCT_MAPPING>(entity =>
                {
                    entity.HasKey(e => new { e.MaterialCode, e.VersionNo, e.SourceSystem });
                });

            modelBuilder.Entity<MBR_TMP_CUSTOMER_VENDOR_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.CustomerShortName, e.Type, e.VersionNo, e.SourceSystem });
            });
            modelBuilder.Entity<MBR_TMP_LSP_PRICE_FORMULA>(entity =>
            {
                entity.HasKey(e => new { e.FormulaName, e.VersionNo });
            });
            modelBuilder.Entity<MBR_TMP_MARKET_PRICE_MAPPING>(entity =>
            {
                entity.HasKey(e => new { e.MarketPriceMI, e.MarketPriceWebPricing, e.VersionNo, e.MarketPriceName });
            });
            modelBuilder.Entity<MBR_TMP_MARKET_PRICE_FORECAST>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.MarketSource, e.Cycle, e.MonthNo, e.RunId });
            });
            modelBuilder.Entity<MBR_TMP_FEED_PURCHASE>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.FeedName, e.MonthNo, e.MCSC, e.RunId });
            });
            modelBuilder.Entity<MBR_TMP_FEED_CONSUMPTION>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.FeedName, e.MonthNo, e.MCSC, e.RunId });
            });
            modelBuilder.Entity<MBR_TMP_PRODUCTION_VOLUME>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.ProductName, e.MonthNo, e.MCSC, e.RunId });
            });
            modelBuilder.Entity<MBR_TMP_BEGINING_INVENTORY>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Cycle, e.ProductShortName, e.MonthNo, e.MCSC, e.RunId, e.MaterialCode, e.SupplierKey });
            });
            modelBuilder.Entity<MBR_TMP_SALES_VOLUME>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.Product, e.MCSC, e.Channel, e.FormulaName, e.Customers, e.TermSpot, e.PriceSet, e.MonthNo, e.RunId });
            });
            modelBuilder.Entity<MRB_TMP_FEED_INFO>(entity =>
            {
                entity.HasKey(e => new { e.ID, e.RunId });
            });

            modelBuilder.Entity<MBR_TMP_ASSUMPTION>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.PlanType, e.Cycle, e.Case, e.VersionNo, e.RunId });
            });

            #region Set Unique

            //modelBuilder.Entity<MBR_TMP_PRODUCT_MAPPING>().HasIndex(i => new { i.ProductShortName, i.VersionNo }).IsUnique();

            //modelBuilder.Entity<MBR_TMP_CUSTOMER_VENDOR_MAPPING>().HasIndex(i => new { i.CustomerCode, i.VersionNo }).IsUnique();

            #endregion Set Unique

            #endregion Temp

            #region Transation

            modelBuilder.Entity<MBR_TRN_MARKET_PRICE_FORECAST>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.MarketSource, e.Cycle, e.MonthNo });
            });
            modelBuilder.Entity<MBR_TRN_FEED_PURCHASE>(entity =>
           {
               entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.FeedName, e.MonthNo, e.MCSC });
           });
            modelBuilder.Entity<MBR_TRN_FEED_CONSUMPTION>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.FeedName, e.MonthNo, e.MCSC });
            });
            modelBuilder.Entity<MBR_TRN_PRODUCTION_VOLUME>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.ProductName, e.MonthNo, e.MCSC });
            });
            modelBuilder.Entity<MBR_TRN_BEGINING_INVENTORY>(entity =>
            {
                entity.HasKey(e => new { e.Case, e.PlanType, e.Cycle, e.ProductShortName, e.MonthNo, e.MCSC, e.MaterialCode, e.SupplierKey });
            });
            modelBuilder.Entity<MBR_TRN_SALES_VOLUME>(entity =>
           {
               entity.HasKey(e => new { e.Case, e.PlanType, e.Company, e.Cycle, e.Product, e.MCSC, e.Channel, e.FormulaName, e.Customers, e.TermSpot, e.PriceSet, e.MonthNo });
           });
            modelBuilder.Entity<MBR_TRN_MERGE_HISTORY>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ExcelId });
            });

            #endregion Transation

            #region Views

            modelBuilder.Entity<vMBR_MST_ProductMapping>().HasNoKey().ToView(nameof(vMBR_MST_ProductMapping));

            modelBuilder.Entity<vMBR_MST_LSPPriceFormula>().HasNoKey().ToView(nameof(vMBR_MST_LSPPriceFormula));

            modelBuilder.Entity<vMBR_MST_CustomerVendorMapping>().HasNoKey().ToView(nameof(vMBR_MST_CustomerVendorMapping));

            modelBuilder.Entity<vMBR_MST_MarketPriceMapping>().HasNoKey().ToView(nameof(vMBR_MST_MarketPriceMapping));

            #endregion Views
        }
    }
}