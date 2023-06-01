using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MST_ROLE")]
    public class MST_ROLE
    {
        [Key]
        [Column("ID")]
        public short Id { get; set; }

        [Column("NAME")]
        [StringLength(200)]
        public string Name { get; set; }

        [Column("ROLE_TYPE_ID")]
        public int? RoleTypeId { get; set; }
    }
}