using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate
{
    [Table("REL_USER_ROLE")]
    public class REL_USER_ROLE
    {
        [Key]
        [Column("USER_ID")]
        [StringLength(50)]
        public string UserId { get; set; }

        [Column("ROLE_ID")]
        [Required]
        public int RoleId { get; set; }
    }
}