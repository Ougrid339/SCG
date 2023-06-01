using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterMaintainPriceRepo : RepositoryBase<MBR_MST_MAINTAIN_PRICE>, IMasterMaintainPriceRepo
    {
        public MasterMaintainPriceRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public MBR_MST_MAINTAIN_PRICE GetByMaintainId(int maintainId)
        {
            return _readContext.MBR_MST_MAINTAIN_PRICEs.FirstOrDefault(f => f.MaintainId == maintainId);
        }
    }
}
