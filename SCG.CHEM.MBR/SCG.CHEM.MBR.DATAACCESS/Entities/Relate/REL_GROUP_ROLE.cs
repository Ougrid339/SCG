using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Relate
{
    [Table("REL_GROUP_ROLE")]
    public class REL_GROUP_ROLE
    {
        [Column("GROUP_ID")]
        public short GroupId { get; set; }

        [Column("ROLE_ID")]
        public short RoleId { get; set; }

        public REL_GROUP_ROLE()
        {
        }

        public REL_GROUP_ROLE(GroupRoleModel model)
        {
            this.GroupId = model.GroupId;
            this.RoleId = model.RoleId;
        }
    }
}