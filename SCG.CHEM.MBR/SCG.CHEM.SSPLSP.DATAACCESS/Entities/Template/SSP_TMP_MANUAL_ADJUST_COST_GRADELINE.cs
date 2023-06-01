using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template
{
    [Table("SSP_TMP_ManualAdjustCostGradeLine")]
    public class SSP_TMP_MANUAL_ADJUST_COST_GRADELINE : BaseDatabaseContext
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(10)]
        public string PlanType { get; set; }

        [Key]
        [StringLength(3)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(20)]
        public string Grade { get; set; }

        [Key]
        [StringLength(10)]
        public string Plant { get; set; }

        [Key]
        [StringLength(10)]
        public string ProductionLine { get; set; }

        public int UnitId { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal TransitionCost { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldC2 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldC3 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldC6 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldC8 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldBU1 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldVCM { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldMBLD { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldMBPD { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldMBHD { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedPolymerSaving { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedConversion { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedFouledHeaxane { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedSteam { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedPackage { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedSemiVC { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedCPDConversion { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedProductionRate { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedTollingCost { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedFOHCost { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedMaintenanceCost { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedInventoryCost { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustYieldVentGasC2 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustYieldVentGasC3 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal BOI { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldWaxLV { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldWaxHV { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedYieldTolling { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedCatalyst { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal AdjustedAdditive { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedYieldSeed { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedSeedConversion { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedThirdRM { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedOther { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedInprocessInventoryCost { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedReserved1 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedReserved2 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedReserved3 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedReserved4 { get; set; }

        [Column(TypeName = "decimal(15, 5)")]
        public decimal? AdjustedReserved5 { get; set; }

        public SSP_TMP_MANUAL_ADJUST_COST_GRADELINE()
        { }

        public SSP_TMP_MANUAL_ADJUST_COST_GRADELINE(SSP_MST_MANUAL_ADJUST_COST_GRADELINE data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_TMP_MANUAL_ADJUST_COST_GRADELINE(string productionSite, string planType, string matPrefix, string grade,
            string plant, string productionLine, int unitId, decimal transitionCost, decimal adjustedYieldC2, decimal adjustedYieldC3,
            decimal adjustedYieldC6, decimal adjustedYieldC8, decimal adjustedYieldBU1, decimal adjustedYieldVCM, decimal adjustedYieldMBLD,
            decimal adjustedYieldMBPD, decimal adjustedYieldMBHD, decimal adjustedPolymerSaving, decimal adjustedConversion, decimal adjustedFouledHeaxane,
            decimal adjustedSteam, decimal adjustedPackage, decimal adjustedSemiVC, decimal adjustedCPDConversion, decimal adjustedProductionRate,
            decimal adjustedTollingCost, decimal adjustedFOHCost, decimal adjustedMaintenanceCost, decimal adjustedInventoryCost, decimal adjustYieldVentGasC2,
            decimal adjustYieldVentGasC3, decimal bOI, decimal adjustedYieldWaxLV, decimal adjustedYieldWaxHV, decimal adjustedYieldTolling, decimal adjustedCatalyst,
            decimal adjustedAdditive, decimal? adjustedYieldSeed, decimal? adjustedSeedConversion, decimal? adjustedThirdRM, decimal? adjustedOther,
            decimal? adjustedInprocessInventoryCost, decimal? adjustedReserved1, decimal? adjustedReserved2, decimal? adjustedReserved3, decimal? adjustedReserved4,
            decimal? adjustedReserved5, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            PlanType = planType;
            MatPrefix = matPrefix;
            Grade = grade;
            Plant = plant;
            ProductionLine = productionLine;
            UnitId = unitId;
            TransitionCost = transitionCost;
            AdjustedYieldC2 = adjustedYieldC2;
            AdjustedYieldC3 = adjustedYieldC3;
            AdjustedYieldC6 = adjustedYieldC6;
            AdjustedYieldC8 = adjustedYieldC8;
            AdjustedYieldBU1 = adjustedYieldBU1;
            AdjustedYieldVCM = adjustedYieldVCM;
            AdjustedYieldMBLD = adjustedYieldMBLD;
            AdjustedYieldMBPD = adjustedYieldMBPD;
            AdjustedYieldMBHD = adjustedYieldMBHD;
            AdjustedPolymerSaving = adjustedPolymerSaving;
            AdjustedConversion = adjustedConversion;
            AdjustedFouledHeaxane = adjustedFouledHeaxane;
            AdjustedSteam = adjustedSteam;
            AdjustedPackage = adjustedPackage;
            AdjustedSemiVC = adjustedSemiVC;
            AdjustedCPDConversion = adjustedCPDConversion;
            AdjustedProductionRate = adjustedProductionRate;
            AdjustedTollingCost = adjustedTollingCost;
            AdjustedFOHCost = adjustedFOHCost;
            AdjustedMaintenanceCost = adjustedMaintenanceCost;
            AdjustedInventoryCost = adjustedInventoryCost;
            AdjustYieldVentGasC2 = adjustYieldVentGasC2;
            AdjustYieldVentGasC3 = adjustYieldVentGasC3;
            BOI = bOI;
            AdjustedYieldWaxLV = adjustedYieldWaxLV;
            AdjustedYieldWaxHV = adjustedYieldWaxHV;
            AdjustedYieldTolling = adjustedYieldTolling;
            AdjustedCatalyst = adjustedCatalyst;
            AdjustedAdditive = adjustedAdditive;
            AdjustedYieldSeed = adjustedYieldSeed;
            AdjustedSeedConversion = adjustedSeedConversion;
            AdjustedThirdRM = adjustedThirdRM;
            AdjustedOther = adjustedOther;
            AdjustedInprocessInventoryCost = adjustedInprocessInventoryCost;
            AdjustedReserved1 = adjustedReserved1;
            AdjustedReserved2 = adjustedReserved2;
            AdjustedReserved3 = adjustedReserved3;
            AdjustedReserved4 = adjustedReserved4;
            AdjustedReserved5 = adjustedReserved5;
            StartMonth = startMonth;

            DateTime dt;
            var isValid = DateTime.TryParseExact(startMonth, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            if (isValid)
                this.FirstDate = dt;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.VersionNo = versionNo;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete()
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }
    }
}