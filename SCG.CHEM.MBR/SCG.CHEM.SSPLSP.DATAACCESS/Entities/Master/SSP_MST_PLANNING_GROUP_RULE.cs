using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_PlanningGroupRule")]
    public class SSP_MST_PLANNING_GROUP_RULE
    {
        [Key]
        public bool IsNotPlanningGroupName { get; set; }

        [Key]
        [StringLength(50)]
        public string PlanningGroupName { get; set; }

        [Key]
        public bool IsNotMatPrefix { get; set; }

        [Key]
        [StringLength(3)]
        public string MatPrefix { get; set; }

        [Key]
        public bool IsNotMaterialGroup { get; set; }

        [Key]
        [StringLength(4)]
        public string MaterialGroup { get; set; }

        [Key]
        public bool IsNotProduct { get; set; }

        [Key]
        [StringLength(50)]
        public string Product { get; set; }

        [Key]
        public bool IsNotProductSub { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductSub { get; set; }

        [Key]
        public bool IsNotApplication { get; set; }

        [Key]
        [StringLength(50)]
        public string Application { get; set; }

        [Key]
        public bool IsNotProductForm { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductForm { get; set; }

        [Key]
        public bool IsNotProductColor { get; set; }

        [Key]
        [StringLength(50)]
        public string ProductColor { get; set; }
    }
}