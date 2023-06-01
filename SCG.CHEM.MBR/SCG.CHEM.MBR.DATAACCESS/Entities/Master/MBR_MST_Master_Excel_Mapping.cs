using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_MasterExcelMapping")]
    public class MBR_MST_MASTER_EXCEL_MAPPING
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

        public bool IsDownload { get; set; }

        public bool IsUpload { get; set; }

        public MBR_MST_MASTER_EXCEL_MAPPING(int ExcelId, string Variable, string ExcelHeader, string Description, int? Sequence, bool? Require)
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