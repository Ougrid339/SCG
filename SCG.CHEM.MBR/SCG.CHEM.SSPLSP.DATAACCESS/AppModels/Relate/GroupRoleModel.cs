using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Relate
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