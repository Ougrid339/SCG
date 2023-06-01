using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Relate
{
    [Table("REL_USER_GROUP")]
    public class REL_USER_GROUP
    {
        [Column("USER_ID")]
        [StringLength(50)]
        public string UserId { get; set; }

        [Column("GROUP_ID")]
        public short GroupId { get; set; }

        public REL_USER_GROUP()
        {
        }

        public REL_USER_GROUP(UserGroupModel model)
        {
            this.GroupId = model.GroupId;
            this.UserId = model.UserId;
        }
    }
}