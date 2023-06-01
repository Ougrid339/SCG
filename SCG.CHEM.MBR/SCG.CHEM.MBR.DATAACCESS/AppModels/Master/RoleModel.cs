using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Master
{
    public class RoleSearchReqModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class RoleSearchResModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleSearchResModel()
        { }

        public RoleSearchResModel(MBR_MST_ROLES db)
        {
            this.Id = db.Id;
            this.Name = db.RoleName;
        }
    }
}