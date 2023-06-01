using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterRegionRepo : RepositoryBase<SSP_MST_REGION>, IMasterRegionRepo
    {
        #region Inject

        public MasterRegionRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_REGION> GetRegionByCodes(List<string> data)
        {
            var result = _readContext.SSP_MST_REGIONs.Where(w => data.Contains(w.Region)).ToList();
            return result;
        }
    }
}