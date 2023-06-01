using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template
{
    [Keyless]
    public class vSSP_MST_MANUAL_ADJUST_COST_GRADELINE_TEMPLATE
    {
        public DateTime? FirstDate { get; set; }

        public string PlanType { get; set; }

        public string ProductionSite { get; set; }

        public string StartMonth { get; set; }

        public string MatPrefix { get; set; }

        public string Grade { get; set; }

        public string Plant { get; set; }

        public string ProductionLine { get; set; }

        public string Unit { get; set; }

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

        [Column("AdjustedYieldVentGasC2", TypeName = "decimal(15, 5)")]
        public decimal AdjustYieldVentGasC2 { get; set; }

        [Column("AdjustedYieldVentGasC3", TypeName = "decimal(15, 5)")]
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

        [Column("Adjusted3rdRM", TypeName = "decimal(15, 5)")]
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
    }
}