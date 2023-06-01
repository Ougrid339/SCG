using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.MBR.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Linq;
using SCG.CHEM.MBR.DATAACCESS.Repository.Relate.Interface;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;
using Microsoft.EntityFrameworkCore;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Relate
{
    public class GroupRoleRepo : RepositoryBase<REL_GROUP_ROLE>, IGroupRoleRepo
    {
        #region Inject

        public GroupRoleRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public IQueryable<REL_GROUP_ROLE> FindAll()
        {
            var query = _readContext.REL_GROUP_ROLEs.AsQueryable();
            return query.AsNoTracking();
        }

        public IQueryable<REL_GROUP_ROLE> Find(GroupRoleSearchReqModel criteria)
        {
            var query = _readContext.REL_GROUP_ROLEs.AsQueryable();

            #region Filter condition

            if (criteria.GroupId != null)
            {
                query = query.Where(x => x.GroupId == criteria.GroupId);
            }

            if (criteria.RoleId != null)
            {
                query = query.Where(x => x.RoleId == criteria.RoleId);
            }

            #endregion Filter condition

            return query.AsNoTracking();
        }

        public REL_GROUP_ROLE FindByKey(GroupRoleModel key)
        {
            var query = _readContext.REL_GROUP_ROLEs.AsQueryable();

            #region Filter condition

            query = query.Where(x => x.GroupId == key.GroupId && x.RoleId == key.RoleId);

            #endregion Filter condition

            return query.FirstOrDefault();
        }

        public bool IsExist(GroupRoleModel req)
        {
            var query = _readContext.REL_GROUP_ROLEs.AsQueryable();

            query = query.Where(x => x.RoleId == req.RoleId && x.GroupId == req.GroupId);
            var result = query.Any();

            return result;
        }
    }
}