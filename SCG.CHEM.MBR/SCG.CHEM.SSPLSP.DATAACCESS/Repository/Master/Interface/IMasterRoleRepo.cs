using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRoleRepo : IRepositoryBase<SSP_MST_ROLES>
    {
        IQueryable<SSP_MST_ROLES> Find(RoleSearchReqModel criteria);
    }
}