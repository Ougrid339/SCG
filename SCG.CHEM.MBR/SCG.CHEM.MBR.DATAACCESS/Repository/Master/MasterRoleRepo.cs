using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterRoleRepo : RepositoryBase<MBR_MST_ROLES>, IMasterRoleRepo
    {
        #region Inject

        public MasterRoleRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public IQueryable<MBR_MST_ROLES> Find(RoleSearchReqModel criteria)
        {
            var query = _readContext.MBR_MST_ROLESs.AsQueryable();

            #region Filter condition

            if (criteria.Id != null)
            {
                query = query.Where(x => x.Id == criteria.Id);
            }
            else
            {
                if (!string.IsNullOrEmpty(criteria.Name))
                {
                    query = query.Where(x => x.RoleName == criteria.Name);
                }
            }

            #endregion Filter condition

            return query.AsNoTracking();
        }
    }
}