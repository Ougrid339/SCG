using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterPlanTypeRepo : IRepositoryBase<MBR_MST_PLANTYPE>
    {
        List<MBR_MST_PLANTYPE> GetPlanType();

        List<MBR_MST_PLANTYPE> GetPlanTypeWithActual();
    }
}
