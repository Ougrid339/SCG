using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Relate;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate.Interface
{
    public interface IUserGroupRepo : IRepositoryBase<REL_USER_GROUP>
    {
        IQueryable<REL_USER_GROUP> Find(UserGroupSearchReqModel criteria);

        REL_USER_GROUP FindByKey(UserGroupModel key);

        bool IsExist(UserGroupModel req);
    }
}