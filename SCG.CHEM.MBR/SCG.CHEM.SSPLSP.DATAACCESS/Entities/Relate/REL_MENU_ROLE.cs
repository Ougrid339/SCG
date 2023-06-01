using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate
{
    [Table("REL_MENU_ROLE")]
    public class REL_MENU_ROLE
    {
        [Column("MENU_ID")]
        public int MenuId { get; set; }

        [Column("ROLE_ID")]
        public short RoleId { get; set; }
    }
}