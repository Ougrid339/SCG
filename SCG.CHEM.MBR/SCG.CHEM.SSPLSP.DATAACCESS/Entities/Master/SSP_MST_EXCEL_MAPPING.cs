using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MasterExcelMapping")]
    public class SSP_MST_EXCEL_MAPPING
    {
        [Key]
        public int ExcelId { get; set; }

        [Key]
        [StringLength(50)]
        public string Variable { get; set; }

        [StringLength(50)]
        public string ExcelHeader { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Sequence { get; set; }

        public bool? Require { get; set; }

        public bool? Primary { get; set; }

        public SSP_MST_EXCEL_MAPPING(int ExcelId, string Variable, string ExcelHeader, string Description, int? Sequence, bool? Require)
        {
            this.ExcelId = ExcelId;
            this.Variable = Variable;
            this.ExcelHeader = ExcelHeader;
            this.Description = Description;
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