using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_SalesGroup")]
    public class SSP_MST_SALES_GROUP
    {
        [Key]
        [StringLength(3)]
        public string SalesGroupCode { get; set; }

        [StringLength(50)]
        public string SalesGroupSDesc { get; set; }

        [StringLength(4)]
        public string SalesOrg { get; set; }

        [StringLength(4)]
        public string CompanyCode { get; set; }

        [StringLength(20)]
        public string? ProductionSite { get; set; }

        public bool? DummyFlag { get; set; }

        [StringLength(10)]
        public string CustomerConvert { get; set; }

        [StringLength(3)]
        public string? SalesGroupCodeConvert { get; set; }

        [StringLength(4)]
        public string? SalesOrgConvert { get; set; }

        [StringLength(4)]
        public string? CompanyCodeConvert { get; set; }
    }
}