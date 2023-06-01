using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MaterialGradeLevel")]
    public class SSP_MST_MATERIAL_GRADE_LEVEL
    {
        [Key]
        [StringLength(20)]
        public string Grade { get; set; }

        [Key]
        [StringLength(3)]
        public string MatPrefix { get; set; }

        [StringLength(10)]
        public string? MINNZPCK { get; set; }

        [StringLength(10)]
        public string? MINPCK { get; set; }

        [StringLength(4)]
        public string? MatGroup { get; set; }

        [StringLength(10)]
        public string? ProdSub { get; set; }

        [StringLength(50)]
        public string? ProdSubDescr { get; set; }

        [StringLength(10)]
        public string? AppCode { get; set; }

        [StringLength(50)]
        public string? AppName { get; set; }

        [StringLength(5)]
        public string? HVACode { get; set; }

        [StringLength(60)]
        public string? HVAName { get; set; }

        [StringLength(20)]
        public string? MarketPriceGroup { get; set; }

        [StringLength(20)]
        public string? MarketPriceSource { get; set; }

        [StringLength(1)]
        public string? BOMFlag { get; set; }
    }
}