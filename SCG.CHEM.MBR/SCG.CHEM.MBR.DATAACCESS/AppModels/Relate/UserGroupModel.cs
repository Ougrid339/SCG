using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Relate
{
    public class UserGroupModel
    {
        public string UserId { get; set; }
        public short GroupId { get; set; }
    }

    public class UserGroupSearchReqModel
    {
        public string? UserId { get; set; }
        public short? GroupId { get; set; }
    }

    public class UserGroupSearchResModel
    {
        public string? UserId { get; set; }
        public short? GroupId { get; set; }

        public UserGroupSearchResModel()
        { }

        public UserGroupSearchResModel(REL_USER_GROUP db)
        {
            this.GroupId = db.GroupId;
            this.UserId = db.UserId;
        }
    }
}