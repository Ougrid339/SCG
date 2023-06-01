using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_HistoryType")]
    public class SSP_MST_HISTORY_TYPE
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public SSP_MST_HISTORY_TYPE()
        { }
    }
}