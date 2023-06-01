using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRefGradeRepo : IRepositoryBase<SSP_MST_REF_GRADE>
    {
        List<PackagingRefGradeMasterSheet> GetMasterRefGradeByPlanType(string plantype);
    }
}