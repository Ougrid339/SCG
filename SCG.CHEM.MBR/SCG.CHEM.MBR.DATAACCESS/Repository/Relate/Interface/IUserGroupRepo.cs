using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Relate.Interface
{
    public interface IUserGroupRepo : IRepositoryBase<REL_USER_GROUP>
    {
        IQueryable<REL_USER_GROUP> Find(UserGroupSearchReqModel criteria);

        REL_USER_GROUP FindByKey(UserGroupModel key);

        bool IsExist(UserGroupModel req);
    }
}