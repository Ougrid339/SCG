using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Linq;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Relate;
using Microsoft.EntityFrameworkCore;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate
{
    public class UserGroupRepo : RepositoryBase<REL_USER_GROUP>, IUserGroupRepo
    {
        #region Inject

        public UserGroupRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public IQueryable<REL_USER_GROUP> Find(UserGroupSearchReqModel criteria)
        {
            var query = _readContext.REL_USER_GROUPs.AsQueryable();

            #region Filter condition

            if (criteria.GroupId != null)
            {
                query = query.Where(x => x.GroupId == criteria.GroupId);
            }

            if (criteria.UserId != null)
            {
                query = query.Where(x => x.UserId == criteria.UserId);
            }

            #endregion Filter condition

            return query.AsNoTracking();
        }

        public REL_USER_GROUP FindByKey(UserGroupModel key)
        {
            var query = _readContext.REL_USER_GROUPs.AsQueryable();

            #region Filter condition

            query = query.Where(x => x.GroupId == key.GroupId && x.UserId == key.UserId);

            #endregion Filter condition

            return query.FirstOrDefault();
        }

        public bool IsExist(UserGroupModel req)
        {
            var query = _readContext.REL_USER_GROUPs.AsQueryable();

            query = query.Where(x => x.UserId == req.UserId && x.GroupId == req.GroupId);
            var result = query.Any();

            return result;
        }
    }
}