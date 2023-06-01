using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Account
{
    [Keyless]
    public class vSSP_INF_LSP_PRODUCTION_PLAN
    {
        [Column("VERSION")]
        public string? Version { get; set; }

        [Column("CYCLE_NAME")]
        public string? CycleName { get; set; }

        [Column("CAL_YEAR_MONTH")]
        public string? CalYearMonth { get; set; }

        [Column("MANUFAC_COMP")]
        public string? ManuFacComp { get; set; }

        [Column("PLANT")]
        public string? Plant { get; set; }

        [Column("PRODUCTION_LINE")]
        public string? ProductionLine { get; set; }

        [Column("MAT_CODE_TRN")]
        public string? MatCodeTRN { get; set; }

        [Column("MAT_CODE_MST")]
        public string? MatCodeMST { get; set; }

        [Column("GRADE_MST")]
        public string? GradeMST { get; set; }

        [Column("PACKAGE")]
        public string? Package { get; set; }

        [Column("NEW_PROD_DESCR")]
        public string? NewProdDescr { get; set; }

        [Column("NEW_PROD_FLAG")]
        public int? NewProdFlag { get; set; }

        [Column("REMARK")]
        public string? Remark { get; set; }

        [Column("UNIT")]
        public string? Unit { get; set; }

        [Column("TON_PRODUCTION")]
        public decimal? TonProduction { get; set; }

        [Column("PLANNING_GROUP")]
        public string? PlanningGroup { get; set; }
    }
}