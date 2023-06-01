using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MST_MENU")]
    public class MST_MENU
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("PARENT_ID")]
        public int? ParentId { get; set; }

        [Required]
        [Column("NAME")]
        public string Name { get; set; }

        [Column("ICON")]
        public string? Icon { get; set; }

        [Column("ACTION")]
        public string Action { get; set; }

        [Column("ORDER")]
        public int? Order { get; set; }
    }
}