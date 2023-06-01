using System;
using System.Collections.Generic;
using System.Linq;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterGroupRepo : RepositoryBase<MST_GROUP>, IMasterGroupRepo
    {
        #region Inject

        public MasterGroupRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
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