using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterGenerateRunningRepo : IRepositoryBase<SSP_MST_GENERATE_RUNNING>
    {
        SSP_MST_GENERATE_RUNNING GeyById(string id);
    }
}