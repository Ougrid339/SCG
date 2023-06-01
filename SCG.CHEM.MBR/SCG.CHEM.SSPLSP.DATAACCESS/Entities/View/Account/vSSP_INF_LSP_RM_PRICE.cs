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
    public class vSSP_INF_LSP_RM_PRICE
    {
        [Column("CYCLE_NAME")]
        public string? CycleName { get; set; }

        [Column("COMPANY")]
        public string? Company { get; set; }

        [Column("MATERIAL_CODE")]
        public string? MaterialCode { get; set; }

        [Column("MATERIAL_NAME")]
        public string? MaterialName { get; set; }

        [Column("DATA_PART")]
        public string? DataPart { get; set; }

        [Column("TIER")]
        public string? Tier { get; set; }

        public decimal? M1 { get; set; }
        public decimal? M2 { get; set; }
        public decimal? M3 { get; set; }
        public decimal? M4 { get; set; }
        public decimal? M5 { get; set; }
        public decimal? M6 { get; set; }
        public decimal? M7 { get; set; }
        public decimal? M8 { get; set; }
        public decimal? M9 { get; set; }
        public decimal? M10 { get; set; }
        public decimal? M11 { get; set; }
        public decimal? M12 { get; set; }
        public decimal? M13 { get; set; }
        public decimal? M14 { get; set; }
        public decimal? M15 { get; set; }
        public decimal? M16 { get; set; }
        public decimal? M17 { get; set; }
        public decimal? M18 { get; set; }

        [Column("Price-M1")]
        public decimal? Price_M1 { get; set; }

        [Column("Price-M2")]
        public decimal? Price_M2 { get; set; }

        [Column("Price-M3")]
        public decimal? Price_M3 { get; set; }

        [Column("Price-M4")]
        public decimal? Price_M4 { get; set; }

        [Column("Price-M5")]
        public decimal? Price_M5 { get; set; }

        [Column("Price-M6")]
        public decimal? Price_M6 { get; set; }

        [Column("Price-M7")]
        public decimal? Price_M7 { get; set; }

        [Column("Price-M8")]
        public decimal? Price_M8 { get; set; }

        [Column("Price-M9")]
        public decimal? Price_M9 { get; set; }

        [Column("Price-M10")]
        public decimal? Price_M10 { get; set; }

        [Column("Price-M11")]
        public decimal? Price_M11 { get; set; }

        [Column("Price-M12")]
        public decimal? Price_M12 { get; set; }

        [Column("Price-M13")]
        public decimal? Price_M13 { get; set; }

        [Column("Price-M14")]
        public decimal? Price_M14 { get; set; }

        [Column("Price-M15")]
        public decimal? Price_M15 { get; set; }

        [Column("Price-M16")]
        public decimal? Price_M16 { get; set; }

        [Column("Price-M17")]
        public decimal? Price_M17 { get; set; }

        [Column("Price-M18")]
        public decimal? Price_M18 { get; set; }
    }
}