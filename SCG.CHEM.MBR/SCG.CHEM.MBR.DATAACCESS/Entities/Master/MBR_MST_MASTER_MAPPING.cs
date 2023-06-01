using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_MasterMapping")]
    public class MBR_MST_MASTER_MAPPING
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

        public bool IsDownload { get; set; }

        public bool IsUpload { get; set; }

        public MBR_MST_MASTER_MAPPING(int MasterId, string Variable, string ExcelHeader, int? Sequence, bool? Require)
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