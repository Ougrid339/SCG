using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Linq;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using Microsoft.EntityFrameworkCore;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterGroupRepo : RepositoryBase<MST_GROUP>, IMasterGroupRepo

    {
        #region Inject

        public MasterGroupRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public IQueryable<MST_GROUP> Find(GroupSearchReqModel criteria)
        {
            var query = _readContext.MST_GROUPs.AsQueryable();

            #region Filter condition

            if (criteria.Id != null)
            {
                query = query.Where(x => x.Id == criteria.Id);
            }
            else
            {
                if (!string.IsNullOrEmpty(criteria.Name))
                {
                    query = query.Where(x => x.Name == criteria.Name);
                }
            }

            #endregion Filter condition

            return query.AsNoTracking();
        }
    }
}