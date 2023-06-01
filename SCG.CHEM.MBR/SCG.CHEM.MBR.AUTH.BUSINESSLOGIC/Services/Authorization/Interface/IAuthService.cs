using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Authorization
{
    public interface IAuthService : IBaseService
    {
        List<RoleSearchResModel> FindRole(RoleSearchReqModel searchReqModel);

        ResponseModel AddGroupRole(GroupRoleModel req);

        ResponseModel DeleteGroupRole(GroupRoleModel req);
    }
}