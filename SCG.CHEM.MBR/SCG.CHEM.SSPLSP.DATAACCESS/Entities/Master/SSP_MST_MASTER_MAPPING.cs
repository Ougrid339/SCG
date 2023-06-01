using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MasterMapping")]
    public class SSP_MST_MASTER_MAPPING
    {
        [Key]
        public int MasterId { get; set; }

        [StringLength(50)]
        public string Variable { get; set; }

        [StringLength(50)]
        public string ExcelHeader { get; set; }

        public int? Sequence { get; set; }

        public bool? Require { get; set; }

        public bool? Primary { get; set; }

        public SSP_MST_MASTER_MAPPING(int MasterId, string Variable, string ExcelHeader, int? Sequence, bool? Require)
        {
            this.MasterId = MasterId;
            this.Variable = Variable;
            this.ExcelHeader = ExcelHeader;
            this.Sequence = Sequence;
            this.Require = Require;
        }

        public void MapVariableAndExcelHeader(string excelheader, bool? required = false)
        {
            this.ExcelHeader = excelheader;
            this.Require = required;
        }
    }
}