using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterGroupRepo : IRepositoryBase<MST_GROUP>
    {
        IQueryable<MST_GROUP> Find(GroupSearchReqModel criteria);
    }
}