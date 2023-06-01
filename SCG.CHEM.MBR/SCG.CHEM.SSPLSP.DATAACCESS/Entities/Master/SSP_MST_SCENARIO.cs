using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Scenario")]
    public class SSP_MST_SCENARIO
    {
        [Key]
        public int SceneId { get; set; }

        [StringLength(50)]
        public string SceneDesc { get; set; }

        [StringLength(20)]
        public string SceneSDesc { get; set; }
    }
}