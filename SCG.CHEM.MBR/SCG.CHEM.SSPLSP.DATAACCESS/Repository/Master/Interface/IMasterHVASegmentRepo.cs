using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterHVASegmentRepo : IRepositoryBase<SSP_MST_HVA_SEGMENT>
    {
        SSP_MST_HVA_SEGMENT GetByHVACode(string code);

        List<SSP_MST_HVA_SEGMENT> GetByHVACodes(List<string> data);
    }
}