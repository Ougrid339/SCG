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
    public class vSSP_MST_MONOMER_PRICE_TEMPLATE
    {
        public string Monomer { get; set; }
        public string VersionName { get; set; }
        public DateTime? FirstDate { get; set; }
        public string Unit { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM1 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM2 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM3 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM4 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM5 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM6 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM7 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM8 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM9 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM10 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM11 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM12 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM13 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM14 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM15 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM16 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM17 { get; set; }

        [Column(TypeName = "decimal(10, 5)")]
        public decimal PriceM18 { get; set; }
    }
}