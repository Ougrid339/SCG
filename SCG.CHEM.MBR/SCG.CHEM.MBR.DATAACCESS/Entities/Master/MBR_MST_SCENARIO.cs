using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_Scenario")]
    public class MBR_MST_SCENARIO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SceneId { get; set; }
        [StringLength(50)]
        public string SceneDesc { get; set; }
        [StringLength(20)]
        public string SceneSDesc { get; set; }
    }
}
