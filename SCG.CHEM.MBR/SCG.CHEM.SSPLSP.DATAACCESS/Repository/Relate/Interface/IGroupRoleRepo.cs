using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Relate;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate.Interface
{
    public interface IGroupRoleRepo : IRepositoryBase<REL_GROUP_ROLE>
    {
        IQueryable<REL_GROUP_ROLE> FindAll();

        IQueryable<REL_GROUP_ROLE> Find(GroupRoleSearchReqModel criteria);

        REL_GROUP_ROLE FindByKey(GroupRoleModel key);

        bool IsExist(GroupRoleModel req);
    }
}