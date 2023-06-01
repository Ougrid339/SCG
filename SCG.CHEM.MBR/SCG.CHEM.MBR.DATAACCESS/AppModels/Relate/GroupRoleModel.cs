using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Relate
{
    public class GroupRoleModel
    {
        public short GroupId { get; set; }
        public short RoleId { get; set; }
    }

    public class GroupRoleSearchReqModel
    {
        public short? GroupId { get; set; }
        public short? RoleId { get; set; }
    }

    public class GroupRoleSearchResModel
    {
        public short? GroupId { get; set; }
        public short? RoleId { get; set; }

        public GroupRoleSearchResModel()
        { }

        public GroupRoleSearchResModel(REL_GROUP_ROLE db)
        {
            this.GroupId = db.GroupId;
            this.RoleId = db.RoleId;
        }
    }
}