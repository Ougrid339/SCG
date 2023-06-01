using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterRoleRepo : RepositoryBase<SSP_MST_ROLES>, IMasterRoleRepo
    {
        #region Inject

        public MasterRoleRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public IQueryable<SSP_MST_ROLES> Find(RoleSearchReqModel criteria)
        {
            var query = _readContext.SSP_MST_ROLESs.AsQueryable();

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