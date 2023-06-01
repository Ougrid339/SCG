using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_ExportMapping")]
    public class MBR_MST_EXPORT_MAPPING
    {
        [Key]
        public int MasterId { get; set; }

        [Key]
        [StringLength(50)]
        public string Variable { get; set; }

        [StringLength(50)]
        public string ExcelHeader { get; set; }

        public int? Sequence { get; set; }

        public MBR_MST_EXPORT_MAPPING(int masterId, string variable, string excelHeader, int? sequence)
        {
            MasterId = masterId;
            Variable = variable;
            ExcelHeader = excelHeader;
            Sequence = sequence;
        }

        public void MapVariableAndExcelHeader(string excelheader)
        {
            this.ExcelHeader = excelheader;
        }
    }
}