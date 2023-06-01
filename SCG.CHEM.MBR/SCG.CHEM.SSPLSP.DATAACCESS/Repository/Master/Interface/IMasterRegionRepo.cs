using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRegionRepo : IRepositoryBase<SSP_MST_REGION>
    {
        List<SSP_MST_REGION> GetRegionByCodes(List<string> data);
    }
}