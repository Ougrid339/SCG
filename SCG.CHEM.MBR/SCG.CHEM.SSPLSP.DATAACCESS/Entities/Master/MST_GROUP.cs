using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("MST_GROUP")]
    public class MST_GROUP
    {
        [Key]
        [Column("ID")]
        public short Id { get; set; }

        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}